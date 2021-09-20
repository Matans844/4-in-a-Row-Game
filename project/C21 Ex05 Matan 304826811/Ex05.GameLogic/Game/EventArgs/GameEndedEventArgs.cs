using System;

namespace Ex05.GameLogic
{
	public class GameEndedEventArgs : EventArgs
	{
		public eGameState m_NewGameState;
		public string m_ResultMessage;
		public string m_ResultTitle;
	}
}