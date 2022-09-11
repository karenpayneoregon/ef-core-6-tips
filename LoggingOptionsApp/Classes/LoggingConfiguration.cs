using Microsoft.Extensions.Configuration;
using EntityFrameworkCoreHelpers.Models;
using ExtensionsLibrary;
using LoggingOptionsApp.Models;

namespace LoggingOptionsApp.Classes;

/// <summary>
/// Provides access to appsettings.json
/// </summary>
internal class LoggingConfiguration
{
    /// <summary>
    /// Read a specific section
    /// </summary>
    /// <typeparam name="T">model</typeparam>
    /// <param name="section">section to get information</param>
    /// <returns>section strong typed</returns>
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

