using CafeteriaWebsite.Enums;
using CafeteriaWebsite.Validations;
using System.ComponentModel.DataAnnotations;

namespace CafeteriaWebsite.Models
{
	public class CreateFoodDto : IValidatableObject
	{
		[StringLength(maximumLength: 100, MinimumLength = 3, ErrorMessage = "{0} length must be between {2} and {1}")]
		[Required(ErrorMessage = "The {0} field is required")]
		[Display(Name = "Name")]
		[FirstLetterIsCapital]
		public string Name { get; set; }

		public string? Description { get; set; }

		//public string? ImageUrl { get; set; }

		public List<bool> Tags { get; private set; } = new List<bool>();

		public List<FoodTag> TagOptions => Enum.GetValues(typeof(FoodTag)).Cast<FoodTag>().ToList();

		public int CategoryId { get; set; }

		public IFormFile? Image { get; set; }

		public void InitializeTags()
		{
			Tags = new List<bool>();

			for (int i = 0; i < TagOptions.Count; i++)
			{
				Tags.Add(false);
			}
		}

		public List<int> TagsIntList
		{
			get
			{
				List<int> ts = new List<int>();
				for (int i = 0; i < Tags.Count; i++)
				{
					if (Tags[i])
						ts.Add(i);
				}

				return ts;
			}
		}

		//This is not really needed in our case. But in other situations, it is used to do more elaborated validations.
		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			//The second paramter tells us which properties have the error. If it not indicated, it is considered an error model. E.g: some user is not allowed to do something
			if (Name == null)
				yield return new ValidationResult("Field cannot be null", [nameof(Name)]);
		}
	}
}
