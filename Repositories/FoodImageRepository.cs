using CafeteriaWebsite.AppDbContext;
using CafeteriaWebsite.Models;
using CafeteriaWebsite.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CafeteriaWebsite.Repositories
{
	public class FoodImageRepository : IFoodImageRepository
	{
		private readonly CafeteriaDbContext _context;

		public FoodImageRepository(CafeteriaDbContext context) {
			_context = context;
		}

		public async Task<int> Create([Bind(new[] { "ImageData", "FileExtension" })] FoodImageModel image)
		{
			if (image.ImageData.Length < 5)
				return -1;

			_context.FoodImage.Add(image);
			await _context.SaveChangesAsync();

			return image.Id;
		}

		public async Task Delete(int id)
		{
			FoodImageModel dbImg = await _context.FoodImage.SingleOrDefaultAsync(n => n.Id == id);

			if (dbImg != null)
			{
				_context.FoodImage.Remove(dbImg);
				await _context.SaveChangesAsync();
			}
		}

		public async Task<FoodImageModel> GetById(int id)
		{
			return await _context.FoodImage.SingleOrDefaultAsync(item => item.Id == id);
		}
	}
}
