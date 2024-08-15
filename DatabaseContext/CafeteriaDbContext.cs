using CafeteriaWebsite.Enums;
using CafeteriaWebsite.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CafeteriaWebsite.AppDbContext
{
	public class CafeteriaDbContext : IdentityDbContext
	{
		public CafeteriaDbContext(DbContextOptions<CafeteriaDbContext> options) : base(options)
		{
		}

		public DbSet<FoodModel> Food => Set<FoodModel>();
		public DbSet<CategoryModel> Category => Set<CategoryModel>();
		public DbSet<FoodImageModel> FoodImage => Set<FoodImageModel>();

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Configure the one-to-one between food and foodImage
			modelBuilder.Entity<FoodModel>()
				.HasOne(f => f.Image) // FoodModel has one FoodImageModel
				.WithOne() // FoodImageModel does not have a navigation property back to FoodModel
				.HasForeignKey<FoodModel>(f => f.FoodImageId) // Foreign key in FoodModel
				.OnDelete(DeleteBehavior.Cascade); // Configure cascading delete

			base.OnModelCreating(modelBuilder);

			SeedData(modelBuilder);
		}

		private static void SeedData(ModelBuilder builder)
		{
			//SeedCafeteriaData(builder);
		}

		private static void SeedCafeteriaData(ModelBuilder builder)
		{
			builder.Entity<CategoryModel>().HasData(
				new CategoryModel()
				{
					Id = 1,
					Name = "Category 1",
					Description = "Description 1"
				},
				new CategoryModel()
				{
					Id = 2,
					Name = "Category 2",
					Description = "Description 2"
				},
				new CategoryModel()
				{
					Id = 3,
					Name = "Category 3",
					Description = null
				}
			);

			builder.Entity<FoodModel>().HasData(
				new FoodModel
				{
					Id = 1,
					Name = "Food1",
					Description = "Food description 1",
					FoodImageId = null,
					CategoryId = 1,
					Tags = new List<int> { (int)FoodTag.Vegan }
				},
				new FoodModel
				{
					Id = 2,
					Name = "Food2",
					Description = "Food description 2",
					FoodImageId = null,
					CategoryId = 2,
					Tags = new List<int> { (int)FoodTag.New }
				},
				new FoodModel
				{
					Id = 3,
					Name = "Food3",
					Description = "Food description 3",
					FoodImageId = null,
					CategoryId = 2,
					Tags = null
				},
				new FoodModel
				{
					Id = 4,
					Name = "Food4",
					Description = "Food description 4",
					FoodImageId = null,
					CategoryId = 3,
					Tags = null
				}
			);
		}

	}
}
