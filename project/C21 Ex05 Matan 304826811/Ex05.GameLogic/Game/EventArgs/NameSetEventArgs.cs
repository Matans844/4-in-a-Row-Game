using System;

namespace Ex05.GameLogic
{
	public class NameSetEventArgs : EventArgs
	{
		public int m_PlayerId;
		public string m_NewName;
	}
}