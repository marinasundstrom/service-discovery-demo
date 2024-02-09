using BlazorApp.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient("WebApi1", (httpClient) => httpClient.BaseAddress = new Uri("http://localhost:5137"));

#region V1.2
//builder.Services.AddHttpClient("WebApi2", (httpClient) => httpClient.BaseAddress = new Uri(builder.Configuration["WebApi1"]!));
# endregion

#region V2
//builder.Services.AddHttpClient("WebApi1", (httpClient) => httpClient.BaseAddress = new Uri(builder.Configuration["WebApi1"]!));
//builder.Services.AddHttpClient("WebApi2", (httpClient) => httpClient.BaseAddress = new Uri(builder.Configuration["WebApi2"]!));
#endregion

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
