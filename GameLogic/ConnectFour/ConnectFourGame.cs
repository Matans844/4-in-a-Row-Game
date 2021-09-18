using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic
{
	using System.Diagnostics.Eventing.Reader;

	public class ConnectFourGame : IPlayable
	{
		public const int k_ZeroPoints = 0;
		private readonly object[] r_Players = new object[2];
		private readonly Board r_Board;
		private readonly Player r_Player1WithXs;
		private readonly Player r_Player2WithOs;
		private readonly eGameMode r_Mode;
		private Cell m_LastMovePlayed; // Needs update after move in game loop
		private int m_GameNumber;
		private eGameState m_GameState = eGameState.NotFinished;
		private Player m_WinnerOfLastGame;
		private Player m_PlayerToWinIfOtherQuit;
		private Player m_PlayerToMove;
		private bool m_PlayerToMoveQuit = false;

		public eGameState GameState
		{
			get => this.m_GameState;
			set => this.m_GameState = value;
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

		public bool PlayerToMoveQuit
		{
			get => this.m_PlayerToMoveQuit;
			set => this.m_PlayerToMoveQuit = value;
		}

		public Player WinnerOfLastGame
		{
			get => this.m_WinnerOfLastGame;
			set => this.m_WinnerOfLastGame = value;
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

		public ConnectFourGame(int i_NumberOfBoardRows, int i_NumberOfBoardColumns, eGameMode i_GameMode)
		{
			this.r_Mode = i_GameMode;
			this.r_Board = new Board(i_NumberOfBoardRows, i_NumberOfBoardColumns, this);
			this.r_Player1WithXs = new PlayerHuman(this.GameBoard, eBoardCellType.XDisc, eTurnState.YourTurn);
			this.GameNumber++;

			if (i_GameMode == eGameMode.PlayerVsPlayer)
			{
				this.r_Player2WithOs = new PlayerHuman(this.GameBoard, eBoardCellType.ODisc, eTurnState.NotYourTurn);
			}
			else
			{
				this.r_Player2WithOs = new PlayerComputer(this.GameBoard, eBoardCellType.ODisc, eTurnState.NotYourTurn);
			}

			this.PlayersInGame[0] = this.Player1WithXs;
			this.PlayersInGame[1] = this.Player2WithOs;
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

		public Cell GetLastMove()
		{
			return this.LastMove;
		}

		public void UpdateAfterValidMove(int i_ChosenColumn)
		{
			int chosenMoveAdjustedToMatrix = i_ChosenColumn - Board.k_TransformBoardToMatrixIndicesWith1;
			this.LastMove = this.GameBoard.GetLastAvailableCellInColumn(chosenMoveAdjustedToMatrix);
			this.PlayerToMove.PlayMove(chosenMoveAdjustedToMatrix);
			this.updateGameState();
		}

		public void UpdateAfterQuit()
		{
			this.PlayerToMoveQuit = true;
			this.updateGameState();
		}

		public bool IsMoveValid(int i_ChosenColumn)
		{
			int chosenMoveAdjustedToMatrix = i_ChosenColumn - Board.k_TransformBoardToMatrixIndicesWith1;

			return this.GameBoard.IsColumnAvailableForDisc(chosenMoveAdjustedToMatrix);
		}

		public bool DidLastPlayerQuit()
		{
			return this.PlayerToMoveQuit;
		}

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
						this.WinnerOfLastGame = this.PlayerToMove;
						this.WinnerOfLastGame.PointsEarned++;
					}
				}
				else
				{
					// Game finished by quit
					this.GameState = eGameState.FinishedInWinByQuit;
					this.WinnerOfLastGame = this.PlayerToWinIfOtherQuit;
					this.WinnerOfLastGame.PointsEarned++;
				}
			}
			else
			{
				// Game is not finished
				this.PlayerToMove.TurnState = eTurnState.NotYourTurn;
				this.switchPlayerTurn(); // switches players
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
			this.GameBoard.PrepareBoardForNewGame();
			this.Player1WithXs.TurnState = eTurnState.YourTurn;
			this.Player2WithOs.TurnState = eTurnState.NotYourTurn;
			this.PlayerToMove = this.Player1WithXs;
		}

		// TODO This loop should be in the UI??
		public StartGame()
		{
			int chosenValidBoardMoveAdjustedToMatrix;

			while (this.DidLastPlayerQuit())
			{
				foreach (Player currentPlayer in this.PlayersInGame)
				{
					this.PlayerToMove = currentPlayer;
					currentPlayer.TurnState = eTurnState.YourTurn;
				}

			}

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
