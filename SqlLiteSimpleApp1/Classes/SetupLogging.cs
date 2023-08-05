using Serilog;
using Serilog.Core;
using Serilog.Events;
using static System.DateTime;

namespace SqlLiteSimpleApp1.Classes;

public class SetupLogging
{
    /// <summary>
    /// Setup logging
    /// </summary>
    /// <param name="log">true to log, false to not log</param>
    public static void Development(bool log)
    {

        if (log)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.File(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogFiles", $"{Now.Year}-{Now.Month}-{Now.Day}", "Log.txt"),
                    rollingInterval: RollingInterval.Infinite,
                    outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level}] {Message}{NewLine}{Exception}")
                .CreateLogger();
        }
        else
        {
            LoggingLevelSwitch ls = new() { MinimumLevel = ((LogEventLevel)1 + (int)LogEventLevel.Fatal) };

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .MinimumLevel.ControlledBy(ls)
                .WriteTo.File(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogFiles", $"{Now.Year}-{Now.Month}-{Now.Day}", "Log.txt"),
                    rollingInterval: RollingInterval.Infinite,
                    outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level}] {Message}{NewLine}{Exception}")
                .CreateLogger();
        }
    }
}