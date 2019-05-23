using System;

namespace DataAccessLayer.Entities
{
	public class Question
	{
		public int Id { get; set; }
		public string Text { get; set; }
		public DateTime DateInsert { get; set; }
		public DateTime DateUpdate { get; set; }
	}
}