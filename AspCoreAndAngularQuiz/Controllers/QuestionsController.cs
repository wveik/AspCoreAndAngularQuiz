using System.Collections.Generic;
using BusinessLogic.Interfaces;
using Common.DTO.Question;
using Microsoft.AspNetCore.Mvc;

namespace AspCoreAndAngularQuiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
	    private readonly IQuestionService _questionService;
		public QuestionsController(IQuestionService questionService)
		{
			_questionService = questionService;
		}

	    // GET: api/Questions
        [HttpGet]
        public IEnumerable<QuestionDTO> Get()
        {
	        return _questionService.GetAllQuestion();
        }

        // GET: api/Questions/5
        [HttpGet("{id}", Name = "Get")]
        public QuestionDTO Get(int id)
        {
			return _questionService.GetQuestionById(id);
		}

        // POST: api/Questions
        [HttpPost]
        public void Post([FromBody] QuestionDTO question)
        {
			_questionService.CreateQuestion(question);
		}

		// DELETE:
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			_questionService.DeleteQuestionById(id);
		}

		[HttpPut]
		public void Put([FromBody] QuestionDTO question)
		{
			_questionService.UpdateQuestion(question);
		}
	}
}
