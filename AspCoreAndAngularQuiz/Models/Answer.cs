using System;
using Common.DTO.Question;

namespace AspCoreAndAngularQuiz.Models
{
	[Serializable]
	public class Answer
	{
		public Answer(bool isRightAnswer, QuestionDTO question)
		{
			IsRightAnswer = isRightAnswer;
			Question = question;
		}

		public bool IsRightAnswer { get;}

		public QuestionDTO Question { get;}
	}
}
