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
	public partial class FormGamePlay : Form
	{
		private readonly IPlayable r_Game;
		private readonly GameSettings r_GameSettingsManager;
		private readonly string r_Player1NameLabelText;
		private readonly string r_Player2NameLabelText;

		public string Player1NameLabelText => this.r_Player1NameLabelText;

		public string Player2NameLabelText => this.r_Player2NameLabelText;

		public IPlayable Game => this.r_Game;

		public GameSettings GameSettingsManager => this.r_GameSettingsManager;

		public FormGamePlay(GameSettings i_GameSettingsManager)
		{
			this.InitializeComponent();
			this.r_GameSettingsManager = i_GameSettingsManager;
			this.r_Player1NameLabelText = $"{this.GameSettingsManager.Player1Name}:";
			this.r_Player2NameLabelText = $"{this.GameSettingsManager.Player2Name}:";

			this.r_Game = new ConnectFourGame(
				this.GameSettingsManager.ChosenNumberOfRows,
				this.GameSettingsManager.ChosenNumberOfColumns,
				this.GameSettingsManager.ChosenGameMode,
				this.GameSettingsManager.Player1Name,
				this.GameSettingsManager.Player2Name);
		}

		protected override void OnLoad(EventArgs i_EventArgs)
		{
			base.OnLoad(i_EventArgs);
			this.LabelPlayer1Name.Text = this.Player1NameLabelText;
			this.LabelPlayer2Name.Text = this.Player2NameLabelText;
		}

		private void FormGamePlay_Load(object sender, EventArgs e)
		{

		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{

		}

		private void LabelPlayer1Name_Click(object sender, EventArgs e)
		{

		}
	}
}
