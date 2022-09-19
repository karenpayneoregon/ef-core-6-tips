using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using DbContextPooling.Data;

namespace DbContextPooling.Classes
{
    public class Startup
    {
        private const string ConnectionString
            = @"Server=(localdb)\mssqllocaldb;Database=Demo.ContextPooling;Trusted_Connection=True";

        public void ConfigureServices(IServiceCollection services)
        {

            // Switch the lines below to compare pooling with the traditional instance-per-request approach.
            //services.AddDbContext<BloggingContext>(c => c.UseSqlServer(ConnectionString));
            //services.AddDbContextPool<BloggingContext>(c => c.UseSqlServer(ConnectionString));

            // for allowing pause while tweaking raw data
            services.AddDbContextPool<BloggingContext>(options => options.UseSqlServer(
                ConnectionString,
                sqlServerOptions => sqlServerOptions.CommandTimeout(60))
            );
        }
    }
}
