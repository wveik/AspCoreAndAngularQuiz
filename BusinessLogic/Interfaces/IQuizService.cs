using Common.DTO.Quiz;

namespace BusinessLogic.Interfaces
{
	public interface IQuizService
	{
		ResponseQuizDTO GetFirstQuizDto();

		bool IsRightAnswer(PostQuizDTO data);

		ResponseQuizDTO GetNextQuizDto(int id);
	}
}