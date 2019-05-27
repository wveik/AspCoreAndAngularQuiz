using System.Collections.Generic;
using Common.DTO;

namespace BusinessLogic.Interfaces
{
	public interface IQuestionService
	{
		void SaveQuestion(QuestionDto dto);

		IEnumerable<QuestionDto> GetAllQuestion();

		QuestionDto GetQuestionById(int id);

		void DeleteQuestionById(int id);
	}
}