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
	public partial class FormGameSetup : Form
	{
		private const string k_MessageMissingFields = "Some fields are missing!";
		private const string k_TitleError = "Error";
		private const string k_DefaultComputerName = "[Computer]";
		private readonly BoardSizeSettings r_BoardSizeSettingManager;
		private readonly GameSettings r_GameSettingsManager;
		private bool m_IsComputerGameMode = true;
		private eGameMode m_ChosenGameMode = eGameMode.PlayerVsComputer;

		public BoardSizeSettings BoardSizeManager => this.r_BoardSizeSettingManager;

		public GameSettings GameSettingsManager => this.r_GameSettingsManager;

		public eGameMode ChosenGameMode
		{
			get => this.m_ChosenGameMode;
			private set => this.m_ChosenGameMode = value;
		}

		public bool IsComputerGameMode
		{
			get => this.m_IsComputerGameMode;
			private set
			{
				this.m_IsComputerGameMode = value;

				this.m_ChosenGameMode = value
											? eGameMode.PlayerVsComputer
											: eGameMode.PlayerVsPlayer;
			}
		}

		public FormGameSetup()
		{
			this.InitializeComponent();
			this.r_BoardSizeSettingManager = new BoardSizeSettings();
			this.r_GameSettingsManager = new GameSettings();
		}

		private void HumanOpponent_CheckedChanged(object sender, EventArgs e)
		{
			this.Player2ChosenName.ReadOnly = !this.Player2ChosenName.ReadOnly;

			this.Player2ChosenName.Text = this.Player2ChosenName.ReadOnly
											? k_DefaultComputerName
											: string.Empty;
			this.IsComputerGameMode = !this.IsComputerGameMode;
		}
	}
}
