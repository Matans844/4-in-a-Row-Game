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
		private IParentable m_ParentOfControl;
		private IPlayable m_Game;
		private ePlayerNumber m_PlayerNumber;

		public IParentable ParentOfControl
		{
			get => this.m_ParentOfControl;
			set
			{
				this.m_ParentOfControl = value;
				this.Game = this.ParentOfControl.GetPlayableMember();
			}
		}

		public IPlayable Game
		{
			get => this.m_Game;
			set
			{
				this.m_Game = value;
				this.startListening();
			}
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
			this.Game.GetPlayerByNumber(this.PlayerNumber).ScoreChanged +=
				new ScoreChangedEventHandler(this.player_ScoreChanged);
		}

		private void player_ScoreChanged(object sender, ScoreChangedEventArgs e)
		{
			this.Text = e.m_NewScore.ToString();
		}
	}
}
