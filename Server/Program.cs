using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "CookieSchema";
}).AddCookie("CookieSchema");

var app = builder.Build();

app.UseRouting();
app.UseAuthentication();

app.MapGet("/", (HttpContext context) => context.User.Claims.FirstOrDefault(c => c.Type == "Name")?.Value);

app.MapGet("/login", async (HttpContext context) =>
{
    var user = new ClaimsPrincipal(
    [new ClaimsIdentity([
            new Claim("Name", "Leonhard")
    ], "CookieSchema")]);
    await context.SignInAsync(user);
});

app.Run();