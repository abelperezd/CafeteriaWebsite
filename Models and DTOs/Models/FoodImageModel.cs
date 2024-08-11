using CafeteriaWebsite.Enums;
using CafeteriaWebsite.Validations;

namespace CafeteriaWebsite.Models
{
	public class FoodImageModel
	{
		public int Id { get; set; }

		//binary data
		public byte[] ImageData { get; set; }

		
		public string FileExtension { get; set; }

		public string ImageAsString
		{
			get
			{
				string base64Image = ImageData != null
					? Convert.ToBase64String(ImageData)
					: null;

				string imageSrc = base64Image != null
					? $"data:image/{FileExtension.TrimStart('.')};base64,{base64Image}"
					: null;

				return imageSrc;
			}
		}

	}
}
