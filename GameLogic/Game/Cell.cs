using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic
{
	public delegate void CellOccupiedByMoveEventHandler(object sender, CellOccupiedByMoveEventArgs e);

	public class Cell
	{
		private readonly int r_Column;
		private readonly int r_Row;
		private eBoardCellType m_CellType;

		public event CellOccupiedByMoveEventHandler CellTypeChanged;

		public int Column => this.r_Column;

		public int Row => this.r_Row;

		public eBoardCellType CellType
		{
			get => this.m_CellType;
			set
			{
				this.m_CellType = value;
				CellOccupiedByMoveEventArgs e = new CellOccupiedByMoveEventArgs { m_NewCellType = value };
				this.OnCellOccupied(e);
			}
		}

		protected virtual void OnCellOccupied(CellOccupiedByMoveEventArgs e)
		{
			if (this.CellTypeChanged != null)
			{
				this.CellTypeChanged(this, e);
			}
		}

		public Cell(int i_Row, int i_Column, eBoardCellType i_CellType)
		{
			this.r_Row = i_Row;
			this.r_Column = i_Column;
			this.CellType = i_CellType;
		}

		public Cell(int i_Row, int i_Column)
		{
			this.r_Row = i_Row;
			this.r_Column = i_Column;
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
