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
		private QuestionRepository _questionRepository;

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

		public IRepository<Question> Questions
		{
			get
			{
				if (_questionRepository == null)
					_questionRepository = new QuestionRepository(DataBase);

				return _questionRepository;
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