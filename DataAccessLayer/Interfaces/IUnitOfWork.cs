using System;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.Question;

namespace DataAccessLayer.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{
		IRepository<Player> Players { get; }

		IQuestionRepository Questions { get; }

		void Save();
	}
}