using CafeteriaWebsite.Models;
using CafeteriaWebsite.Repositories.Interfaces;
using CafeteriaWebsite.Utils;
using Microsoft.AspNetCore.Authorization;
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

		[HttpPost]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> DeleteFromToast(int id)
		{
			CategoryModel cat = await _categoryRepository.GetById(id);

			if (cat == null)
			{
				return BadRequest("Not authorised");
			}

			//for now, avoid removing it from the database
			await _categoryRepository.Delete(id);

			return Ok();
		}

		public async Task<IActionResult> AddNew()
		{
			//CreateFoodDto createFoodDto = new CreateFoodDto() { CategoryId = categoryId, };
			//return View(createFoodDto);
			return View(new CreateCategoryDto());
		}

		[HttpPost]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> AddNew(CreateCategoryDto dto)
		{
			if (!ModelState.IsValid)
			{
				return View(dto);
			}

			CategoryModel model = new CategoryModel() { Name = dto.Name, Description = dto.Description };


			int categoryId = await _categoryRepository.Create(model);

			return RedirectToAction("Menu", new
			{
				categoryId
			});
		}

		[HttpGet]
		public async Task<ActionResult> Update(int id)
		{
			CategoryModel model = await _categoryRepository.GetById(id);

			if (model == null)
			{
				return RedirectToAction(Constants.NOT_FOUND_REDIRECT, "Home");
			}

			UpdateCategoryDto dto = new UpdateCategoryDto(model.Id, model.Name, model.Description);
			return View(dto);
		}

		[HttpPost]
		[Authorize(Roles = "Admin")]
		public async Task<ActionResult> Update(UpdateCategoryDto dto)
		{
			bool exists = await _categoryRepository.GetById(dto.Id) != null;

			if (!exists)
			{
				return RedirectToAction(Constants.NOT_FOUND_REDIRECT, "Home");
			}

			await _categoryRepository.Update(dto);

			return RedirectToAction("Home","Home");
		}

	}
}



