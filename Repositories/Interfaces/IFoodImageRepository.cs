using CafeteriaWebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace CafeteriaWebsite.Repositories.Interfaces
{
	public interface IFoodImageRepository
	{
		public Task<int?> Create([Bind(["ImageData", "FileExtension"])] FoodImageModel image);
		public Task Delete(int id);
		public Task<FoodImageModel> GetById(int id);
	}
}
