using BlazorAppDemo_01.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()   //рендеринг компонентів не сервері
    .AddInteractiveServerComponents();  //інтерактивний рендеринг компонентів не сервері:

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()               // кореневий компонент застосунку (за замовчуванням це компонент App з файлу App.razor)
    .AddInteractiveServerRenderMode();      // налаштовує режим інтерактивного рендерингу на стороні сервера

app.Run();
