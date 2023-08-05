namespace SqlLiteSimpleApp1.Models;


public class PersonOrderColumns
{
    public static List<OrderColumn> List() =>
        new()
        {
            new() { PropertyName = PersonPropertyName.FirstName, Column = "FirstName" },
            new() { PropertyName = PersonPropertyName.LastName, Column = "LastName" },
        };
}