using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic
{
	public interface IPlayable
	{
		bool DidLastPlayerQuit();

		Board GetBoard();

		Cell GetLastMove();
	}
}
