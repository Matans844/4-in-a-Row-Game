using System.Collections.Generic;
using System.Windows.Forms;

using Ex05.GameLogic;

namespace Ex05.FormsUserInterface
{
	public partial class FormGamePlay : Form
	{
		private readonly IPlayable m_PlayableGame;
		private readonly string r_Player1NameLabelText;
		private readonly string r_Player2NameLabelText;
		private readonly int r_BoardRows;
		private readonly int r_BoardColumns;
		private readonly GameSettings r_ChosenGameSettings;
		private bool m_NotSureAboutExit = true;
		private bool m_CloseUponExit = false;
		private List<LabelBoardColumn> r_BoardColumnLabels;

		public GameSettings ChosenGameSettings => this.r_ChosenGameSettings;

		public bool CloseUponExit
		{
			get => this.m_CloseUponExit;
			set => this.m_CloseUponExit = value;
		}

		public bool NotSureAboutExit
		{
			get => this.m_NotSureAboutExit;
			set => this.m_NotSureAboutExit = value;
		}

		public List<LabelBoardColumn> BoardColumnLabels => this.r_BoardColumnLabels;

		public int BoardColumns => this.r_BoardColumns;

		public int BoardRows => this.r_BoardRows;

		public string Player1NameLabelText => this.r_Player1NameLabelText;

		public string Player2NameLabelText => this.r_Player2NameLabelText;

		public IPlayable PlayableGame => this.m_PlayableGame;

		public FormGamePlay(GameSettings i_GameSettingsManager)
		{
			InitializeComponent();
			this.r_ChosenGameSettings = i_GameSettingsManager;
			this.r_Player1NameLabelText = $"{i_GameSettingsManager.Player1Name}:";
			this.r_Player2NameLabelText = $"{i_GameSettingsManager.Player2Name}:";
			this.r_BoardColumns = i_GameSettingsManager.ChosenNumberOfColumns;
			this.r_BoardRows = i_GameSettingsManager.ChosenNumberOfRows;
			this.r_BoardColumnLabels = new List<LabelBoardColumn>();

			this.m_PlayableGame = new ConnectFourGame(
				i_GameSettingsManager.ChosenNumberOfRows,
				i_GameSettingsManager.ChosenNumberOfColumns,
				i_GameSettingsManager.ChosenGameMode,
				i_GameSettingsManager.Player1Name,
				i_GameSettingsManager.Player2Name);

			this.initializeBoard();
			this.updateExistingPlayerInformationSection();
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
				this.PlayableGame.SetUpNewGame();
			}
			else
			{
				this.CloseUponExit = true;
				this.NotSureAboutExit = false;
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
			this.TableBoardCells.ColumnCount = this.BoardColumns;

			for (int columnIndex = 0; columnIndex < this.BoardColumns; columnIndex++)
			{
				LabelBoardColumn cellToAdd = new LabelBoardColumn(columnIndex, this.PlayableGame);
				this.TableRowOfColumnLabels.Controls.Add(cellToAdd, columnIndex, Board.k_ZeroIndex);
				this.BoardColumnLabels.Add(cellToAdd);
			}
		}

		private void boardCell_ComputerMadeMove(object sender, ComputerToMoveEventArgs e)
		{
			foreach (LabelBoardColumn labelColumn in this.BoardColumnLabels)
			{
				labelColumn.Enabled = true;
			}
		}

		private void updateExistingPlayerInformationSection()
		{
			this.LabelPlayer1Name.Text = this.r_Player1NameLabelText;
			this.LabelPlayer2Name.Text = this.r_Player2NameLabelText;
			this.LabelPlayer1Score.StartListening(this.PlayableGame);
			this.LabelPlayer2Score.StartListening(this.PlayableGame);
		}

		private void populateBoardCells()
		{
			this.TableBoardCells.RowCount = this.BoardRows;
			this.TableBoardCells.ColumnCount = this.BoardColumns;

			for (int rowIndex = 0; rowIndex < this.BoardRows; rowIndex++)
			{
				for (int columnIndex = 0; columnIndex < this.BoardColumns; columnIndex++)
				{
					ButtonBoardCell cellToAdd = new ButtonBoardCell(rowIndex, columnIndex, this.PlayableGame);
					this.TableBoardCells.Controls.Add(cellToAdd, columnIndex, rowIndex);
					cellToAdd.ComputerMadeMove += new ComputerAfterMoveEventHandler(this.boardCell_ComputerMadeMove);
				}
			}
		}

		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			if (!this.CloseUponExit)
			{
				this.PlayableGame.QuitSingleGameAndUpdateGameState();
			}

			if (this.NotSureAboutExit)
			{
				e.Cancel = true;
			}
		}
	}
}
