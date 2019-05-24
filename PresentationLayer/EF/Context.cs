using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EF
{
	public class Context : DbContext
	{
		public Context(DbContextOptions<Context> options)
			: base(options)
		{ }

		public DbSet<Player> Players { get; set; }

		public DbSet<Question> Questions { get; set; }

		//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		//{
		//	optionsBuilder.UseSqlite("Data Source=quiz.db");
		//}
	}
}