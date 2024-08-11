using CafeteriaWebsite.Enums;

namespace CafeteriaWebsite.Models
{
	public class FoodModel
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string? Description { get; set; }


		public List<int>? Tags { get; set; }

		public int? FoodImageId { get; set; }

		public int CategoryId { get; set; }
		public CategoryModel? Category { get; set; }
		public FoodImageModel? Image { get; set; }



		public List<FoodTag> TagsAsEnums
		{
			get
			{
				if (Tags == null)
					return new List<FoodTag>();

				return Tags
					//.Where(tag => Enum.IsDefined(typeof(FoodTag), tag)) // Ensure the int can be converted to a FoodTag
					.Select(tag => (FoodTag)tag) // Convert int to FoodTag
					.ToList();
			}
		}
	}
}
