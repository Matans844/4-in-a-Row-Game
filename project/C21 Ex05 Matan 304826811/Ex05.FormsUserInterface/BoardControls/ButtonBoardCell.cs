using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Ex05.GameLogic;

namespace Ex05.FormsUserInterface
{
	public sealed class ButtonBoardCell : Button
	{
		public const string k_EmptyCell = String.Empty;
		public const string k_XDiscText = "X";
		public const string k_ODiscText = "O";
		private const int k_HeightOfCell = 40;
		private const int k_WidthOfCell = 40;
		private const float k_ButtonFontSize = 12f;
		private readonly IPlayable r_Game;
		private readonly int r_RowIndex;
		private readonly int r_ColumnIndex;

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
			this.Text = k_EmptyCell;
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
			switch (e.m_NewCellType)
			{
				case eBoardCellType.XDisc:
					this.Text = k_XDiscText;
					break;

				case eBoardCellType.ODisc:
					this.Text = k_ODiscText;
					break;

				case eBoardCellType.Empty:
					this.Text = k_EmptyCell;
					break;
			}
		}
	}
}
