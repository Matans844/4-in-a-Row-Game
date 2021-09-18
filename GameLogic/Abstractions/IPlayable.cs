using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic
{
	public interface IPlayable
	{
		Board GetBoard();

		Cell GetLastMove();

		bool DidLastPlayerQuitSingleGame();

		eGameState GetGameState();

		void MakeValidMoveAndUpdateBoardAndGameState(int i_ChosenColumn);

		void QuitSingleGameAndUpdateGameState();

		void SetUpNewGame();

		bool IsMoveValid(int i_ChosenColumn);
	}
}
