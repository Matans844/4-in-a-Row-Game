namespace Ex05.GameLogic
{
	public delegate void ScoreChangedEventHandler(object sender, ScoreChangedEventArgs e);

	public delegate void NameSetEventHandler(object sender, NameSetEventArgs e);

	public abstract class Player
	{
		private static int s_InstanceCounter = 1;
		private readonly IPlayable r_GameForBoard;
		private readonly Board r_BoardOfPlayer;
		private readonly int r_PlayerId;
		private readonly eBoardCellType r_DiscType;
		private string m_PlayerName;
		private int m_PointsEarned = ConnectFourGame.k_ZeroPoints;
		private eTurnState m_TurnState;

		public event ScoreChangedEventHandler ScoreChanged;

		public event NameSetEventHandler NameSet;

		public IPlayable GameForBoard => this.r_GameForBoard;

		public Board BoardOfPlayer => this.r_BoardOfPlayer;

		public int PlayerID => this.r_PlayerId;

		public string PlayerName
		{
			get => this.m_PlayerName;
			set
			{
				this.m_PlayerName = value;

				NameSetEventArgs e = new NameSetEventArgs
					{
						m_PlayerId = this.PlayerID,
						m_NewName = value
					};

				this.OnNameSet(e);
			}
		}

		public int PointsEarned
		{
			get => this.m_PointsEarned;
			set
			{
				this.m_PointsEarned = value;

				ScoreChangedEventArgs e = new ScoreChangedEventArgs
					{
						m_PlayerId = this.PlayerID,
						m_NewScore = value
					};

				this.OnScoreChanged(e);
			}
		}

		public eBoardCellType DiscType => this.r_DiscType;

		public eTurnState TurnState
		{
			get => this.m_TurnState;
			set => this.m_TurnState = value;
		}

		protected Player(Board i_BoardOfPlayer, eBoardCellType i_DiscType, eTurnState i_TurnState, string i_PlayerName)
		{
			this.r_DiscType = i_DiscType;
			this.r_BoardOfPlayer = i_BoardOfPlayer;
			this.TurnState = i_TurnState;
			this.PlayerName = i_PlayerName;
			this.r_PlayerId = s_InstanceCounter;
			s_InstanceCounter++;
		}

		public void PlayMove()
		{
			this.BoardOfPlayer.SlideDiskToBoard(this.ChooseColumnForMove(), this.DiscType);
		}

		public abstract int ChooseColumnForMove();

		protected virtual void OnScoreChanged(ScoreChangedEventArgs e)
		{
			this.ScoreChanged?.Invoke(this, e);
		}

		protected virtual void OnNameSet(NameSetEventArgs e)
		{
			this.NameSet?.Invoke(this, e);
		}

		public override string ToString()
		{
			return this.PlayerName;
		}
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
