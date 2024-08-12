using CafeteriaWebsite.Enums;
using CafeteriaWebsite.Validations;
using System.ComponentModel.DataAnnotations;

namespace CafeteriaWebsite.Models
{
	public class UpdateCategoryDto
	{
		public int Id { get; set; }

		[StringLength(maximumLength: 100, MinimumLength = 3, ErrorMessage = "{0} length must be between {2} and {1}")]
		[Required(ErrorMessage = "The {0} field is required")]
		[Display(Name = "Name")]
		[FirstLetterIsCapital]
		public string Name { get; set; }

		public string? Description { get; set; }

		public UpdateCategoryDto(int id, string name, string? description)
		{
			Id = id;
			Name = name;
			Description = description;

		}

		public UpdateCategoryDto() { }
	}
}
