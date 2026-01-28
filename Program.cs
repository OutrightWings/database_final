using Database.Components;
using MySqlConnector;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
builder.Services.AddTransient(_ =>
{
    var connStr = builder.Configuration.GetConnectionString("DefaultConnection");
    return new MySqlConnection(connStr);
});
// builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
// builder.Services.AddAuthentication(options =>
// {
//     options.DefaultAuthenticateScheme = null;
//     options.DefaultChallengeScheme = null;
// });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();
app.UseAuthorization();
app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
