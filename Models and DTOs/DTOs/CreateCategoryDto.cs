using CafeteriaWebsite.Enums;
using CafeteriaWebsite.Validations;
using System.ComponentModel.DataAnnotations;

namespace CafeteriaWebsite.Models
{
	public class CreateCategoryDto
	{
		[StringLength(maximumLength: 100, MinimumLength = 3, ErrorMessage = "{0} length must be between {2} and {1}")]
		[Required(ErrorMessage = "The {0} field is required")]
		[Display(Name = "Name")]
		[FirstLetterIsCapital]
		public string Name { get; set; }

		public string? Description { get; set; }

	}
}
