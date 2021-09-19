using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic
{
	public class CellOccupiedByMoveEventArgs : EventArgs
	{
		public int m_CellRowIndex;
		public int m_CellColumnIndex;
		public eBoardCellType m_NewCellType;
	}
}
