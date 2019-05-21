using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer.EF;

namespace DataAccessLayer
{
	public class Class1
	{
		public void Test()
		{
			var db = new Context();
			var array = db.Players.ToArray();
			array.ToString();
		}
	}
}
