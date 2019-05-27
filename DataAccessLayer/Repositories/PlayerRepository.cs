using System.Collections.Generic;
using DataAccessLayer.EF;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer.Repositories
{
	public class PlayerRepository : IRepository<Player>
	{
		private readonly Context _db;

		public PlayerRepository(Context context)
		{
			_db = context;
		}

		public IEnumerable<Player> ReadAll()
		{
			return _db.Players;
		}

		public Player Read(int id)
		{
			return _db.Players.Find(id);
		}

		public void Create(Player player)
		{
			_db.Players.Add(player);
		}

		public void Update(Player player)
		{
			var previousPlayer = _db.Players.Find(player.Id);

			if (previousPlayer != null)
			{
				_db.Players.Remove(previousPlayer);
				var newPlayer = new Player()
				{
					Name = player.Name,
					Surname = player.Surname,
					IsHealthy = player.IsHealthy,
					IsInGame = player.IsInGame,
					Salary = player.Salary,
					Date = player.Date
				};

				_db.Players.Add(newPlayer);
			}
		}

		public void Delete(int id)
		{
			var player = _db.Players.Find(id);
			if (player != null)
				_db.Players.Remove(player);
		}
	}
}