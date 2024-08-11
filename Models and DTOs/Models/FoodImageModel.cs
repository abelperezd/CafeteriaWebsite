using CafeteriaWebsite.Enums;

namespace CafeteriaWebsite.Models
{
	public class FoodImageModel
	{
		public int Id { get; set; }

		//binary data
		public byte[] ImageData { get; set; }

		public string FileExtension { get; set; }
	}
}
