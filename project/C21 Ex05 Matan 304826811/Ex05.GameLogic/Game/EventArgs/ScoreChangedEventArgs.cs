using System;

namespace Ex05.GameLogic
{
	public class ScoreChangedEventArgs : EventArgs
	{
		public ePlayerNumber m_ChangedScorePlayerNumber;
		public int m_NewScore;
	}
}
