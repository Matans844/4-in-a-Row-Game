﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic
{
	public class GameStateChangedEventArgs : EventArgs
	{
		public eGameState m_NewGameState;
	}
}