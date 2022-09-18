﻿using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Core;

namespace TaxpayersConcurrencyCheck.Classes;

public sealed class SeriControl
{
    private static readonly Lazy<SeriControl> Lazy = new(() => new SeriControl());
    public static SeriControl Instance => Lazy.Value;


#pragma warning disable CS8618
    private static Logger _logger;
#pragma warning restore CS8618
    public Logger Logger => _logger;
    private SeriControl()
    {
        // setup to read setting from Serilog.json
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("Serilog.json", true, true)
            .Build();

        _logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .MinimumLevel.Information()
            .CreateLogger();

    }
}