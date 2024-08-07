using CafeteriaWebsite.Models;
using CafeteriaWebsite.Repositories.Interfaces;

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

		public List<CategoryModel> GetAll()
		{
			return _categories;
		}

		public CategoryModel GetById(int id)
		{
			return _categories.Find(item => item.Id == id);
		}
	}
}
