using System.Collections.Generic;
using Common.DTO.Question;

namespace BusinessLogic.Interfaces
{
	public interface IQuestionService
	{
		/// <summary>
		/// Create question
		/// </summary>
		/// <param name="dto"></param>
		void CreateQuestion(QuestionDTO dto);

		/// <summary>
		/// Get all questions
		/// </summary>
		/// <returns></returns>
		IEnumerable<QuestionDTO> GetAllQuestion();

		/// <summary>
		/// Get question by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		QuestionDTO GetQuestionById(int id);

		/// <summary>
		/// Delete question
		/// </summary>
		/// <param name="id"></param>
		void DeleteQuestionById(int id);

		/// <summary>
		/// Update question
		/// </summary>
		/// <param name="dto"></param>
		void UpdateQuestion(QuestionDTO dto);
	}
}