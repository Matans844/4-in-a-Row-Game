using System;

namespace Ex05.GameLogic
{
	public class CellOccupancyChangedEventArgs : EventArgs
	{
		public ePlayerType m_PlayerType;
		public int m_CellRowIndex;
		public int m_CellColumnIndex;
		public eBoardCellType m_NewCellType;
	}
}
