﻿using System;

namespace Common.Exceptions
{
	public class LogicException : Exception
	{
		public LogicException(string message) : base(message)
		{
		}
	}
}