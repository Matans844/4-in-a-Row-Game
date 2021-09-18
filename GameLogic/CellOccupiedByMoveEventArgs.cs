using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic
{
	public class CellOccupiedByMoveEventArgs : EventArgs
	{
		public eBoardCellType m_NewCellType;
	}
}
