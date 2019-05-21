using DataAccessLayer.EF;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;

namespace DataAccessLayer
{
	public class UnitOfWork : IUnitOfWork
	{
		private Context DataBase { get; }
		private PlayerRepository _playersRepository;

		public UnitOfWork()
		{
			DataBase = new Context();
		}

		public IRepository<Player> Players
		{
			get
			{
				if (_playersRepository == null)
					_playersRepository = new PlayerRepository(DataBase);

				return _playersRepository;
			}
		}

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