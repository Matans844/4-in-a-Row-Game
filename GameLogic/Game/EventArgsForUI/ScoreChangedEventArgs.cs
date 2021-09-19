using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic
{
	public class ScoreChangedEventArgs : EventArgs
	{
		public int m_PlayerId;
		public int m_NewScore;
	}
}
