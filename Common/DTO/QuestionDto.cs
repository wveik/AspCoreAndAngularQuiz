using System;

namespace Common.DTO
{
	public class QuestionDto
	{
		public int Id { get; set; }

		public string Text { get; set; }

		public DateTime DateInsert { get; set; }

		public DateTime DateUpdate { get; set; }
	}
}