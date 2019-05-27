namespace AspCoreAndAngularQuiz.Models.Questions
{
	public class Question
	{
		public int Id { get; set; }

		public string Text { get; set; }

		public string Answer { get; set; }

		public string WrongAnswer1 { get; set; }

		public string WrongAnswer2 { get; set; }

		public string WrongAnswer3 { get; set; }

	}
}