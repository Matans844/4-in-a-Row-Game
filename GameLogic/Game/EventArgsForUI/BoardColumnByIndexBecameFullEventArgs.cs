using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic
{
	public class BoardColumnByIndexBecameFullEventArgs : EventArgs
	{
		public int m_FilledBoardColumnIndex;
	}
}
