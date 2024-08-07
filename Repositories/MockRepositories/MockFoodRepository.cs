using CafeteriaWebsite.Enums;
using CafeteriaWebsite.Models;
using CafeteriaWebsite.Repositories.Interfaces;
using CafeteriaWebsite.Repositories.MockRepositories;

namespace CafeteriaWebsite.Repositories
{
	public class MockFoodRepository : IFood
	{
		private static readonly ICategory _categoryRepository = new MockCategoryRepository();

		private List<FoodModel> _food = new List<FoodModel>()
		{
			new FoodModel
			{
				Id = 1, Name = "Food1", Description = "Food description 1", ImageUrl = null,
				CategoryId = 1, Category = _categoryRepository.GetById(1), Tags = new List<int>{(int)FoodTag.VegetarianOption }
			},
			new FoodModel
			{
				Id = 2, Name = "Food2", Description = "Food description 2", ImageUrl = null,
				CategoryId = 2, Category = _categoryRepository.GetById(2), Tags = new List<int>{(int)FoodTag.New }
			},
			new FoodModel
			{
				Id = 3, Name = "Food3", Description = "Food description 3", ImageUrl = null,
				CategoryId = 2, Category = _categoryRepository.GetById(2), Tags = null
			},
			new FoodModel
			{
				Id = 4, Name = "Food4", Description = "Food description 4", ImageUrl = null,
				CategoryId = 3, Category = _categoryRepository.GetById(3), Tags = null
			}
		};

		public List<FoodModel> GetAll()
		{
			return _food;
		}

		public FoodModel GetById(int id)
		{
			return _food.Find(item => item.Id == id);
		}

		public List<FoodModel> GetByCategoryId(int id)
		{
			return _food.Where(item => item.CategoryId == id).ToList();
		}
		
	}
}
