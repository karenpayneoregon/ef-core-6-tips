using System.Runtime.CompilerServices;
using ConsoleHelperLibrary.Classes;
using NorthWind2020ConsoleApp.Classes;


namespace NorthWind2020ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        CoreOperations.EmployeeReportsToManager();
        Console.ReadLine();
    }

    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "Code sample - EF Core NorthWind 2022";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }
}