using DbContextPooling.Classes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace DbContextPooling
{
    internal partial class Program
    {
        [ModuleInitializer]
        public static void Init()
        {
            AnsiConsole.MarkupLine("");
            Console.Title = "Code sample";
            WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
        }

        private static void SetupDatabase(IServiceProvider serviceProvider)
        {
            using var serviceScope = serviceProvider.CreateScope();
            var context = serviceScope.ServiceProvider.GetService<BloggingContext>();

            if (context!.Database.EnsureCreated())
            {
                context.Blogs.Add(new Blog { Name = "The Dog Blog", Url = "http://sample.com/dogs" });
                context.Blogs.Add(new Blog { Name = "The Cat Blog", Url = "http://sample.com/cats" });
                context.SaveChanges();
            }
        }
    }
}
