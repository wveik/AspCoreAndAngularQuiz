﻿using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.EF;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.Question;

namespace DataAccessLayer.Repositories
{
	public class QuestionRepository : IQuestionRepository
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

		public Question GetFirst()
		{
			return _db.Questions
				.OrderBy(x => x.Id)
				.FirstOrDefault();
		}

		public Question GetNext(int id)
		{
			return _db.Questions
				.Where(x => x.Id > id)
				.OrderBy(x => x.Id)
				.FirstOrDefault();
		}

		public bool HasNext(int id)
		{
			return _db.Questions.Count(x => x.Id > id) > 0;
		}
	}
}