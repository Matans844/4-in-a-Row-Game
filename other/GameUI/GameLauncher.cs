using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameUI
{
	public class GameLauncher
	{
		private readonly FormSetupGame r_SetupGame;
		private FormConnectFourGame m_FormConnectFourGame;

		public GameLauncher()
		{
			r_SetupGame = new FormSetupGame();
		}
	}
}
