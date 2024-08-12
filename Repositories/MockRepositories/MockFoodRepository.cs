using CafeteriaWebsite.Enums;
using CafeteriaWebsite.Models;
using CafeteriaWebsite.Repositories.Interfaces;
using CafeteriaWebsite.Repositories.MockRepositories;
using Microsoft.AspNetCore.Mvc;

namespace CafeteriaWebsite.Repositories
{
	public class MockFoodRepository : IFoodRepository
	{
		private static readonly ICategoryRepository _categoryRepository = new MockCategoryRepository();

		private List<FoodModel> _food = new List<FoodModel>()
		{
			new FoodModel
			{
				Id = 1, Name = "Food1", Description = "Food description 1", FoodImageId = null,
				CategoryId = 1, Category = _categoryRepository.GetByIdNotAsync(1), Tags = new List<int>{(int)FoodTag.Vegan }
			},
			new FoodModel
			{
				Id = 2, Name = "Food2", Description = "Food description 2", FoodImageId = null,
				CategoryId = 2, Category = _categoryRepository.GetByIdNotAsync(2), Tags = new List<int>{(int)FoodTag.New }
			},
			new FoodModel
			{
				Id = 3, Name = "Food3", Description = "Food description 3", FoodImageId = null,
				CategoryId = 2, Category = _categoryRepository.GetByIdNotAsync(2), Tags = null
			},
			new FoodModel
			{
				Id = 4, Name = "Food4", Description = "Food description 4", FoodImageId = null,
				CategoryId = 3, Category = _categoryRepository.GetByIdNotAsync(3), Tags = null
			}
		};

		public List<FoodModel> GetAll()
		{
			return _food;
		}

		public Task<int> Create([Bind(new[] { "Name", "CategoryId" })] FoodModel category)
		{
			throw new NotImplementedException();
		}

		public Task Delete(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<FoodModel> GetById(int id)
		{
			return _food.Find(item => item.Id == id);
		}

		public async Task<List<FoodModel>> GetByCategoryId(int id)
		{
			return _food.Where(item => item.CategoryId == id).ToList();
		}
	}
}
