using System;
using System.Windows.Forms;

using Ex05.GameLogic;

namespace Ex05.FormsUserInterface
{
	public partial class FormGameSetup : Form
	{
		private const string k_MessageMissingFields = "Some fields are missing!";
		private const string k_TitleError = "Error";
		private const string k_DefaultComputerLabelText = "[Computer]";
		private const string k_DefaultComputerName = "Computer";
		private readonly GameSettings r_GameSettingsManager = new GameSettings();
		private bool m_IsComputerGameMode = true;
		private eGameMode m_ChosenGameMode = eGameMode.PlayerVsComputer;

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
			InitializeComponent();
		}

		private void CheckBoxHumanOpponent_CheckedChanged(object sender, EventArgs e)
		{
			this.TextBoxPlayer2ChooseName.ReadOnly = !this.TextBoxPlayer2ChooseName.ReadOnly;
			this.TextBoxPlayer2ChooseName.Enabled = !this.TextBoxPlayer2ChooseName.Enabled;

			this.TextBoxPlayer2ChooseName.Text = this.TextBoxPlayer2ChooseName.ReadOnly
											? k_DefaultComputerLabelText
											: string.Empty;
			this.IsComputerGameMode = !this.IsComputerGameMode;
		}

		private void StartButton_Click(object sender, EventArgs e)
		{
			int chosenNumberOfBoardRows;
			int chosenNumberOfBoardColumns;

			bool allFieldsNotEmpty = !string.IsNullOrEmpty(this.TextBoxPlayer1ChooseName.Text)
									&& !string.IsNullOrEmpty(this.TextBoxPlayer2ChooseName.Text)
									&& !string.IsNullOrWhiteSpace(this.TextBoxPlayer1ChooseName.Text)
									&& !string.IsNullOrWhiteSpace(this.TextBoxPlayer2ChooseName.Text);

			if (allFieldsNotEmpty)
			{
				chosenNumberOfBoardRows = (int)this.NumericUpDownChooseNumberOfRows.Value;
				chosenNumberOfBoardColumns = (int)this.NumericUpDownChooseNumberOfColumns.Value;

				this.ChosenGameMode = this.IsComputerGameMode
										? eGameMode.PlayerVsComputer
										: eGameMode.PlayerVsPlayer;

				this.GameSettingsManager.Player1Name = this.TextBoxPlayer1ChooseName.Text;

				this.GameSettingsManager.Player2Name = this.ChosenGameMode == eGameMode.PlayerVsComputer
															? k_DefaultComputerName
															: this.TextBoxPlayer2ChooseName.Text;

				this.GameSettingsManager.RowsForGame = chosenNumberOfBoardRows;
				this.GameSettingsManager.ColumnsForGame = chosenNumberOfBoardColumns;
				this.GameSettingsManager.ModeForGame = this.ChosenGameMode;

				if (this.GameSettingsManager.CanGameBegin())
				{
					this.DialogResult = DialogResult.OK;
					this.Close();
				}
				else
				{
					this.errorOccurred();
				}
			}
			else
			{
				this.errorOccurred();
			}
		}

		private void errorOccurred()
		{
			MessageBox.Show(k_MessageMissingFields, k_TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}
}
