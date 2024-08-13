using CafeteriaWebsite.Enums;

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

		public string GetTagColor(FoodTag tag)
		{


			switch (tag)
			{
				case FoodTag.Recommended:
					return "#daae61";
				case FoodTag.New:
					return "#61cada";
				case FoodTag.Vegetarian:
					return "#61da6c";
				case FoodTag.Vegan:
					return "#3b7941";
			}
			return "";
		}

	}
}
