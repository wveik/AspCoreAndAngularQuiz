using System;
using Common.DTO;
using DataAccessLayer;
using DataAccessLayer.Entities;

namespace BusinessLogic
{
	public class BlClass : IDisposable
	{
		private UnitOfWork Db { get; }

		public BlClass()
		{
			Db = new UnitOfWork();
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