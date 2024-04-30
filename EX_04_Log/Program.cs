using EX_04_Log;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

IHostBuilder CreateHostBuilder() =>
            Host.CreateDefaultBuilder()
            .ConfigureServices((_, services) =>
            {
                services.AddTransient<Worker>();
            })
            .ConfigureLogging((_, logging) =>
            {
                logging.ClearProviders();
                logging.AddSimpleConsole(options => options.IncludeScopes = true);
                logging.AddEventLog();
            });

var host = CreateHostBuilder().Build();
var workerInstance = host.Services.GetRequiredService<Worker>();

workerInstance.Execute();