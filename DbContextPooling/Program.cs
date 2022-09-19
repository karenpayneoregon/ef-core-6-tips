using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using DbContextPooling.Classes;

namespace DbContextPooling
{
    internal partial class Program
    {
        private const int Threads = 32;
        private const int Seconds = 5;

        private static long _requestsProcessed;

        private static async Task Main()
        {
            var serviceCollection = new ServiceCollection();
            new Startup().ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            SetupDatabase(serviceProvider);

            var stopwatch = new Stopwatch();

            var monitorTask = MonitorResults(TimeSpan.FromSeconds(Seconds), stopwatch);

            await Task.WhenAll(
                Enumerable
                    .Range(0, Threads)
                    .Select(_ => SimulateRequestsAsync(serviceProvider, stopwatch)));

            await monitorTask;

            AnsiConsole.MarkupLine("[white on blue]DONE[/]");
            Console.ReadLine();

        }


        private static async Task SimulateRequestsAsync(IServiceProvider serviceProvider, Stopwatch stopwatch)
        {
            while (stopwatch.IsRunning)
            {
                using (var serviceScope = serviceProvider.CreateScope())
                {
                    var blog = await new BlogController(serviceScope.ServiceProvider.GetService<BloggingContext>())
                        .GetBlogAsync();
                    //Console.WriteLine(blog.Name);
                }

                Interlocked.Increment(ref _requestsProcessed);
            }
        }


        private static async Task MonitorResults(TimeSpan duration, Stopwatch stopwatch)
        {
            var lastInstanceCount = 0L;
            var lastRequestCount = 0L;
            var lastElapsed = TimeSpan.Zero;

            stopwatch.Start();

            while (stopwatch.Elapsed < duration)
            {
                await Task.Delay(TimeSpan.FromSeconds(1));

                var instanceCount = BloggingContext.InstanceCount;
                var requestCount = _requestsProcessed;
                var elapsed = stopwatch.Elapsed;
                var currentElapsed = elapsed - lastElapsed;
                var currentRequests = requestCount - lastRequestCount;

                Console.WriteLine(
                    $"[{DateTime.Now:HH:mm:ss.fff}] "
                    + $"Context creations/second: {instanceCount - lastInstanceCount} | "
                    + $"Requests/second: {Math.Round(currentRequests / currentElapsed.TotalSeconds)}");

                lastInstanceCount = instanceCount;
                lastRequestCount = requestCount;
                lastElapsed = elapsed;
            }

            Console.WriteLine();
            Console.WriteLine($"Total context creations: {BloggingContext.InstanceCount}");
            Console.WriteLine($"Requests per second:     {Math.Round(_requestsProcessed / stopwatch.Elapsed.TotalSeconds)}");

            stopwatch.Stop();
        }

    }
}