using Microsoft.Extensions.Configuration;
using EntityFrameworkCoreHelpers.Models;
using ExtensionsLibrary;
using LoggingOptionsApp.Models;

namespace LoggingOptionsApp.Classes;

internal class LoggingConfiguration
{
    private static IConfigurationRoot InitMainConfiguration() =>
        new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json").Build();

    public static T InitOptions<T>(string section) where T : new() 
        => InitMainConfiguration().GetSection(section).Get<T>();

    public static LoggingOptions LoggingOptions() 
        =>  InitOptions<Logging>("Logging").LogLevel.Type.GetValueFromEnumMember<LoggingOptions>();
}

