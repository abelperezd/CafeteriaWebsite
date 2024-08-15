using CafeteriaWebsite.Enums;
using CafeteriaWebsite.Models;
using CafeteriaWebsite.Repositories.Interfaces;
using CafeteriaWebsite.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CafeteriaWebsite.Controllers
{
	public class FoodController : Controller
	{
		private readonly IFoodRepository _foodRepository;
		//commented for deployment
		//private readonly IFoodImageRepository _foodImageRepository;

		public FoodController(ICategoryRepository categoryRepository, IFoodRepository foodRepository/*, IFoodImageRepository foodImageRepository*/)
		{
			_foodRepository = foodRepository;
			//commented for deployment
			//_foodImageRepository = foodImageRepository;
		}

		#region Remove


		[HttpPost]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> DeleteFromToast(int id)
		{
			FoodModel food = await _foodRepository.GetById(id);

			if (food == null)
			{
				return BadRequest("Not authorised");
			}

			//for now, avoid removing it from the database
			await _foodRepository.Delete(id);

			return Ok();
		}

		#endregion

		#region Add


		public async Task<IActionResult> AddNew(int categoryId)
		{
			CreateFoodDto createFoodDto = new CreateFoodDto() { CategoryId = categoryId, };
			createFoodDto.InitializeTags();
			return View(createFoodDto);
		}

		[HttpPost]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> AddNew(CreateFoodDto dto)
		{
			if (!ModelState.IsValid)
			{
				return View(dto);
			}

			FoodModel food = new FoodModel()
			{ Name = dto.Name,
				CategoryId = dto.CategoryId,
				Description = dto.Description,
				Price = dto.Price,
				Tags = dto.TagsIntList };

			if (dto.Image != null)
			{
				food.FoodImageId = await SaveImageInDb(dto.Image);
			}

			await _foodRepository.Create(food);

			return RedirectToAction("Menu", "Category", new
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
				//commented for deployment
				//return await _foodImageRepository.Create(imageModel);
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

		#endregion

	}
}



