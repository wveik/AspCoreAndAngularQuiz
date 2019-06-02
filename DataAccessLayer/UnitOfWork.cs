using DataAccessLayer.EF;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Interfaces.Question;

namespace DataAccessLayer
{
	public class UnitOfWork : IUnitOfWork
	{
		private Context DataBase { get; }

		public UnitOfWork(Context dataBase, IRepository<Player> players, IQuestionRepository questions)
		{
			DataBase = dataBase;
			Players = players;
			Questions = questions;
		}

		public IRepository<Player> Players { get; }

		public IQuestionRepository Questions { get; }

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