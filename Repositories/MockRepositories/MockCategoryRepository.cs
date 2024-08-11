using CafeteriaWebsite.Models;
using CafeteriaWebsite.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CafeteriaWebsite.Repositories.MockRepositories
{
	public class MockCategoryRepository : ICategoryRepository
	{
		private List<CategoryModel> _categories = new List<CategoryModel>()
		{
			new CategoryModel()
			{
				Id= 1,
				Name = "Category 1",
				Description = "Description 1"
			},
			new CategoryModel()
			{
				Id= 2,
				Name = "Category 2",
				Description = "Description 2"
			},
			new CategoryModel()
			{
				Id= 3,
				Name = "Category 3",
				Description = null
			}
		};

		public Task<int> Create([Bind(new[] { "Name" })] CategoryModel category)
		{
			throw new NotImplementedException();
		}

		public Task Delete(int id)
		{
			throw new NotImplementedException();
		}


		public async Task<List<CategoryModel>> GetAll()
		{
			return _categories;
		}

		public async Task<CategoryModel> GetById(int id)
		{
			return _categories.Find(item => item.Id == id);
		}

		public CategoryModel GetByIdNotAsync(int id)
		{
			return _categories.Find(item => item.Id == id);
		}
	}
}
