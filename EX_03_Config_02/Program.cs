using EX_03_Config_02;
using Microsoft.Extensions.Configuration;


var environment = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");

IConfigurationBuilder builder = new ConfigurationBuilder()
    .AddJsonFile($"appsettings.json", true, true)
    .AddJsonFile($"appsettings.{environment}.json", true, true)
    .AddEnvironmentVariables();

IConfigurationRoot configurationRoot = builder.Build();

var appConfig = configurationRoot.GetSection(nameof(AppConfig)).Get<AppConfig>();

Console.WriteLine(appConfig.Environment);
