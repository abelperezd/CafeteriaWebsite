using CafeteriaWebsite.Models;
using CafeteriaWebsite.Repositories.Interfaces;

namespace CafeteriaWebsite.Repositories
{
	public class FoodRepository : IFood
	{
		public List<FoodModel> GetAll()
		{
			throw new NotImplementedException();
		}

		public List<FoodModel> GetByCategoryId(int id)
		{
			throw new NotImplementedException();
		}

		public FoodModel GetById(int id)
		{
			throw new NotImplementedException();
		}
	}
}
