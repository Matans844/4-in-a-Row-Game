using System;

namespace GameLogic
{
	public abstract class Player
	{
		private static int s_InstanceCounter = 1;
		private readonly IPlayable r_GameForBoard;
		private readonly Board r_BoardOfPlayer;
		private readonly string r_PlayerId;
		private readonly eBoardCellType r_DiscType;
		private int m_PointsEarned = ConnectFourGame.k_ZeroPoints;
		private eTurnState m_TurnState;

		public IPlayable GameForBoard => this.r_GameForBoard;

		public Board BoardOfPlayer => this.r_BoardOfPlayer;

		public string PlayerID => this.r_PlayerId;

		public int PointsEarned
		{
			get => this.m_PointsEarned;
			set => this.m_PointsEarned = value;
		}

		public eBoardCellType DiscType => this.r_DiscType;

		public eTurnState TurnState
		{
			get => this.m_TurnState;
			set => this.m_TurnState = value;
		}

		protected Player(Board i_BoardOfPlayer, eBoardCellType i_DiscType, eTurnState i_TurnState)
		{
			this.r_DiscType = i_DiscType;
			this.r_BoardOfPlayer = i_BoardOfPlayer;
			this.TurnState = i_TurnState;
			this.r_PlayerId = $"Player {s_InstanceCounter}";
			s_InstanceCounter++;
		}

		public void PlayMove(int i_ChosenColumnAfterIndexAdjustment)
		{
			this.BoardOfPlayer.SlideDiskToBoard(this.ChooseColumnForMove(), this.DiscType);
		}

		public abstract int ChooseColumnForMove();
	}

	public enum ePlayerType
	{
		Human = 1,
		Computer = 2
	}

	public enum eTurnState
	{
		YourTurn = 1,
		NotYourTurn = 2
	}
}
