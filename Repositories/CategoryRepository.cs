using CafeteriaWebsite.AppDbContext;
using CafeteriaWebsite.Models;
using CafeteriaWebsite.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CafeteriaWebsite.Repositories
{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly CafeteriaDbContext _context;

		public CategoryRepository(CafeteriaDbContext context) {
			_context = context;
		}

		public async Task<int> Create([Bind(new[] { "Name" })] CategoryModel category)
		{
			CategoryModel? itemFound = _context.Category.FirstOrDefault(item => item.Name == category.Name);
			if (itemFound != null)
				return itemFound.Id;

			_context.Category.Add(category);
			await _context.SaveChangesAsync();

			return category.Id;
		}

		public async Task Delete(int id)
		{
			CategoryModel dbCat = await _context.Category.SingleOrDefaultAsync(n => n.Id == id);

			if (dbCat != null)
			{
				_context.Category.Remove(dbCat);
				await _context.SaveChangesAsync();
			}
		}

		public async Task<List<CategoryModel>> GetAll()
		{
			return await _context.Category.ToListAsync();
		}

		public async Task<CategoryModel> GetById(int id)
		{
			return await _context.Category.SingleOrDefaultAsync(item => item.Id == id);

		}

		public CategoryModel GetByIdNotAsync(int id)
		{
			return null;
		}
	}
}
