using Microsoft.EntityFrameworkCore;
using PresentationLayer.Entities;

namespace PresentationLayer.EF
{
	public class Context : DbContext
	{
		public DbSet<Player> Players { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite("Data Source=quiz.db");
		}
	}
}