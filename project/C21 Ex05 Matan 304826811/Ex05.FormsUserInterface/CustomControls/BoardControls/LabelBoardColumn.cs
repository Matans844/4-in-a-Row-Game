﻿using System;
using System.Windows.Forms;
using System.Drawing;
using Ex05.GameLogic;

namespace Ex05.FormsUserInterface
{
	public class LabelBoardColumn : Label
	{
		private const float k_ButtonFontSize = 8f;
		private const int k_HeightOfCell = 25;
		private const int k_WidthOfCell = 50;
		private const int k_AllMargin = 5;
		private const int k_AllPadding = 5;
		private readonly IPlayable r_Game;
		private readonly int r_ColumnIndex;
		private bool m_IsBoardColumnFull;

		public bool IsBoardColumnFull
		{
			get => this.m_IsBoardColumnFull;
			private set => this.m_IsBoardColumnFull = value;
		}

		public IPlayable MyGame => this.r_Game;

		public int ColumnIndex => this.r_ColumnIndex;

		public LabelBoardColumn(int i_ColumnIndex, IPlayable i_Game)
			: base()
		{
			this.r_Game = i_Game;
			this.r_ColumnIndex = i_ColumnIndex;
			this.modifyButtonControl();
			this.startListening();
		}

		private void modifyButtonControl()
		{
			this.Text = $@"{this.ColumnIndex + Board.k_ConversionFactor1NumberToIndices}";
			this.Font = new Font(this.Font.FontFamily, k_ButtonFontSize);
			this.TextAlign = ContentAlignment.MiddleCenter;
			this.Margin = new System.Windows.Forms.Padding(k_AllMargin);
			this.Padding = new System.Windows.Forms.Padding(k_AllPadding);
			this.Size = new Size(k_WidthOfCell, k_HeightOfCell);
			this.Anchor = AnchorStyles.None;
			this.BorderStyle = BorderStyle.FixedSingle;
		}

		private void startListening()
		{
			Board connectedBoard = this.MyGame.GetBoard();
			connectedBoard.BoardColumnByIndexBecameFull += new BoardColumnByIndexBecameFullEventHandler(this.board_ColumnIsFull);
			connectedBoard.NewGameRequested += new Action(this.board_NewGameRequested);
			this.MyGame.ComputerToMove += new ComputerToMoveEventHandler(this.game_ComputerToMove);
		}

		private void board_NewGameRequested()
		{
			this.IsBoardColumnFull = false;
			this.Enabled = true;
		}

		private void game_ComputerToMove(object sender, ComputerToMoveEventArgs e)
		{
			if (e.m_MoveStatus.Equals(eMoveStatus.BeforeUIUpdate) && e.m_GameMode.Equals(eGameMode.PlayerVsComputer))
			{
				this.Enabled = false;
			}
		}

		private void board_ColumnIsFull(object sender, BoardColumnByIndexBecameFullEventArgs e)
		{
			if (this.ColumnIndex == e.m_FilledBoardColumnIndex)
			{
				this.IsBoardColumnFull = true;
				this.Enabled = false;
			}
		}

		protected override void OnClick(EventArgs e)
		{
			int chosenColumnByText = this.ColumnIndex + Board.k_ConversionFactor1NumberToIndices;
			this.MyGame.MakeValidMoveAndUpdateBoardAndGameState(chosenColumnByText);
		}
	}
}
