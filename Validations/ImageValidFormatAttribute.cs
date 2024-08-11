using CafeteriaWebsite.Utils;
using System.ComponentModel.DataAnnotations;

namespace CafeteriaWebsite.Validations
{
	public class ImageValidFormatAttribute : ValidationAttribute
	{
		private string[] _validExtensions = ["jpg", "jpeg", "png"];

		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			//we allow null images
			if(value == null)
			{
				return ValidationResult.Success;
			}

			if(value is not IFormFile)
				return new ValidationResult("File is required.");

			IFormFile model = (IFormFile)value;

			//return true becau
			if (model == null)
				return new ValidationResult("Wrong image format.");

			foreach (var ext in _validExtensions)
			{
				if (model.FileName.GetExtension().Equals(ext, StringComparison.CurrentCultureIgnoreCase))
					return ValidationResult.Success;
			}
			return new ValidationResult($"Invaled image extension. Allowed types: {string.Join(", ", _validExtensions)}");

		}
	}
}
