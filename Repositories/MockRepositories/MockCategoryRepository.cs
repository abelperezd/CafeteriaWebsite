using CafeteriaWebsite.Models;
using CafeteriaWebsite.Repositories.Interfaces;

namespace CafeteriaWebsite.Repositories.MockRepositories
{
	public class MockCategoryRepository : ICategory
	{
		public List<CategoryModel> GetAll()
		{
			throw new NotImplementedException();
		}

		public CategoryModel GetById(int id)
		{
			throw new NotImplementedException();
		}
	}
}
