using System;

namespace Common.Exceptions
{
	public class SystemException: Exception
	{
		public SystemException(string message) : base(message)
		{
		}
	}
}