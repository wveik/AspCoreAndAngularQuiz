namespace DataAccessLayer.Interfaces.Question
{
	public interface IQuestionRepository : IRepository<Entities.Question>
	{
		Entities.Question GetFirst();

		bool HasNext(int id);

		Entities.Question GetNext(int id);
	}
}