using System.Collections.Generic;
using AspCoreAndAngularQuiz.Models;
using BusinessLogic.Interfaces;
using Common.DTO.Quiz;
using Common.Helpers;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspCoreAndAngularQuiz.Controllers
{
	[Route("api/[controller]")]
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

		// GET: api/<controller>
		[HttpGet]
		public ResponseQuizDTO Get()
		{
			return _quizService.GetFirstQuizDto();
		}

		// GET api/<controller>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<controller>
		[HttpPost]
		public void Post([FromBody]PostQuizDTO value)
		{
			var isRightAnswer = _quizService.IsRightAnswer(value);
			var question = _questionService.GetQuestionById(value.QuestionId);

			var answer = new Answer(isRightAnswer, question);

			var list = new List<Answer>();

			if (HttpContext.Session.TryGetValue(KeyQuiz, out var byteArray))
				list = byteArray.Deserializer<List<Answer>>();

			list.Add(answer);

			HttpContext.Session.Set(KeyQuiz, list.Serializer());
		}

		// PUT api/<controller>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE api/<controller>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
