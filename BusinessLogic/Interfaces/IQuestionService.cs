using System.Collections.Generic;
using Common.DTO;

namespace BusinessLogic.Interfaces
{
	public interface IQuestionService
	{
		/// <summary>
		/// Create question
		/// </summary>
		/// <param name="dto"></param>
		void CreateQuestion(QuestionDto dto);

		/// <summary>
		/// Get all questions
		/// </summary>
		/// <returns></returns>
		IEnumerable<QuestionDto> GetAllQuestion();

		/// <summary>
		/// Get question by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		QuestionDto GetQuestionById(int id);

		/// <summary>
		/// Delete question
		/// </summary>
		/// <param name="id"></param>
		void DeleteQuestionById(int id);

		/// <summary>
		/// Update question
		/// </summary>
		/// <param name="dto"></param>
		void UpdateQuestion(QuestionDto dto);
	}
}