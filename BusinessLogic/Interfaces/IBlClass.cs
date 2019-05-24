using System;
using Common.DTO;

namespace BusinessLogic.Interfaces
{
	public interface IBlClass : IDisposable
	{
		void AddPlayer(PlayerDto element);
	}
}