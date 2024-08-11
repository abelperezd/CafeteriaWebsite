using CafeteriaWebsite.Enums;
using CafeteriaWebsite.Models;
using CafeteriaWebsite.Repositories.Interfaces;
using CafeteriaWebsite.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace CafeteriaWebsite.Controllers
{
	public class CategoryController : Controller
	{
		private readonly ICategoryRepository _categoryRepository;
		private readonly IFoodRepository _foodRepository;
		private readonly IFoodImageRepository _foodImageRepository;

		public CategoryController(ICategoryRepository categoryRepository, IFoodRepository foodRepository, IFoodImageRepository foodImageRepository)
		{
			_categoryRepository = categoryRepository;
			_foodRepository = foodRepository;
			_foodImageRepository = foodImageRepository;
		}

		public async Task<IActionResult> Menu(int categoryId)
		{
			CategoryModel category = await _categoryRepository.GetById(categoryId);

			if (category == null)
			{
				//TODO: show not found error

			}

			List<FoodModel> food = await _foodRepository.GetByCategoryId(categoryId);

			if (food.Count == 0)
			{
				//TODO: show not found error

			}

			CategoryDto dto = new CategoryDto(category, food);

			return View(dto);
		}
	}
}



