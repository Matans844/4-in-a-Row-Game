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

		public Cell LastMovePlayed
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
	}

	public enum eGameMode
	{
		PlayerVsPlayer = 1,
		PlayerVsComputer = 2
	}
}
