﻿using CafeteriaWebsite.Models;

namespace CafeteriaWebsite.Repositories.Interfaces
{
	public interface IFood
	{
		public List<FoodModel> GetAll();
		public FoodModel GetById(int id);
		public List<FoodModel> GetByCategoryId(int id);

	}
}
