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
		private readonly BoardSizeSettings r_BoardSizeSettingsManager;
		private readonly int r_WithoutBoardWindowWidth;
		private readonly int r_WithoutBoardWindowHeight;
		private readonly string r_Player1NameLabelText;
		private readonly string r_Player2NameLabelText;
		private int m_ModifiedWindowWidth;
		private int m_ModifiedWindowHeight;

		public string Player1NameLabelText => this.r_Player1NameLabelText;

		public string Player2NameLabelText => this.r_Player2NameLabelText;

		public int WithoutBoardWindowWidth => this.r_WithoutBoardWindowWidth;

		public int WithoutBoardWindowHeight => this.r_WithoutBoardWindowHeight;

		public int ModifiedWindowHeight
		{
			get => this.m_ModifiedWindowHeight;
			set => this.m_ModifiedWindowHeight = value;
		}

		public int ModifiedWindowWidth
		{
			get => this.m_ModifiedWindowWidth;
			set => this.m_ModifiedWindowWidth = value;
		}

		public IPlayable Game => this.r_Game;

		public GameSettings GameSettingsManager => this.r_GameSettingsManager;

		public BoardSizeSettings BoardSizeSettingsManager => this.r_BoardSizeSettingsManager;

		public FormGamePlay(GameSettings i_GameSettingsManager, BoardSizeSettings i_BoardSizeSettingsManager)
		{
			this.InitializeComponent();
			this.r_GameSettingsManager = i_GameSettingsManager;
			this.r_BoardSizeSettingsManager = i_BoardSizeSettingsManager;
			this.r_WithoutBoardWindowWidth = this.Size.Width;
			this.r_WithoutBoardWindowHeight = this.Size.Height;
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
			this.Size = new Size(this.BoardSizeSettingsManager.BoardWidth, this.BoardSizeSettingsManager.BoardHeight);
		}

		private void LabelScorePlayer1_Click(object sender, EventArgs e)
		{

		}

		private void LabelPlayer2Name_Click(object sender, EventArgs e)
		{

		}
	}
}
