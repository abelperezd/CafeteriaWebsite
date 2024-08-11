using CafeteriaWebsite.Models;
using CafeteriaWebsite.Utils;
using System.ComponentModel.DataAnnotations;

namespace CafeteriaWebsite.Validations
{
	public class ImageValidSizeAttribute : ValidationAttribute
	{
		//max size, 256KB
		private readonly long _maxFileSize = 265 * 1024;

		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			//we allow null images
			if (value == null)
			{
				return ValidationResult.Success;
			}

			if (value is not IFormFile file)
			{
				return new ValidationResult("File is required.");
			}

			if (file == null || file.Length == 0)
			{
				return new ValidationResult("No file uploaded.");
			}


			// Check file size
			if (file.Length > _maxFileSize)
			{
				return new ValidationResult($"The file size exceeds the limit of {_maxFileSize / 1024} KB.");
			}

			return ValidationResult.Success;
		}
	}
}
