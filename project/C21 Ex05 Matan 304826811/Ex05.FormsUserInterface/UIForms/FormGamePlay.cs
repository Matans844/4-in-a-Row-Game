using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ex05.GameLogic;

namespace Ex05.FormsUserInterface
{
	public partial class FormGamePlay : Form, IParentable
	{
		private readonly IPlayable m_PlayableGame;
		private readonly GameSettings r_GameSettingsManager;
		private readonly string r_Player1NameLabelText;
		private readonly string r_Player2NameLabelText;

		public string Player1NameLabelText => this.r_Player1NameLabelText;

		public string Player2NameLabelText => this.r_Player2NameLabelText;

		public IPlayable PlayableGame => this.m_PlayableGame;

		public GameSettings GameSettingsManager => this.r_GameSettingsManager;

		public FormGamePlay(GameSettings i_GameSettingsManager)
		{
			this.InitializeComponent();
			this.r_GameSettingsManager = i_GameSettingsManager;
			this.r_Player1NameLabelText = $"{this.GameSettingsManager.Player1Name}:";
			this.r_Player2NameLabelText = $"{this.GameSettingsManager.Player2Name}:";

			this.m_PlayableGame = new ConnectFourGame(
				this.GameSettingsManager.ChosenNumberOfRows,
				this.GameSettingsManager.ChosenNumberOfColumns,
				this.GameSettingsManager.ChosenGameMode,
				this.GameSettingsManager.Player1Name,
				this.GameSettingsManager.Player2Name);
		}

		protected override void OnLoad(EventArgs i_EventArgs)
		{
			base.OnLoad(i_EventArgs);

			foreach (Control control in this.Controls)
			{
				if (control.HasProperty("ParentOfControl"))
				{
					control.SetProperty<IParentable>("ParentOfControl", this);
				}
			}
		}

		public IPlayable GetPlayableMember()
		{
			return this.PlayableGame;
		}

		public TableLayoutPanel GetBoardTable()
		{
			return this.TableBoardCells;
		}
	}
}
