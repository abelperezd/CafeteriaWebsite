using CafeteriaWebsite.AppDbContext;
using CafeteriaWebsite.Models;
using CafeteriaWebsite.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CafeteriaWebsite.Repositories
{
	public class FoodRepository : IFoodRepository
	{
		private readonly CafeteriaDbContext _context;

		public FoodRepository(CafeteriaDbContext context) {
			_context = context;
		}
		public async Task<int> Create([Bind(new[] { "Name", "CategoryId" })] FoodModel food)
		{
			FoodModel? itemFound = _context.Food.FirstOrDefault(item => item.Name == food.Name);
			if (itemFound != null)
				return itemFound.Id;

			_context.Food.Add(food);
			await _context.SaveChangesAsync();

			return food.Id;
		}

		public async Task Delete(int id)
		{
			FoodModel dbFood = await _context.Food.SingleOrDefaultAsync(n => n.Id == id);

			if (dbFood != null)
			{
				_context.Food.Remove(dbFood);
				await _context.SaveChangesAsync();
			}

		}

		public async Task<List<FoodModel>> GetByCategoryId(int id)
		{
			return _context.Food.Where(item => item.CategoryId == id).ToList();
		}

		public async Task<FoodModel> GetById(int id)
		{
			return await _context.Food.SingleOrDefaultAsync(item => item.Id == id);
		}
	}
}
