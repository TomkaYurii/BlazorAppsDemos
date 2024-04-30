
using EX_02_DI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

//конфігруруємо хост
IHostBuilder CreateHostBuilder() =>
    Host.CreateDefaultBuilder()
        .ConfigureServices((hostcontext, services) =>
            services.AddTransient<ITransientGetCreatedTime, GetCreatedTimeImplementation>()
                    .AddScoped<IScopedGetCreatedTime, GetCreatedTimeImplementation>()
                    .AddSingleton<ISingletonGetCreatedTime, GetCreatedTimeImplementation>()
                    .AddTransient<GetCreatedTimeInvoker>());
//білдимо хост
using IHost host = CreateHostBuilder().Build();

//Створюэмо скоупи
ExecuteScope(host.Services, "sample-scope-1");
ExecuteScope(host.Services, "sample-scope-2");

static void ExecuteScope(IServiceProvider services, string scope)
{
    using IServiceScope serviceScope = services.CreateScope();
    IServiceProvider provider = serviceScope.ServiceProvider;

    Console.WriteLine("===================================================");
    Console.WriteLine($"Scope Name: {scope}");
    Console.WriteLine("===================================================");
    Console.WriteLine($"First Call.... -->>");
    GetCreatedTimeInvoker invoker = provider.GetRequiredService<GetCreatedTimeInvoker>();
    invoker.Invoke();

    Console.WriteLine("...");
    Console.WriteLine($"Second Call.... -->>");
    invoker = provider.GetRequiredService<GetCreatedTimeInvoker>();
    invoker.Invoke();

    Console.WriteLine("===================================================");
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine();
}