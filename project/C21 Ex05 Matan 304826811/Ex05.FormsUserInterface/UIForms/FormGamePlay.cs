﻿using System;
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
	using System.Diagnostics.Eventing.Reader;

	public partial class FormGamePlay : Form
	{
		private readonly IPlayable m_PlayableGame;
		private readonly string r_Player1NameLabelText;
		private readonly string r_Player2NameLabelText;
		private readonly int r_BoardRows;
		private readonly int r_BoardColumns;
		private bool m_AskBeforeExit = true;
		private bool m_CloseUponExit = false;

		public bool CloseUponExit
		{
			get => this.m_CloseUponExit;
			set => this.m_CloseUponExit = value;
		}

		public bool AskBeforeExit
		{
			get => this.m_AskBeforeExit;
			set => this.m_AskBeforeExit = value;
		}

		public int BoardColumns => this.r_BoardColumns;

		public int BoardRows => this.r_BoardRows;

		public string Player1NameLabelText => this.r_Player1NameLabelText;

		public string Player2NameLabelText => this.r_Player2NameLabelText;

		public IPlayable PlayableGame => this.m_PlayableGame;

		public FormGamePlay(GameSettings i_GameSettingsManager)
		{
			InitializeComponent();
			this.r_Player1NameLabelText = $"{i_GameSettingsManager.Player1Name}:";
			this.r_Player2NameLabelText = $"{i_GameSettingsManager.Player2Name}:";
			this.r_BoardColumns = i_GameSettingsManager.ChosenNumberOfColumns;
			this.r_BoardRows = i_GameSettingsManager.ChosenNumberOfRows;

			this.m_PlayableGame = new ConnectFourGame(
				i_GameSettingsManager.ChosenNumberOfRows,
				i_GameSettingsManager.ChosenNumberOfColumns,
				i_GameSettingsManager.ChosenGameMode,
				i_GameSettingsManager.Player1Name,
				i_GameSettingsManager.Player2Name);

			this.initializeBoard();
			this.updateExistingPlayerScoreLabelsWithPlayer();
			this.startListening();
		}

		private void startListening()
		{
			this.PlayableGame.GameEnded += new GameEndedEventHandler(this.game_SingleGameEnded);
		}

		private void game_SingleGameEnded(object sender, GameEndedEventArgs e)
		{
			DialogResult result = MessageBox.Show(e.m_ResultMessage, e.m_ResultTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Information);

			if (result == DialogResult.Yes)
			{
				this.AskBeforeExit = false;
				this.PlayableGame.SetUpNewGame();
			}
			else
			{
				this.CloseUponExit = true;
				this.Close();
			}
		}

		private void initializeBoard()
		{
			this.populateBoardCells();
			this.populateBoardColumnLabels();
		}

		private void populateBoardColumnLabels()
		{
			for (int columnIndex = 0; columnIndex < this.BoardColumns; columnIndex++)
			{
				LabelBoardColumn cellToAdd = new LabelBoardColumn(columnIndex, this.PlayableGame);
				this.TableRowOfColumnLabels.Controls.Add(cellToAdd, Board.k_ZeroIndex, columnIndex);
			}
		}

		private void updateExistingPlayerScoreLabelsWithPlayer()
		{
			this.LabelPlayer1Score.StartListening(this.PlayableGame);
			this.LabelPlayer2Score.StartListening(this.PlayableGame);
		}

		private void populateBoardCells()
		{
			for (int rowIndex = 0; rowIndex < this.BoardRows; rowIndex++)
			{
				for (int columnIndex = 0; columnIndex < this.BoardColumns; columnIndex++)
				{
					ButtonBoardCell cellToAdd = new ButtonBoardCell(rowIndex, columnIndex, this.PlayableGame);
					this.TableBoardCells.Controls.Add(cellToAdd, columnIndex, rowIndex);
				}
			}
		}

		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			if (!this.CloseUponExit)
			{
				this.PlayableGame.QuitSingleGameAndUpdateGameState();
			}

			if (!this.AskBeforeExit)
			{
				e.Cancel = true;
			}
		}
	}
}
