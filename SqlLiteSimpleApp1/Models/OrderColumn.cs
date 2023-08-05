#pragma warning disable CS8618

namespace SqlLiteSimpleApp1.Models;
public class OrderColumn
{
    /// <summary>
    /// Property name for ordering
    /// </summary>
    public PersonPropertyName PropertyName { get; set; }
    /// <summary>
    /// Column name to use for ordering which can contain a dot for navigations
    /// </summary>
    public string Column { get; set; }
    public override string ToString() => PropertyName.ToString();

}