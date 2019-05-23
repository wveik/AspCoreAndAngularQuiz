using Common.DTO;

namespace BusinessLogic.Interfaces
{
	public interface IQuestionService
	{
		void SaveQuestion(QuestionDto dto);
	}
}