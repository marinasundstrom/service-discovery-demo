using BlazorApp.Components;

using Steeltoe.Common.Http.Discovery;
using Steeltoe.Discovery.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


builder.Services.AddDiscoveryClient();

// Any hardcoded URL is for demonstration purposes only. Please put them in appsettings.json!

builder.Services
    .AddHttpClient("WebApi1", (httpClient) => httpClient.BaseAddress = new Uri("http://webapi1"))
    .AddServiceDiscovery();

builder.Services
    .AddHttpClient("WebApi2", (httpClient) => httpClient.BaseAddress = new Uri("http://webapi2"))
    .AddServiceDiscovery();

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

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
