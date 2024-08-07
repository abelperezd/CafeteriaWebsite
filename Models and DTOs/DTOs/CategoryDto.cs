namespace CafeteriaWebsite.Models
{
	public class CategoryDto
	{
		public CategoryModel Category { get; private set; }
		public List<FoodModel> Food{ get; private set; }

		public CategoryDto(CategoryModel category, List<FoodModel> food)
		{
			Category = category;
			Food = food;
		}
	}
}
