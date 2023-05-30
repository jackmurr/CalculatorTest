using Calculator.Core.Services;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);


var services = builder.Services;

// DI
services.AddScoped<ISimpleCalculator, CalculatorService>();

// Add services to the container.

services.AddControllersWithViews();
services.AddCors(options => // add a policyu for the angular port
{
    options.AddPolicy("LocalPolicy", builder =>
    {
        builder.WithOrigins("https://localhost:44426").AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// cors sucks


app.UseCors("LocalPolicy");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
