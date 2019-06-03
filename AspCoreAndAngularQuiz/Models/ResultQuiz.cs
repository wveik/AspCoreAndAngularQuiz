namespace AspCoreAndAngularQuiz.Models
{
	public class ResultQuiz
	{
		public ResultQuiz(bool isWinner, int fullCountQuestion, int successCountQuestion)
		{
			IsWinner = isWinner;
			FullCountQuestion = fullCountQuestion;
			SuccessCountQuestion = successCountQuestion;
		}

		public bool IsWinner { get; }

		public int FullCountQuestion { get; }

		public int SuccessCountQuestion { get; }
	}
}
