using System.Runtime.CompilerServices;
using static ConsoleHelperLibrary.Classes.WindowUtility;

// ReSharper disable once CheckNamespace
namespace NorthWindContactsApp;

internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "Code sample";
        SetConsoleWindowPosition(AnchorWindow.Center);
        Console.WriteLine();
    }
}