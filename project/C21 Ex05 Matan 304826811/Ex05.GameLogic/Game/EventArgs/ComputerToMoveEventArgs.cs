using System;

namespace Ex05.GameLogic
{
	public class ComputerToMoveEventArgs : EventArgs
	{
		public eGameMode m_GameMode;
		public eMoveStatus m_MoveStatus;
	}
}