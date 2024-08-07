using CafeteriaWebsite.Models;
using CafeteriaWebsite.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CafeteriaWebsite.Controllers
{
	public class CategoryController : Controller
	{
		private readonly ICategoryRepository _categoryRepository;
		private readonly IFoodRepository _foodRepository;

		public CategoryController(ICategoryRepository categoryRepository, IFoodRepository foodRepository)
		{
			_categoryRepository = categoryRepository;
			_foodRepository = foodRepository;
		}
		public IActionResult Menu(int categoryId)
		{
			CategoryModel category = _categoryRepository.GetById(categoryId);

			if(category == null)
			{
				//TODO: show not found error
				
			}

			List<FoodModel> food = _foodRepository.GetByCategoryId(categoryId);
			
			if(food.Count == 0)
			{
				//TODO: show not found error

			}

			CategoryDto dto = new CategoryDto(category, food);

			return View(dto);
		}
	}
}
