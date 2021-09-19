using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic
{
	public delegate void CellOccupiedByMoveEventHandler(object sender, CellOccupiedByMoveEventArgs e);

	public class Cell
	{
		private readonly int r_ColumnIndex;
		private readonly int r_RowIndex;
		private eBoardCellType m_CellType;

		public event CellOccupiedByMoveEventHandler CellTypeChanged;

		public int ColumnIndex => this.r_ColumnIndex;

		public int RowIndex => this.r_RowIndex;

		public eBoardCellType CellType
		{
			get => this.m_CellType;
			set
			{
				this.m_CellType = value;

				CellOccupiedByMoveEventArgs e = new CellOccupiedByMoveEventArgs
					{
						m_CellRowIndex = this.RowIndex,
						m_CellColumnIndex = this.ColumnIndex,
						m_NewCellType = value
					};

				this.OnCellOccupied(e);
			}
		}

		protected virtual void OnCellOccupied(CellOccupiedByMoveEventArgs e)
		{
			this.CellTypeChanged?.Invoke(this, e);
		}

		public Cell(int i_RowIndex, int i_ColumnIndex, eBoardCellType i_CellType)
		{
			this.r_RowIndex = i_RowIndex;
			this.r_ColumnIndex = i_ColumnIndex;
			this.CellType = i_CellType;
		}

		public Cell(int i_RowIndex, int i_ColumnIndex)
		{
			this.r_RowIndex = i_RowIndex;
			this.r_ColumnIndex = i_ColumnIndex;
			this.CellType = eBoardCellType.Empty;
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
}
