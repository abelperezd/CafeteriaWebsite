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

		public async Task<IActionResult> AddNew(int categoryId)
		{
			CreateFoodDto createFoodDto = new CreateFoodDto() { CategoryId = categoryId, };
			createFoodDto.InitializeTags();
			return View(createFoodDto);
		}

		//TODO: move this to food controller
		[HttpPost]
		public async Task<IActionResult> AddNew(CreateFoodDto dto)
		{
			if (!ModelState.IsValid)
			{
				return View(dto);
			}

			FoodModel food = new FoodModel() { Name = dto.Name, CategoryId = dto.CategoryId, Description = dto.Description, Tags = dto.TagsIntList };

			if (dto.Image != null)
			{
				food.FoodImageId = await SaveImageInDb(dto.Image);
			}


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

			await _foodRepository.Create(food);

			return RedirectToAction("Menu", new
			{
				categoryId = dto.CategoryId
			});
		}

		private List<FoodTag> AllFoodTags => Enum.GetValues(typeof(FoodTag)).Cast<FoodTag>().ToList();

		private async Task<int?> SaveImageInDb(IFormFile image)
		{
			byte[] imageData = null;

			if (image.Length > 0)
			{
				using (var ms = new MemoryStream())
				{
					await image.CopyToAsync(ms);
					imageData = ms.ToArray();
				}
			}

			if (imageData != null)
			{
				FoodImageModel imageModel = new FoodImageModel()
				{
					ImageData = imageData,
					FileExtension = image.FileName.GetExtension()
				};

				return await _foodImageRepository.Create(imageModel);
			}
			return -1;

		}

		private async void SaveImageLocally(IFormFile image)
		{
			if (image != null && image.Length > 0)
			{
				// Define the path to save the file
				var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

				// Ensure the directory exists
				if (!Directory.Exists(uploadsFolder))
				{
					Directory.CreateDirectory(uploadsFolder);
				}

				// Generate a unique file name to prevent overwriting
				var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
				var filePath = Path.Combine(uploadsFolder, uniqueFileName);

				// Save the file to the specified path
				using (var stream = new FileStream(filePath, FileMode.Create))
				{
					await image.CopyToAsync(stream);
				}
			}
		}

	}
}



