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
				Name = "Sandwiches and Toasts",
				Description = "Enjoy our gourmet sandwiches and toasts, crafted with fresh ingredients and perfectly balanced flavors in every bite."
			},
			new CategoryModel()
			{
				Id= 2,
				Name = "Pancakes",
				Description = "Indulge in our fluffy pancakes, made from scratch and served warm with your choice of sweet or savory toppings. "
			},
			new CategoryModel()
			{
				Id= 3,
				Name = "Cakes",
				Description = "Whether you prefer classic or creative, our cakes are baked to perfection and sure to satisfy your sweet tooth."
			},
			new CategoryModel()
			{
				Id= 4,
				Name = "Snacks",
				Description = "Explore our tasty snack selection, offering a variety of quick bites that are perfect for satisfying your cravings."
			},
			new CategoryModel()
			{
				Id= 5,
				Name = "Drinks",
				Description = "Whether you're in the mood for something fruity, fizzy, or smooth, we have the perfect drink to quench your thirst."
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

		public Task Update(UpdateCategoryDto dto)
		{
			throw new NotImplementedException();
		}
	}
}
