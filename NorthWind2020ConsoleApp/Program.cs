using System.Runtime.CompilerServices;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Validators;
using ConsoleHelperLibrary.Classes;
using NorthWind2020ConsoleApp.Classes;


namespace NorthWind2020ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        //config.WithOptions(ConfigOptions.DisableOptimizationsValidator)
        //CoreOperations.EmployeeReportsToManager();
        //BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);

        var config =  new ManualConfig()
            .WithOptions(ConfigOptions.DisableOptimizationsValidator)
            .AddValidator(JitOptimizationsValidator.DontFailOnError)
            .AddLogger(ConsoleLogger.Default)
            .AddColumnProvider(DefaultColumnProviders.Instance);

        BenchmarkRunner.Run<CoreOperations>(config);

        Console.WriteLine("DONE");
        Console.ReadLine();
    }

    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "Code sample - EF Core NorthWind 2022";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }
}