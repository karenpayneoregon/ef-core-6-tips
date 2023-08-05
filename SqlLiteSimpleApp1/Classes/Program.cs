using SqlLiteSimpleApp1.Classes;
using SqlLiteSimpleApp1.Models;
using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace SqlLiteSimpleApp1;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "Code sample";
        SetupLogging.Development(true);
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }
    // there are for dynamic sorting in Main
    private static OrderColumn _firstNameOrdering = PersonOrderColumns.List()
        .FirstOrDefault(o => o.PropertyName == PersonPropertyName.FirstName);

    private static OrderColumn _lastNameOrdering = PersonOrderColumns.List()
        .FirstOrDefault(o => o.PropertyName == PersonPropertyName.LastName);
}
