namespace Ex05.GameLogic
{
	public delegate void CellOccupancyChangedEventHandler(object sender, CellOccupancyChangedEventArgs e);

	public class Cell
	{
		private readonly int r_ColumnIndex;
		private readonly int r_RowIndex;
		private readonly IPlayable r_GameInterface;
		private eBoardCellType m_CellType;
		private eDiscType m_DiscType;

		public event CellOccupancyChangedEventHandler CellTypeChanged;

		public IPlayable GameInterface => r_GameInterface;

		public int ColumnIndex => this.r_ColumnIndex;

		public int RowIndex => this.r_RowIndex;

		public eDiscType DiscType
		{
			get => this.m_DiscType;
			private set => this.m_DiscType = value;
		}

		public eBoardCellType CellType
		{
			get => this.m_CellType;
			set
			{
				this.m_CellType = value;

				CellOccupancyChangedEventArgs e = new CellOccupancyChangedEventArgs
					{
						m_CellRowIndex = this.RowIndex,
						m_CellColumnIndex = this.ColumnIndex,
						m_NewCellType = value
					};

				if (!value.Equals(eBoardCellType.Empty))
				{
					this.DiscType = value.Equals(eBoardCellType.XDisc)
										? eDiscType.XDisc
										: eDiscType.ODisc;
					e.m_PlayerType = this.GameInterface.GetPlayerByDisc(this.DiscType).PlayerType;
				}

				this.OnCellOccupied(e);
			}
		}

		protected virtual void OnCellOccupied(CellOccupancyChangedEventArgs e)
		{
			this.CellTypeChanged?.Invoke(this, e);
		}

		public Cell(int i_RowIndex, int i_ColumnIndex, IPlayable i_GameInterface)
		{
			this.r_RowIndex = i_RowIndex;
			this.r_ColumnIndex = i_ColumnIndex;
			this.CellType = eBoardCellType.Empty;
			this.r_GameInterface = i_GameInterface;
		}

		public bool HasSameTypeAs(Cell i_AnotherBoardCell)
		{
			return this.CellType.Equals(i_AnotherBoardCell.CellType);
		}

		public bool HasSameTypeAs(params Cell[] i_OtherBoardCell)
		{
			bool hasSameType = true;
			bool areSameType;

			foreach (Cell disc in i_OtherBoardCell)
			{
				areSameType = this.HasSameTypeAs(disc);

				if (!areSameType)
				{
					hasSameType = false;
					break;
				}
			}

			return hasSameType;
		}

		public void Reset()
		{
			this.CellType = eBoardCellType.Empty;
		}
	}

	public enum eBoardCellType
	{
		Empty = 0,
		XDisc = 1,
		ODisc = 2
	}

	public enum eDiscType
	{
		XDisc = 1,
		ODisc = 2
	}
}
