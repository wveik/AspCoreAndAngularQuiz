using System;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{
		IRepository<Player> Players { get; }
		void Save();
	}
}