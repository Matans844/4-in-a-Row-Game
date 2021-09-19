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
		private IPlayable m_Game;
		private ePlayerNumber m_PlayerNumber;

		public IPlayable Game
		{
			get => this.m_Game;
			set => this.m_Game = value;
		}

		public ePlayerNumber PlayerNumber
		{
			get => this.m_PlayerNumber;
			set => this.m_PlayerNumber = value;
		}

		public LabelPlayerScore()
			: base()
		{
		}

		private void startListening()
		{
			this.Game.GetPlayerByNumber(PlayerNumber).ScoreChanged +=
				new ScoreChangedEventHandler(this.player_ScoreChanged);
		}

		public UpdateFields(IPlayable i_Game, ePlayerNumber i_PlayerNumber)
		{
			this.Game = i_Game;
			this.PlayerNumber = i_PlayerNumber;
			this.startListening();
		}

		private void player_ScoreChanged(object sender, ScoreChangedEventArgs e)
		{
			this.Text = e.m_NewScore.ToString();
		}
	}
}
