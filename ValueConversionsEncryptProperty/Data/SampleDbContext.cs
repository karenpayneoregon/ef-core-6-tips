using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ValueConversionsEncryptProperty.Models;

using static ConfigurationLibrary.Classes.ConfigurationHelper;
using static ValueConversionsEncryptProperty.Classes.SecurityHelpers;

namespace ValueConversionsEncryptProperty.Data
{
    public class SampleDbContext : DbContext
    {
        //public DbSet<User> User { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region ConfigureEncryptPropertyValues
            modelBuilder.Entity<User>().Property(e => e.Password).HasConversion(
                v => EncryptString(v),
                v => DecryptString(v));
            #endregion
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .LogTo(message => Debug.WriteLine(message),
                    new[] { RelationalEventId.CommandExecuted },
                    LogLevel.Information,
                    DbContextLoggerOptions.UtcTime)
                .UseSqlServer(ConnectionString())
                .EnableSensitiveDataLogging();
    }
}
