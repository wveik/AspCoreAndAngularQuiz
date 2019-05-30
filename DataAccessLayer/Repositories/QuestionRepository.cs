using System;
using System.Collections.Generic;
using DataAccessLayer.EF;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer.Repositories
{
	public class QuestionRepository : IRepository<Question>
	{
		private readonly Context _db;

		public QuestionRepository(Context context)
		{
			_db = context;
		}

		public IEnumerable<Question> ReadAll()
		{
			return _db.Questions;
		}

		public Question Read(int id)
		{
			return _db.Questions.Find(id);
		}

		public void Create(Question item)
		{
			item.DateInsert = DateTime.Now;
			item.DateUpdate = DateTime.Now;

			_db.Questions.Add(item);
		}

		public void Update(Question item)
		{
			item.DateUpdate = DateTime.Now;

			_db.Questions.Update(item);
		}

		public void Delete(int id)
		{
			var question = _db.Questions.Find(id);
			if (question != null)
				_db.Questions.Remove(question);
		}
	}
}