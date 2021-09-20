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
		public const string k_EmptyCell = "";
		public const string k_XDiscText = "X";
		public const string k_ODiscText = "O";
		private const int k_HeightOfCell = 40;
		private const int k_WidthOfCell = 40;
		private const float k_ButtonFontSize = 12f;
		private TableLayoutPanel m_TableForBoard;
		private IParentable m_ParentOfControl;
		private IPlayable m_Game;
		private int? m_RowIndex;
		private int? m_ColumnIndex;
		private bool m_CanSubscribe;

		public TableLayoutPanel TableForBoard
		{
			get => this.m_TableForBoard;
			set => this.m_TableForBoard = value;
		}

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
			}
		}

		public int? RowIndex
		{
			get => this.m_RowIndex;
			set
			{
				this.m_RowIndex = value;

				if (this.ColumnIndex.HasValue)
				{
					this.CanSubscribe = true;
				}
			}
		}

		public int? ColumnIndex
		{
			get => this.m_ColumnIndex;
			set
			{
				this.m_ColumnIndex = value;

				if (this.RowIndex.HasValue)
				{
					this.CanSubscribe = true;
				}
			}
		}

		public bool CanSubscribe
		{
			get => this.m_CanSubscribe;
			private set
			{
				this.m_CanSubscribe = value;
				this.addToTableBoard();
				this.startListening();
			}
		}

		public ButtonBoardCell()
			: base()
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
			Cell connectedCell = this.Game.GetBoard().CellMatrix[this.RowIndex.GetValueOrDefault(), this.ColumnIndex.GetValueOrDefault()];
			connectedCell.CellTypeChanged += new CellOccupiedByMoveEventHandler(this.boardCell_DiscEntered)
		}

		private void addToTableBoard()
		{
			this.TableForBoard = this.ParentOfControl.GetBoardTable();
			this.TableForBoard.Controls.Add(this, this.m_ColumnIndex.GetValueOrDefault(), this.RowIndex.GetValueOrDefault());
		}

		private void boardCell_DiscEntered(object sender, CellOccupiedByMoveEventArgs e)
		{
			this.Text = e.m_NewCellType == eBoardCellType.XDisc
							? k_XDiscText
							: k_ODiscText;
		}
	}
}
