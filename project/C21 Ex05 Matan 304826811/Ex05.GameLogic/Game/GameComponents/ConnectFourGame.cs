namespace Ex05.GameLogic
{
	using System;

	public delegate void GameEndedEventHandler(object sender, GameEndedEventArgs e);

	public class ConnectFourGame : IPlayable
	{
		public const int k_ZeroPoints = 0;
		public const string k_GameName = "4 in a Row !!";
		public const string k_DrawMessage = "Tie!!";
		public const string k_DrawTitle = "A Tie!";
		public const string k_WinTitle = "A Win!";
		public const string k_WinByQuitTitle = "A Win! (by Quit)";
		public const string k_AnotherRound = "Another Round?";
		private readonly object[] r_Players = new object[2];
		private readonly Board r_Board;
		private readonly Player r_Player1WithXs;
		private readonly Player r_Player2WithOs;
		private readonly eGameMode r_Mode;
		private eGameState m_GameState = eGameState.NotFinished;
		private Cell m_LastMovePlayed; // Needs update after move in game loop
		private Player m_WinnerOfLastGame;
		private Player m_PlayerToWinIfOtherQuit;
		private Player m_PlayerToMove;
		private int m_GameNumber;
		private bool m_PlayerToMoveQuitSingleGame = false;
		private string m_WinMessage;

		public event GameEndedEventHandler GameEnded;

		public string WinMessage
		{
			get => this.m_WinMessage;
			set => this.m_WinMessage = $"{value} Won!!";
		}

		public eGameState GameState
		{
			get => this.m_GameState;
			set
			{
				GameEndedEventArgs e = new GameEndedEventArgs();
				this.m_GameState = value;

				if (this.m_GameState != eGameState.NotFinished)
				{
					// Game finished
					e.m_NewGameState = value;

					switch (value)
					{
						case eGameState.FinishedInDraw:
							e.m_ResultTitle = k_DrawTitle;
							e.m_ResultMessage = $"{k_DrawMessage}{Environment.NewLine}{k_AnotherRound}";
							break;

						case eGameState.FinishedInWinByBoard:
							this.WinnerOfLastGame = this.PlayerToMove;
							e.m_ResultTitle = k_WinTitle;
							e.m_ResultMessage = $"{this.WinMessage}{Environment.NewLine}{k_AnotherRound}";
							break;

						case eGameState.FinishedInWinByQuit:
							this.WinnerOfLastGame = this.PlayerToWinIfOtherQuit;
							e.m_ResultTitle = k_WinByQuitTitle;
							e.m_ResultMessage = $"{this.WinMessage} (by Quit){Environment.NewLine}{k_AnotherRound}";
							break;
					}

					this.OnGameEnded(e);
				}
			}
		}

		public Player PlayerToWinIfOtherQuit
		{
			get => this.m_PlayerToWinIfOtherQuit;
			private set => this.m_PlayerToWinIfOtherQuit = value;
		}

		public Player PlayerToMove
		{
			get => this.m_PlayerToMove;
			private set
			{
				this.m_PlayerToMove = value;
				this.PlayerToWinIfOtherQuit = this.getOtherPlayer(value);
			}
		}

		public bool PlayerToMoveQuitSingleGame
		{
			get => this.m_PlayerToMoveQuitSingleGame;
			set => this.m_PlayerToMoveQuitSingleGame = value;
		}

		public Player WinnerOfLastGame
		{
			get => this.m_WinnerOfLastGame;
			set
			{
				this.m_WinnerOfLastGame = value;
				this.WinMessage = value.PlayerName;
			}
		}

		public int GameNumber
		{
			get => this.m_GameNumber;
			set => this.m_GameNumber = value;
		}

		public eGameMode Mode => this.r_Mode;

		public Player Player1WithXs => this.r_Player1WithXs;

		public Player Player2WithOs => this.r_Player2WithOs;

		public Board GameBoard => this.r_Board;

		public object[] PlayersInGame => this.r_Players;

		public Cell LastMove
		{
			get => this.m_LastMovePlayed;
			set => this.m_LastMovePlayed = value;
		}

		public ConnectFourGame(
			int i_NumberOfBoardRows,
			int i_NumberOfBoardColumns,
			eGameMode i_GameMode,
			string i_Player1Name,
			string i_Player2Name)
		{
			this.r_Mode = i_GameMode;
			this.r_Board = new Board(i_NumberOfBoardRows, i_NumberOfBoardColumns, this);
			this.r_Player1WithXs = new PlayerHuman(this, this.GameBoard, eBoardCellType.XDisc, eTurnState.YourTurn, i_Player1Name);
			this.GameNumber++;

			if (i_GameMode == eGameMode.PlayerVsPlayer)
			{
				this.r_Player2WithOs = new PlayerHuman(this, this.GameBoard, eBoardCellType.ODisc, eTurnState.NotYourTurn, i_Player2Name);
			}
			else
			{
				this.r_Player2WithOs = new PlayerComputer(this, this.GameBoard, eBoardCellType.ODisc, eTurnState.NotYourTurn, i_Player2Name);
			}

			this.PlayersInGame[0] = this.Player1WithXs;
			this.PlayersInGame[1] = this.Player2WithOs;
			this.PlayerToMove = this.Player1WithXs;
		}

		private Player getOtherPlayer(Player i_Player)
		{
			Player otherPlayer;

			if (i_Player.DiscType == eBoardCellType.XDisc)
			{
				otherPlayer = this.Player2WithOs;
			}
			else
			{
				otherPlayer = this.Player1WithXs;
			}

			return otherPlayer;
		}

		public Board GetBoard()
		{
			return this.GameBoard;
		}

		public void SetLastMove(int i_ChosenColumn)
		{
			this.LastMove = this.GameBoard.GetLastAvailableCellInGivenColumn(i_ChosenColumn);
		}

		public Cell GetLastMove()
		{
			return this.LastMove;
		}

		public string GetGameWinnerName()
		{
			return this.WinnerOfLastGame.ToString();
		}

		public void MakeValidMoveAndUpdateBoardAndGameState(int i_ChosenColumn)
		{
			this.PlayerToMove.PlayMove(i_ChosenColumn);
			this.updateGameState();

			if (!this.didLastMoveEndGame() && this.Mode.Equals(eGameMode.PlayerVsComputer))
			{
				this.PlayerToMove.PlayRandomMove();
				this.updateGameState();
			}
		}

		private bool didLastMoveEndGame()
		{
			return !this.GameState.Equals(eGameState.NotFinished);
		}

		public void QuitSingleGameAndUpdateGameState()
		{
			this.PlayerToMoveQuitSingleGame = true;
			this.updateGameState();
		}

		public bool IsMoveValid(int i_ChosenColumn)
		{
			int chosenMoveAdjustedToMatrix = i_ChosenColumn - Board.k_ConversionFactor1NumberToIndices;

			return this.GameBoard.IsColumnAvailableForDisc(chosenMoveAdjustedToMatrix);
		}

		public bool DidLastPlayerQuitSingleGame()
		{
			return this.PlayerToMoveQuitSingleGame;
		}

		// When GameState is changed to finished (draw, winByQuit, winByBoard), notification is sent to listeners.
		// If the game is finished in win, the GameState setter also updates the winner.
		private void updateGameState()
		{
			if (ResultChecker.IsGameFinished(this))
			{
				if (ResultChecker.IsGameFinishedByBoard(this))
				{
					if (ResultChecker.IsGameDrawnByBoard(this))
					{
						this.GameState = eGameState.FinishedInDraw;
					}
					else
					{
						this.GameState = eGameState.FinishedInWinByBoard;
						this.WinnerOfLastGame.PointsEarned++;
					}
				}
				else
				{
					// Game finished by quit
					this.GameState = eGameState.FinishedInWinByQuit;
					this.WinnerOfLastGame.PointsEarned++;
				}
			}
			else
			{
				// Game is not finished
				this.PlayerToMove.TurnState = eTurnState.NotYourTurn;
				this.switchPlayerTurn(); // switches players' turns
				this.PlayerToMove.TurnState = eTurnState.YourTurn;
			}
		}

		private void switchPlayerTurn()
		{
			// The setter in PlayerToMove also changes PlayerToWinIfOtherQuit
			this.PlayerToMove = this.PlayerToWinIfOtherQuit;
		}

		public void SetUpNewGame()
		{
			this.PlayerToMoveQuitSingleGame = false;
			this.GameBoard.OnNewGameRequested();
			this.GameState = eGameState.NotFinished;
			this.Player1WithXs.TurnState = eTurnState.YourTurn;
			this.Player2WithOs.TurnState = eTurnState.NotYourTurn;
			this.PlayerToMove = this.Player1WithXs;
			this.GameNumber++;
		}

		public eGameState GetGameState()
		{
			return this.GameState;
		}

		// TODO This loop should be in the UI??
/*		public StartGame()
		{
			int chosenValidBoardMoveAdjustedToMatrix;

			while (this.DidLastPlayerQuitSingleGame())
			{
				foreach (Player currentPlayer in this.PlayersInGame)
				{
					this.PlayerToMove = currentPlayer;
					currentPlayer.TurnState = eTurnState.YourTurn;
				}

			}

		}*/

		protected virtual void OnGameEnded(GameEndedEventArgs e)
		{
			this.GameEnded?.Invoke(this, e);
		}

		public override string ToString()
		{
			return k_GameName;
		}

		public string GetGameName()
		{
			return this.ToString();
		}

		public Player GetPlayerByDisc(eDiscType i_PlayerDiscType)
		{
			return i_PlayerDiscType == eDiscType.XDisc
						? this.Player1WithXs
						: this.Player2WithOs;
		}

		public Player GetPlayerByNumber(ePlayerNumber i_NumberOfPlayer)
		{
			return i_NumberOfPlayer == ePlayerNumber.Player1
						? this.Player1WithXs
						: this.Player2WithOs;
		}
	}

	public enum eGameMode
	{
		PlayerVsPlayer = 1,
		PlayerVsComputer = 2
	}

	public enum eGameState
	{
		NotFinished = 0,
		FinishedInDraw = 1,
		FinishedInWinByBoard = 2,
		FinishedInWinByQuit = 3
	}
}
