﻿using CafeteriaWebsite.Enums;

namespace CafeteriaWebsite.Models
{
	public class FoodModel
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string? Description { get; set; }
		public float Price{ get; set; }

		public List<int>? Tags { get; set; }

		public int? FoodImageId { get; set; }

		public int CategoryId { get; set; }
		public CategoryModel? Category { get; set; }
		public FoodImageModel? Image { get; set; }

		//For the mock repository
		public string? ImageUrl { get; set; }

		public List<FoodTag> TagsAsEnums
		{
			get
			{
				if (Tags == null)
					return new List<FoodTag>();

				return Tags
					//.Where(tag => Enum.IsDefined(typeof(FoodTag), tag)) // Ensure the int can be converted to a FoodTag
					.Select(tag => ((FoodTag)tag)/*.ToString().Replace("_", " ")*/) // Convert int to FoodTag
					.ToList();
			}
		}

		public string ImageSrc => Image != null ? Image.ImageAsString : ImageUrl;

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
