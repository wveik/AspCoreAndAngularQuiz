﻿using System.Collections.Generic;
using AutoMapper;
using BusinessLogic.Interfaces;
using Common.DTO.Question;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;

namespace BusinessLogic.Services
{
	public class QuestionService : IQuestionService
	{
		private readonly IUnitOfWork _unitOfWork;

		public QuestionService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public void CreateQuestion(QuestionDTO dto)
		{
			var result = Mapper.Map<QuestionDTO, Question>(dto);

			_unitOfWork.Questions.Create(result);

			_unitOfWork.Save();
		}

		public void UpdateQuestion(QuestionDTO dto)
		{
			var result = Mapper.Map<QuestionDTO, Question>(dto);

			_unitOfWork.Questions.Update(result);

			_unitOfWork.Save();
		}

		public IEnumerable<QuestionDTO> GetAllQuestion()
		{
			var questions = _unitOfWork.Questions.ReadAll();

			var result = Mapper.Map<IEnumerable<Question>, List<QuestionDTO>>(questions);

			return result;
		}

		public QuestionDTO GetQuestionById(int id)
		{
			var question = _unitOfWork.Questions.Read(id);

			var result = Mapper.Map<Question, QuestionDTO>(question);

			return result;
		}

		public void DeleteQuestionById(int id)
		{
			_unitOfWork.Questions.Delete(id);
			_unitOfWork.Save();
		}
	}
}