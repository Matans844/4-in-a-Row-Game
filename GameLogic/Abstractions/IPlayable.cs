using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic
{
	public interface IPlayable
	{
		// Used for communication inside Logic unit
		Board GetBoard();

		// Used for communication inside Logic unit
		Cell GetLastMove();

		// From here onwards, used for communication with UI
		bool DidLastPlayerQuitSingleGame();

		eGameState GetGameState();

		void MakeValidMoveAndUpdateBoardAndGameState(int i_ChosenColumn);

		void QuitSingleGameAndUpdateGameState();

		void SetUpNewGame();

		bool IsMoveValid(int i_ChosenColumn);
	}
}
