using CafeteriaWebsite.Models;

namespace CafeteriaWebsite.Repositories.Interfaces
{
	public interface ICategoryRepository
	{
		public List<CategoryModel> GetAll();
		public CategoryModel GetById(int id);
	}
}
