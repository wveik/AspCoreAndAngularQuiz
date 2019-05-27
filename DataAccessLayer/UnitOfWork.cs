using DataAccessLayer.EF;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer
{
	public class UnitOfWork : IUnitOfWork
	{
		private Context DataBase { get; }

		public UnitOfWork(Context dataBase, IRepository<Player> players, IRepository<Question> questions)
		{
			DataBase = dataBase;
			Players = players;
			Questions = questions;
		}

		public IRepository<Player> Players { get; }

		public IRepository<Question> Questions { get; }

		public void Save()
		{
			DataBase.SaveChanges();
		}

		public void Dispose()
		{
			DataBase.Dispose();
		}
	}
}