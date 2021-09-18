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

		void UpdateAfterValidMove(int i_ChosenColumn);

		void UpdateAfterQuit();


		void SetUpNewGame();

		bool IsMoveValid(int i_ChosenColumn);
	}
}
