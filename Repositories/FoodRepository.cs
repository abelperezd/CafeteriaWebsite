﻿using CafeteriaWebsite.AppDbContext;
using CafeteriaWebsite.Models;
using CafeteriaWebsite.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CafeteriaWebsite.Repositories
{
	public class FoodRepository : IFoodRepository
	{
		private readonly CafeteriaDbContext _context;
		private readonly IFoodImageRepository _foodImageRepository;

		public FoodRepository(CafeteriaDbContext context, IFoodImageRepository foodImageRepository) {
			_context = context;
			_foodImageRepository = foodImageRepository;
		}
		public async Task<int> Create([Bind(new[] { "Name", "CategoryId" })] FoodModel food)
		{
			FoodModel? itemFound = _context.Food.FirstOrDefault(item => item.Name == food.Name);
			if (itemFound != null)
				return itemFound.Id;

			_context.Food.Add(food);
			await _context.SaveChangesAsync();

			return food.Id;
		}

		public async Task Delete(int id)
		{
			FoodModel dbFood = await _context.Food.SingleOrDefaultAsync(n => n.Id == id);

			if (dbFood != null)
			{
				_context.Food.Remove(dbFood);

				//for some reason it is not automatically removed
				if(dbFood.FoodImageId != null)
				{
					await _foodImageRepository.Delete((int)dbFood.FoodImageId);
				}

				await _context.SaveChangesAsync();
			}

		}

		public async Task<List<FoodModel>> GetByCategoryId(int id)
		{
			//for some reason, .Include does not work.
			var foods =  await _context.Food.Where(item => item.CategoryId == id)/*.Include(item => item.Image)*/.ToListAsync();

			foreach (var food in foods)
			{
				if (food.FoodImageId != null)
					food.Image = await _foodImageRepository.GetById((int)food.FoodImageId);
			}
			return foods;
		}

		public async Task<FoodModel> GetById(int id)
		{
			return await _context.Food
				.Include(item => item.Image)
				.SingleOrDefaultAsync(item => item.Id == id);
		}
	}
}
