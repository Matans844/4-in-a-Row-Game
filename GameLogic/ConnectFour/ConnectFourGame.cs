using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic
{
	public class ConnectFourGame : IPlayable
	{
		public const int k_ZeroPoints = 0;
		private readonly object[] r_Players = new object[2];
		private readonly Board r_Board;
		private readonly Player r_Player1WithXs;
		private readonly Player r_Player2WithOs;
		private readonly eGameMode r_Mode;
		private Cell m_LastMovePlayed;
		private int m_GameNumber;
		private Player m_PlayerToWinInCaseOfQuit;
		private Player m_WinnerOfLastGame;
		private Player m_PlayerToWinIfOtherQuit;
		private Player m_PlayerToMove;
		private bool m_PlayerToMoveQuit = false;

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
				this.PlayerToWinIfOtherQuit = getOtherPlayer(value);
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

		public Player PlayerToWinInCaseOfQuit
		{
			get => this.m_PlayerToWinInCaseOfQuit;
			set => this.m_PlayerToWinInCaseOfQuit = value;
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

		public bool DidLastPlayerQuit()
		{
			return this.PlayerToMoveQuit;
		}

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
}
