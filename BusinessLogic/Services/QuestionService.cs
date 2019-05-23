using BusinessLogic.Interfaces;
using Common.DTO;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;

namespace BusinessLogic.Services
{
	public class QuestionService : IQuestionService
	{
		private readonly IUnitOfWork _unitOfWork;

		public QuestionService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public void SaveQuestion(QuestionDto dto)
		{
			_unitOfWork.Questions.Create(new Question()
			{
				Text = dto.Text
			});
			_unitOfWork.Save();
		}
	}
}