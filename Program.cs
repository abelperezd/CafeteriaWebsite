using CafeteriaWebsite.AppDbContext;
using CafeteriaWebsite.Repositories;
using CafeteriaWebsite.Repositories.Interfaces;
using CafeteriaWebsite.Repositories.MockRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("CafeteriaDbContextConnectionPublished") ?? throw new InvalidOperationException("Connection string 'CafeteriaDbContextConnection' not found.");

//To allow the login pages
builder.Services.AddRazorPages(); // Add Razor Pages

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<CafeteriaDbContext>(options => options.UseSqlServer("name=CafeteriaDbContextConnectionPublished"));

//builder.Services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<CafeteriaDbContext>();

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
	.AddEntityFrameworkStores<CafeteriaDbContext>()
	.AddDefaultTokenProviders();

builder.Services.AddTransient<IFoodRepository, MockFoodRepository>();
builder.Services.AddTransient<ICategoryRepository, MockCategoryRepository>();
//builder.Services.AddTransient<IFoodImageRepository, FoodImageRepository>();

//builder.Services.AddDbContext<CafeteriaDbContext>(options => options.UseSqlServer("name=CafeteriaDbContextConnection"));

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

//To allow the user to have persistence during its session

app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Home}/{id?}");


//enables razor pages model
app.MapRazorPages();

/*
using (var scope = app.Services.CreateScope())
{
	var services = scope.ServiceProvider;
	var context = services.GetRequiredService<CafeteriaDbContext>();
	context.Database.Migrate(); // Apply any pending migrations

	await SeedAdminUser(services);
}
*/

app.Run();

async Task SeedAdminUser(IServiceProvider serviceProvider)
{
	return;
	var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
	var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

	//saved in credentials
	string adminEmail = "";
	string adminPassword = "";
	string adminRole = "Admin";

	// Ensure the admin role exists
	if (!await roleManager.RoleExistsAsync(adminRole))
	{
		await roleManager.CreateAsync(new IdentityRole(adminRole));
	}

	// Ensure the admin user exists
	var adminUser = await userManager.FindByEmailAsync(adminEmail);
	if (adminUser == null)
	{
		adminUser = new IdentityUser { UserName = adminEmail, Email = adminEmail };
		var result = await userManager.CreateAsync(adminUser, adminPassword);

		if (result.Succeeded)
		{
			await userManager.AddToRoleAsync(adminUser, adminRole);
		}
	}
	else
	{
		// Fetch roles for the existing user
		var roles = await userManager.GetRolesAsync(adminUser);

		// Check if the user already has the "Admin" role
		if (!roles.Contains(adminRole))
		{
			await userManager.AddToRoleAsync(adminUser, adminRole);
		}
	}
}