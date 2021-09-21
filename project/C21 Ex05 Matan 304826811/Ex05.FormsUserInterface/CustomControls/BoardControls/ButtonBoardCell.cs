using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

using Ex05.GameLogic;

namespace Ex05.FormsUserInterface
{
	public delegate void ComputerAfterMoveEventHandler(object sender, ComputerToMoveEventArgs e);

	public class ButtonBoardCell : Button
	{
		public const string k_XDiscText = "X";
		public const string k_ODiscText = "O";
		private const int k_HeightOfCell = 50;
		private const int k_WidthOfCell = 50;
		private const int k_AllMargin = 5;
		private const int k_AllPadding = 5;
		private const float k_ButtonFontSize = 12f;
		private const int k_DelayInMilliSeconds = 80;
		private readonly string r_EmptyCellText = string.Empty;
		private readonly IPlayable r_Game;
		private readonly int r_RowIndex;
		private readonly int r_ColumnIndex;

		[Browsable(true)]
		[Category("Action")]
		[Description("Invoked when button finished loading computer move")]
		public event ComputerAfterMoveEventHandler ComputerMadeMove;

		public string EmptyCellText => this.r_EmptyCellText;

		public IPlayable MyGame => this.r_Game;

		public int RowIndex => this.r_RowIndex;

		public int ColumnIndex => this.r_ColumnIndex;

		public ButtonBoardCell(int i_RowIndex, int i_ColumnIndex, IPlayable i_Game)
			: base()
		{
			this.r_Game = i_Game;
			this.r_ColumnIndex = i_ColumnIndex;
			this.r_RowIndex = i_RowIndex;
			this.modifyButtonControl();
			this.startListening();
		}

		private void modifyButtonControl()
		{
			this.Enabled = false;
			this.Margin = new System.Windows.Forms.Padding(k_AllMargin);
			this.Padding = new System.Windows.Forms.Padding(k_AllPadding);
			this.Name = $"buttonR{this.RowIndex}C{this.ColumnIndex}";
			this.Text = this.EmptyCellText;
			this.Font = new Font(this.Font.FontFamily, k_ButtonFontSize);
			this.TextAlign = ContentAlignment.MiddleCenter;
			this.Size = new Size(k_WidthOfCell, k_HeightOfCell);
			this.Anchor = AnchorStyles.None;
		}

		private void startListening()
		{
			Cell connectedGameCell = this.MyGame.GetBoard().CellMatrix[this.RowIndex, this.ColumnIndex];
			connectedGameCell.CellTypeChanged += new CellOccupancyChangedEventHandler(this.boardCell_OccupancyChanged);
		}

		private void boardCell_OccupancyChanged(object sender, CellOccupancyChangedEventArgs e)
		{
			if (e.m_NewCellType.Equals(eBoardCellType.Empty))
			{
				this.Text = this.EmptyCellText;
			}
			else
			{
				if (e.m_PlayerType.Equals(ePlayerType.Computer))
				{
					EventExtensions.Delay(
						k_DelayInMilliSeconds,
						(o, a) => this.setTextAfterOccupancyChanged(e.m_NewCellType));
				}
				else
				{
					this.setTextAfterOccupancyChanged(e.m_NewCellType);
				}
			}
		}

		private void setTextAfterOccupancyChanged(eBoardCellType i_UpdatedCellType)
		{
			ComputerToMoveEventArgs e = new ComputerToMoveEventArgs();

			this.Text = i_UpdatedCellType.Equals(eBoardCellType.XDisc)
							? k_XDiscText
							: k_ODiscText;

			e.m_MoveStatus = eMoveStatus.AfterUIUpdate;
			this.OnComputerMadeMove(e);
		}

		protected virtual void OnComputerMadeMove(ComputerToMoveEventArgs e)
		{
			this.ComputerMadeMove?.Invoke(this, e);
		}
	}
}
