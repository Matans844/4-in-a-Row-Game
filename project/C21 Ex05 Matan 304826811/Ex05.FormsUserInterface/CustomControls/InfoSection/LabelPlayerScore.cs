using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Ex05.GameLogic;

namespace Ex05.FormsUserInterface
{
	public sealed class LabelPlayerScore : Label
	{
		private ePlayerNumber m_PlayerNumber;

		public ePlayerNumber PlayerNumber
		{
			get => this.m_PlayerNumber;
			set => this.m_PlayerNumber = value;
		}

		public LabelPlayerScore()
			: base()
		{
		}

		public void StartListening(IPlayable i_GameInterface)
		{
			i_GameInterface.GetPlayerByNumber(this.PlayerNumber).ScoreChanged +=
				new ScoreChangedEventHandler(this.player_ScoreChanged);
		}

		private void player_ScoreChanged(object sender, ScoreChangedEventArgs e)
		{
			if (e.m_ChangedScorePlayerNumber.Equals(this.PlayerNumber))
			{
				this.Text = e.m_NewScore.ToString();
			}
		}
	}
}
