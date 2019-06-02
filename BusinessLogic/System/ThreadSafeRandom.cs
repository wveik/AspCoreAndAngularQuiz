using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BusinessLogic.System
{
	public static class ThreadSafeRandom
	{
		[ThreadStatic]
		private static Random _local;

		public static Random ThisThreadsRandom => _local ?? (_local = new Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId)));
	}

	public static class MyExtensions
	{
		public static void Shuffle<T>(this IList<T> list)
		{
			var n = list.Count;
			while (n > 1)
			{
				n--;
				var k = ThreadSafeRandom.ThisThreadsRandom.Next(n + 1);
				T value = list[k];
				list[k] = list[n];
				list[n] = value;
			}
		}
	}
}
