using CafeteriaWebsite.Models;

namespace CafeteriaWebsite.Repositories.Interfaces
{
	public interface ICategory
	{
		public List<CategoryModel> GetAll();
		public CategoryModel GetById(int id);
	}
}
