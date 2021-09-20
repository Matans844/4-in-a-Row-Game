namespace Ex05.GameLogic
{
	// Used for communication inside the logic unit and with the UI unit.
	public interface IPlayable
	{
		event GameEndedEventHandler GameEnded;

		Board GetBoard();

		Cell GetLastMove();

		bool DidLastPlayerQuitSingleGame();

		eGameState GetGameState();

		string GetGameWinnerName();

		void MakeValidMoveAndUpdateBoardAndGameState(int i_ChosenColumn);

		void QuitSingleGameAndUpdateGameState();

		void SetUpNewGame();

		bool IsMoveValid(int i_ChosenColumn);

		string GetGameName();

		Player GetPlayerByDisc(eDiscType i_PlayerDiscType);

		Player GetPlayerByNumber(ePlayerNumber i_NumberOfPlayer);
	}
}
