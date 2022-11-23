using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Validators;
using NorthWind2020ConsoleAppCore7.Classes;

namespace NorthWind2020ConsoleAppCore7
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            var config = new ManualConfig()
                .WithOptions(ConfigOptions.DisableOptimizationsValidator)
                .AddValidator(JitOptimizationsValidator.DontFailOnError)
                .AddLogger(ConsoleLogger.Default)
                .AddColumnProvider(DefaultColumnProviders.Instance);

            BenchmarkRunner.Run<CoreOperations>(config);

            Console.WriteLine("DONE");
            Console.ReadLine();
        }
    }
}