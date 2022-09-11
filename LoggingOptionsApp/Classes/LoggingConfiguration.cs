using Microsoft.Extensions.Configuration;
using EntityFrameworkCoreHelpers.Models;
using ExtensionsLibrary;
using LoggingOptionsApp.Models;

namespace LoggingOptionsApp.Classes;

internal class LoggingConfiguration
{

    private static T InitOptions<T>(string section) where T : new() 
        => new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build()
            .GetSection(section)
            .Get<T>();

    /// <summary>
    /// Get <see cref="LoggingOptions"/> for EF Core 
    /// </summary>
    /// <returns></returns>
    public static LoggingOptions LoggingOptions()
        => InitOptions<EntityFrameWorkLogging>("EntityFrameWorkLogging")
            .Type.GetValueFromEnumMember<LoggingOptions>();
}

