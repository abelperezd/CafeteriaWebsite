using CafeteriaWebsite.CafeteriaDbContext;
using CafeteriaWebsite.Repositories;
using CafeteriaWebsite.Repositories.Interfaces;
using CafeteriaWebsite.Repositories.MockRepositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddDbContext<CafeteriaDbContext>(options => options.UseSqlServer("name=CafeteriaDbContextConnection"));

builder.Services.AddTransient<IFoodRepository, MockFoodRepository>();
builder.Services.AddTransient<ICategoryRepository, MockCategoryRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Home}/{id?}");

app.Run();
