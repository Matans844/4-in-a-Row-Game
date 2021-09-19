using System;

namespace Ex05.GameLogic
{
	public class ScoreChangedEventArgs : EventArgs
	{
		public int m_PlayerId;
		public int m_NewScore;
	}
}
