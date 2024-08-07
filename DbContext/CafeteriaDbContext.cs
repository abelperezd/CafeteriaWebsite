using CafeteriaWebsite.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CafeteriaWebsite.CafeteriaDbContext
{
	public class CafeteriaDbContext : DbContext
	{
		public CafeteriaDbContext(DbContextOptions options) : base(options)
		{
		}

		//DbSet<Category>
	}
}
