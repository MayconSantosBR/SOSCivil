using Microsoft.Extensions.Configuration;
using System;

public class AppConfig
{
    private readonly IConfiguration _configuration;

    public AppConfig()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory) // Set the base path to your application's directory.
            .AddJsonFile("appsettings.json"); // Specify the name of your JSON configuration file.

        _configuration = builder.Build();
    }

    public string GetSetting(string key)
    {
        return _configuration[key];
    }
}