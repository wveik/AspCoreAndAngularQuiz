using System.Collections.Generic;
using System.Linq;
using AspCoreAndAngularQuiz.Models;
using BusinessLogic.Interfaces;
using Common.DTO.Quiz;
using Common.Helpers;
using Microsoft.AspNetCore.Mvc;
using SystemException = Common.Exceptions.SystemException;

namespace AspCoreAndAngularQuiz.Controllers
{
	public class QuizController : Controller
    {
	    private readonly IQuizService _quizService;
	    private readonly IQuestionService _questionService;

	    private const string KeyQuiz = "KEY_QUIZ";

	    public QuizController(IQuizService quizService, IQuestionService questionService)
	    {
		    _quizService = quizService;
		    _questionService = questionService;
	    }

		[HttpGet]
		public ResponseQuizDTO GetFirstQuizDto()
		{
			return _quizService.GetFirstQuizDto();
		}

		[HttpGet]
		public ResponseQuizDTO GetNextQuizDto(int id)
		{
			return _quizService.GetNextQuizDto(id);
		}

		[HttpGet]
		public ResultQuiz GetResultQuiz()
		{
			List<AnswerModel> list;

			if (HttpContext.Session.TryGetValue(KeyQuiz, out var byteArray))
				list = byteArray.Deserializer<List<AnswerModel>>();
			else 
				throw new SystemException("Did not have data from server.");

			HttpContext.Session.Clear();

			var isWinner = list.All(x => x.IsRightAnswer);

			var result = new ResultQuiz(isWinner, list.Count, list.Count(x => x.IsRightAnswer));

			return result;
		}

		[HttpPost]
		public void PostQuiz([FromBody]PostQuizDTO value)
		{
			var isRightAnswer = _quizService.IsRightAnswer(value);
			var question = _questionService.GetQuestionById(value.QuestionId);

			var answer = new AnswerModel(isRightAnswer, question);

			var list = new List<AnswerModel>();

			if (HttpContext.Session.TryGetValue(KeyQuiz, out var byteArray))
				list = byteArray.Deserializer<List<AnswerModel>>();

			list.Add(answer);

			HttpContext.Session.Set(KeyQuiz, list.Serializer());
		}
    }
}