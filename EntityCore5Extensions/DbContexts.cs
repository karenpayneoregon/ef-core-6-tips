using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using EntityCore5Extensions.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EntityCore5Extensions
{
    public static class DbContexts
    {
        /// <summary>
        /// Test connection with exception handling
        /// </summary>
        /// <param name="context"><see cref="DbContext"/></param>
        /// <returns></returns>
        public static async Task<(bool success, Exception exception)> CanConnectAsync(this DbContext context)
        {
            try
            {
                var result = await Task.Run(async () => await context.Database.CanConnectAsync());
                return (result, null);
            }
            catch (Exception e)
            {
                return (false, e);
            }
        }

        public static string GetTableNameBasic(this DbContext context, Type modelType)
        {
            var entityType = context.Model.FindEntityType(modelType);
            var schema = entityType.GetDefaultSchema();
            return $"{schema ?? "(unknown)"}.{entityType.GetTableName()}";
        }
        /// <summary>
        /// Get model names for a DbContext
        /// </summary>
        public static List<Type> GetModelNames(this DbContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            return context.Model.GetEntityTypes().Select(et => et.ClrType).ToList();
        }

        /// <summary>
        /// Get details for a model
        /// </summary>
        /// <param name="context">Active dbContext</param>
        /// <param name="modelName">Model name in context</param>
        /// <returns>List&lt;SqlColumn&gt;</returns>
        public static List<SqlColumn> GetModelProperties(this DbContext context, string modelName) 
        {

            if (context == null) throw new ArgumentNullException(nameof(context));

            var entityType = GetEntityType(context, modelName);

            var list = new List<SqlColumn>();

            IEnumerable<IProperty> properties = context.Model
                .FindEntityType(entityType ?? throw new InvalidOperationException())
                .GetProperties();

            foreach (IProperty itemProperty in properties)
            {
                var sqlColumn = new SqlColumn() { Name = itemProperty.Name };
                var comment = context.Model.FindEntityType(entityType)
                    .FindProperty(itemProperty.Name).GetComment();

                sqlColumn.Description = string.IsNullOrWhiteSpace(comment) ? itemProperty.Name : comment;

                sqlColumn.IsPrimaryKey = itemProperty.IsKey();
                sqlColumn.IsForeignKey = itemProperty.IsForeignKey();
                sqlColumn.IsNullable = itemProperty .IsColumnNullable();
                
                list.Add(sqlColumn);

            }

            return list;

        }

        /// <summary>
        /// Get Model navigations
        /// </summary>
        public static List<Details> GetNavigationDetails(this DbContext context) =>
            context.Model.GetEntityTypes()
                .Select(entityType => new Details(
                    entityType.ClrType.Name, 
                    entityType.GetNavigations()
                    .Select(navigation => navigation.PropertyInfo)))
                .ToList();

        /// <summary>
        /// Get type from model name
        /// </summary>
        /// <param name="context">Live DbContext</param>
        /// <param name="modelName">Valid model name</param>
        /// <returns></returns>
        private static Type GetEntityType(DbContext context, string modelName) => 
            context.Model.GetEntityTypes().Select(eType => eType.ClrType)
                .FirstOrDefault(type => type.Name == modelName);

        /// <summary>
        /// Get model comments by model type
        /// </summary>
        /// <param name="context">Live DbContext</param>
        /// <param name="modelType">Model type</param>
        /// <returns>IEnumerable&lt;ModelComment&gt;</returns>
        /// <remarks>
        /// context.Comments(typeof(Customers));
        /// </remarks>
        public static IEnumerable<ModelComment> Comments(this DbContext context, Type modelType)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            IEntityType entityType = context.Model.FindRuntimeEntityType(modelType);

            return entityType.GetProperties().Select(property => new ModelComment
            {
                Name = property.Name,
                Comment = property.GetComment()
            });

        }
        /// <summary>
        /// Returns a list of column names for model
        /// </summary>
        /// <param name="context">Live DbContext</param>
        /// <param name="modelName">Existing model name</param>
        /// <returns></returns>
        public static List<string> ColumnNames(this DbContext context, string modelName)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            var entityType = GetEntityType(context, modelName);

            var sqlColumnsList = new List<string>();

            IEnumerable<IProperty> properties = 
                context.Model.FindEntityType(entityType ?? throw new InvalidOperationException()).GetProperties();

            foreach (IProperty itemProperty in properties)
            {
                sqlColumnsList.Add(itemProperty.Name);
            }

            return sqlColumnsList;

        }
        /// <summary>
        /// Get comments for a specific model
        /// </summary>
        /// <param name="context">Live DbContext</param>
        /// <param name="modelName">Model name to get comments for</param>
        /// <returns>IEnumerable&lt;ModelComment&gt;</returns>
        /// <remarks>
        /// context.Comments("Customers");
        /// </remarks>
        public static IEnumerable<ModelComment> Comments(this DbContext context, string modelName)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            var entityType = GetEntityType(context, modelName);

            var commentList = new List<ModelComment>();

            IEnumerable<IProperty> properties = context.Model.FindEntityType(entityType ?? 
                throw new InvalidOperationException()).GetProperties();

            foreach (IProperty itemProperty in properties)
            {
                var modelComment = new ModelComment
                {
                    Name = itemProperty.Name,
                    Comment = context.Model.FindEntityType(entityType).FindProperty(itemProperty.Name).GetComment() ?? 
                              itemProperty.Name
                };
                
                commentList.Add(modelComment);
                
            }

            return commentList;

        }

        /// <summary>
        /// Find by one or more keys
        /// </summary>
        /// <typeparam name="T">Model</typeparam>
        /// <param name="dbContext">DbContext</param>
        /// <param name="keyValues">One or more keys</param>
        /// <code>
        /// await using var context = new NorthWindContext();
        /// var keys = new object[] {1, 2, 3, 4};
        /// var results = await context.FindAllAsync&lt;Category&gt;(keys);
        /// </code>
        public static Task<T[]> FindAllAsync<T>(this DbContext dbContext, params object[] keyValues) where T : class
        {
            var entityType = dbContext.Model.FindEntityType(typeof(T));
            var primaryKey = entityType.FindPrimaryKey();

            if (primaryKey.Properties.Count != 1)
            {
                throw new NotSupportedException("Only a single primary key is supported");
            }

            var pkProperty = primaryKey.Properties[0];
            var pkPropertyType = pkProperty.ClrType;

            foreach (var keyValue in keyValues)
            {
                if (!pkPropertyType.IsInstanceOfType(keyValue))
                {
                    throw new ArgumentException($"Key value '{keyValue}' is not of the right type");
                }
            }

            var pkMemberInfo = typeof(T).GetProperty(pkProperty.Name);

            if (pkMemberInfo is null)
            {
                throw new ArgumentException("Type does not contain the primary key as an accessible property");
            }

            var parameter = Expression.Parameter(typeof(T), "e");
            var body = Expression.Call(null, ContainsMethod,
                Expression.Constant(keyValues),
                Expression.Convert(Expression.MakeMemberAccess(parameter, pkMemberInfo), typeof(object)));
            var predicateExpression = Expression.Lambda<Func<T, bool>>(body, parameter);

            return dbContext.Set<T>().Where(predicateExpression).ToArrayAsync();
        }

        private static readonly MethodInfo ContainsMethod = typeof(Enumerable)
            .GetMethods()
            .FirstOrDefault(methodInfo => methodInfo.Name == "Contains" && methodInfo.GetParameters().Length == 2)?.MakeGenericMethod(typeof(object));

        /// <summary>
        /// Convert T[] to object[]
        /// </summary>
        /// <typeparam name="T">type to convert</typeparam>
        /// <param name="sender">array</param>
        /// <returns>object array</returns>
        public static object[] ToObjectArray<T>(this T[] sender) 
            => sender.OfType<object>().ToArray();
    }

    public class Details
    {
        public string Name { get; }
        public IEnumerable<PropertyInfo> NavigationProperties { get; }

        public Details(string name, IEnumerable<PropertyInfo> navigationProperties)
        {
            Name = name;
            NavigationProperties = navigationProperties;
        }
    }
}
