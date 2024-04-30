using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<FactoryMiddleware>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// 01. Adding Middleware With Request Delegates
app.Use(async (context, next) =>
        {
            // Add code before request.
            ILogger<Program> logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
            logger.LogInformation("Logging before executing next middleware...");
            await next(context);
            logger.LogInformation("Logging after executing next middleware...");
            // Add code after request.
        });

        // 02. Adding Middleware By Convention
        app.UseMiddleware<ConventionMiddleware>();

        // 03. Adding Factory-Based Middleware
        app.UseMiddleware<FactoryMiddleware>();


app.Run();


        public class ConventionMiddleware(RequestDelegate next,
            ILogger<ConventionMiddleware> logger)
        {
            public async Task InvokeAsync(HttpContext context)
            {
                logger.LogInformation("ConventionMiddleware. Before request");
                await next(context);
                logger.LogInformation("ConventionMiddleware. After request");
            }
        }

        public class FactoryMiddleware(ILogger<FactoryMiddleware> logger) : IMiddleware
        {
            public async Task InvokeAsync(HttpContext context, RequestDelegate next)
            {
                logger.LogInformation("FactoryMiddleware. Before request");

                await next(context);

                logger.LogInformation("FactoryMiddleware. After request");
            }
        }
