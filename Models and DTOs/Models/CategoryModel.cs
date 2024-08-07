using Microsoft.Identity.Client;

namespace CafeteriaWebsite.Models
{
	public class CategoryModel
	{
		public int Id { get; set; }	
		public string  Name { get; set; }
		public string? Description { get; set; }

	}
}
