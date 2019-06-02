using System.Collections.Generic;
using BusinessLogic.Interfaces;
using BusinessLogic.System;
using Common.DTO.Quiz;
using Common.Exceptions;
using DataAccessLayer.Interfaces;

namespace BusinessLogic.Services
{
	public class QuizService : IQuizService
	{
		private readonly IUnitOfWork _unitOfWork;

		public QuizService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public bool IsRightAnswer(PostQuizDTO data)
		{
			var id = data.QuestionId;
			var question = _unitOfWork.Questions.Read(id);

			if (question == null)
				throw new LogicException($"Error from check quiz. Did not find question by id: {id}");

			return question.Answer == data.Answer;
		}

		public ResponseQuizDTO GetFirstQuizDto()
		{
			var result = new ResponseQuizDTO
			{
				Quiz = new QuizDTO()
			};

			var question = _unitOfWork.Questions.GetFirst();

			if (question == null)
			{
				result = new ResponseQuizDTO
				{
					IsFinished = true,
					HasNext = false
				};

				return result;
			}

			result.Quiz.QuestionId = question.Id;
			result.HasNext = _unitOfWork.Questions.HasNext(question.Id);

			var questions = new List<string>
			{
				question.Answer, question.WrongAnswer1, question.WrongAnswer2, question.WrongAnswer3
			};

			questions.Shuffle();

			result.Quiz.Question = question.Text;

			result.Quiz.Answer1 = questions[0];
			result.Quiz.Answer2 = questions[1];
			result.Quiz.Answer3 = questions[2];
			result.Quiz.Answer4 = questions[3];

			return result;
		}
	}
}