using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PresentationLayer.EF;

namespace PresentationLayer
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
