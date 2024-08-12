using CafeteriaWebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace CafeteriaWebsite.Repositories.Interfaces
{
	public interface ICategoryRepository
	{
		public Task<int> Create([Bind(["Name"])] CategoryModel category);
		public Task Delete(int id);
		public Task<List<CategoryModel>> GetAll();
		public Task<CategoryModel> GetById(int id);
		public CategoryModel GetByIdNotAsync(int id);
		public Task Update(UpdateCategoryDto dto);
	}
}
