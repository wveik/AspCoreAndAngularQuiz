using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DTO.Quiz
{
	public class ResponseQuizDTO
	{
		public QuizDTO Quiz { get; set; }

		public bool IsFinished { get; set; }

		public bool HasNext { get; set; }

		public bool IsVictory { get; set; }
	}
}
