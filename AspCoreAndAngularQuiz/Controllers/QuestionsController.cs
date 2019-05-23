using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspCoreAndAngularQuiz.Models.Questions;
using BusinessLogic.Interfaces;
using Common.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspCoreAndAngularQuiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
	    private IQuestionService _questionService;
		public QuestionsController(IQuestionService questionService)
		{
			_questionService = questionService;
		}

	    // GET: api/Questions
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Questions/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Questions
        [HttpPost]
        public void Post([FromBody] Question question)
        {
			_questionService.SaveQuestion(new QuestionDto()
			{
				Text = question.Text
			});
		}
	}
}
