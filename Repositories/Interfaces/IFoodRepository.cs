using CafeteriaWebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace CafeteriaWebsite.Repositories.Interfaces
{
	public interface IFoodRepository
	{
		public Task<int> Create([Bind(["Name", "CategoryId"])] FoodModel category);
		public Task Delete(int id);

		public Task<FoodModel> GetById(int id);
		public Task<List<FoodModel>> GetByCategoryId(int id);

	}
}
