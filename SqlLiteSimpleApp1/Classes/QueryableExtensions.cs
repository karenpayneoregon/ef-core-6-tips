﻿using System.Linq.Expressions;

namespace SqlLiteSimpleApp1.Classes;

/// <summary>
/// Extension methods to perform Order By using strings
/// </summary>
/// <remarks>
/// See also
/// https://github.com/karenpayneoregon/ef-core-order-by
/// </remarks>
public static class QueryableExtensions
{
    public static IOrderedQueryable<T> OrderByColumn<T>(this IQueryable<T> source, string columnPath) 
        => source.OrderByColumnUsing(columnPath, "OrderBy");

    public static IOrderedQueryable<T> OrderByColumnDescending<T>(this IQueryable<T> source, string columnPath) 
        => source.OrderByColumnUsing(columnPath, "OrderByDescending");

    public static IOrderedQueryable<T> ThenByColumn<T>(this IOrderedQueryable<T> source, string columnPath) 
        => source.OrderByColumnUsing(columnPath, "ThenBy");

    public static IOrderedQueryable<T> ThenByColumnDescending<T>(this IOrderedQueryable<T> source, string columnPath) 
        => source.OrderByColumnUsing(columnPath, "ThenByDescending");

    private static IOrderedQueryable<T> OrderByColumnUsing<T>(this IQueryable<T> source, string columnPath, string method)
    {
        var parameter = Expression.Parameter(typeof(T), "item");
        var member = columnPath.Split('.')
            .Aggregate((Expression)parameter, Expression.PropertyOrField);
        var keySelector = Expression.Lambda(member, parameter);
        var methodCall = Expression.Call(typeof(Queryable), method, new[] 
                { parameter.Type, member.Type },
            source.Expression, Expression.Quote(keySelector));

        return (IOrderedQueryable<T>)source.Provider.CreateQuery(methodCall);
    }
}
