using BlazorBootcamp.Server.Data;
using BlazorBootcamp.DataAccess;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.SqlServer.Server;
using BlazorBootcamp.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using BlazorBootcamp.Business.Repository;
using System.Collections.Concurrent;
using BlazorBootcamp.Server.Service;
using Syncfusion.Blazor;

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mjc5MzgzNkAzMjMzMmUzMDJlMzBoSnlrWS9vNFlPcXlWNjFibFE1citEZHVkbDQva0M1VnVQRkl4NTNLNkZZPQ==");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddSyncfusionBlazor();

builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IFileUpload, FileUpload>();


builder.Services.AddDbContext<DataContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
