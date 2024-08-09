using CafeteriaWebsite.Enums;
using CafeteriaWebsite.Models;
using CafeteriaWebsite.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;

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

		public IActionResult AddNew(int categoryId)
		{
			CreateFoodDto createFoodDto = new CreateFoodDto() { CategoryId = categoryId, };
			createFoodDto.InitializeTags();
			return View (createFoodDto);
		}

		//TODO: move this to food controller
		[HttpPost]
		public async Task<IActionResult> AddNew(CreateFoodDto dto)
		{
			if (!ModelState.IsValid)
			{
				return View(dto);
			}

			FoodModel food = new FoodModel() { Name = dto.Name , CategoryId = dto.CategoryId, Description = dto.Description, Tags = dto.TagsIntList};


			if (dto.Image != null && dto.Image.Length > 0)
			{
				// Define the path to save the file
				var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

				// Ensure the directory exists
				if (!Directory.Exists(uploadsFolder))
				{
					Directory.CreateDirectory(uploadsFolder);
				}

				// Generate a unique file name to prevent overwriting
				var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(dto.Image.FileName);
				var filePath = Path.Combine(uploadsFolder, uniqueFileName);

				// Save the file to the specified path
				using (var stream = new FileStream(filePath, FileMode.Create))
				{
					await dto.Image.CopyToAsync(stream);
				}

				// Optionally, you can store the file path or name in your FoodModel or database
				food.ImageUrl = "/uploads/" + uniqueFileName; // Adjust according to your model
			}


			// Your logic to save the food model

			return RedirectToAction("Menu", new { categoryId = dto.CategoryId });


			/*
			Note note = _mapper.Map<Note>(dto);

			note.CreationDate = DateTime.Now;
			note.UserId = _userService.GetUserId();

			//check if the user already has this note
			if (await _repositoryNotes.Exists(note.Text, note.UserId))
			{
				dto.NoteImportance = GetNoteImportance();
				ModelState.AddModelError(nameof(dto.Text), $"Text {dto.Text} already exists.");
				return View(dto);
			}
D
			await _repositoryNotes.Create(note);
			*/

			return RedirectToAction("Menu", new { categoryId = dto.CategoryId });
		}

		private List<FoodTag> AllFoodTags => Enum.GetValues(typeof(FoodTag)).Cast<FoodTag>().ToList();


	}
}



