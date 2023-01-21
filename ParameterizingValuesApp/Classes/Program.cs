using System.Runtime.CompilerServices;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;

// ReSharper disable once CheckNamespace
namespace ParameterizingValuesApp;

internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            //.WriteTo.Console(theme: AnsiConsoleTheme.Code)
            .WriteTo.File(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogFiles", "EF-Log.txt"),
                rollingInterval: RollingInterval.Day,
                outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level}] {Message}{NewLine}{Exception}")
            .CreateLogger();

        Log.Information("Created logger");

        Console.Title = "Code sample";
        Console.SetWindowSize(Console.WindowWidth, Console.WindowHeight + 25);
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }
}