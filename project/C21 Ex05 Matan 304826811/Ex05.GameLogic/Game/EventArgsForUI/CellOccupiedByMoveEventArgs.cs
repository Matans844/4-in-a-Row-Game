using System;

namespace Ex05.GameLogic
{
	public class CellOccupiedByMoveEventArgs : EventArgs
	{
		public int m_CellRowIndex;
		public int m_CellColumnIndex;
		public eBoardCellType m_NewCellType;
	}
}
