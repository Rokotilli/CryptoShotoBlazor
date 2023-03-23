using Client.Controllers;
using Client.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddAuthentication("Cookies").AddCookie();
builder.Services.AddAuthorization();
builder.Services.AddHttpClient<NewsService>(httpClient =>
{
    httpClient.BaseAddress = new Uri(builder.Configuration["ApiUrl"]);
});

builder.Services.AddHttpClient<PostService>(httpClient =>
{
    httpClient.BaseAddress = new Uri(builder.Configuration["ApiUrl"]);
});

builder.Services.AddHttpClient<IdentityService>(httpClient =>
{
    httpClient.BaseAddress = new Uri(builder.Configuration["ApiUrl"]);
});

builder.Services.AddHttpClient<WalletService>(httpClient =>
{
    httpClient.BaseAddress = new Uri(builder.Configuration["ApiUrl"]);
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");

    app.UseHsts();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
