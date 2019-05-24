using BusinessLogic.Interfaces;
using Common.DTO;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;

namespace BusinessLogic.Logic
{
	public class BlClass : IBlClass
	{
		private IUnitOfWork Db { get; }

		public BlClass(IUnitOfWork db)
		{
			Db = db;
		}

		public void AddPlayer(PlayerDto element)
		{
			Db.Players.Create(new Player()
			{
				Id = element.Id,
				Date = element.Date,
				IsHealthy = element.IsHealthy,
				IsInGame = element.IsInGame,
				Name = element.Name,
				Salary = element.Salary,
				Surname = element.Surname
			});
			Db.Save();
		}

		public void Dispose()
		{
			Db.Dispose();
		}
	}
}