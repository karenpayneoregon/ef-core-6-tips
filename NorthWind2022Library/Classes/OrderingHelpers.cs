using System.Linq.Expressions;
using NorthWind2022Library.Models;

namespace NorthWind2022Library.Classes;

/// <summary>
/// Specifies the sort direction against a property
/// </summary>
public enum Direction
{
    /// <summary>
    /// Sort ascending.
    /// </summary>
    Ascending,
    /// <summary>
    /// Sort descending.
    /// </summary>
    Descending
}
public static class OrderingHelpers
{
    /// <summary>
    /// Provides sorting by string using a key specified in <see cref="name"/> and if the key is not found the default is <see cref="Customers.CompanyName"/>
    /// </summary>
    /// <param name="query"><see cref="Customers"/> query</param>
    /// <param name="name">key to sort by</param>
    /// <param name="direction">direction to sort by</param>
    /// <returns>query with order by</returns>
    public static IQueryable<Customers> OrderByString(this IQueryable<Customers> query, 
        string name, Direction direction = Direction.Ascending)
    {
        Expression<Func<Customers, object>> exp = name switch
        {
            "LastName" => customer => customer.Contact.LastName,
            "FirstName" => customer => customer.Contact.FirstName,
            "CountryName" => customer => customer.CountryNavigation.Name,
            _ => customer => customer.CompanyName
        };

        return direction == Direction.Ascending ? query.OrderBy(exp) : query.OrderByDescending(exp);
    }

    /// <summary>
    /// Provides sorting by string using a key specified in <see cref="name"/> and if the key is not found the default is <see cref="Contacts.LastName"/>
    /// </summary>
    /// <param name="query"><see cref="Contacts"/> query</param>
    /// <param name="name">key to sort by</param>
    /// <param name="direction">direction to sort by</param>
    /// <returns>query with order by</returns>
    public static IQueryable<Contacts> OrderByString(this IQueryable<Contacts> query, string name, Direction direction = Direction.Ascending)
    {
        Expression<Func<Contacts, object>> exp = name switch
        {
            "LastName" => contact => contact.LastName,
            "FirstName" => contact => contact.FirstName,
            "Title" => contact => contact.ContactTypeNavigation.ContactTitle,
            _ => x => x.LastName
        };

        return direction == Direction.Ascending ? query.OrderBy(exp) : query.OrderByDescending(exp);
    }
}