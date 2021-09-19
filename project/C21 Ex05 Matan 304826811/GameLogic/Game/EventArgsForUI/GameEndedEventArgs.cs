using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic
{
	public class GameEndedEventArgs : EventArgs
	{
		public eGameState m_NewGameState;
		public string m_ResultMessage;
		public string m_ResultTitle;
	}
}