using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic
{
	public class Board
	{
		public const int k_TransformBoardToMatrixIndicesWith1 = 1;
		public const int k_ZeroIndex = 0;
		private readonly IPlayable r_GameForBoard;
		private readonly Cell[,] r_CellMatrix;
		private readonly int[] r_NumberOfCellVacanciesInColumn;
		private eBoardState m_BoardState = eBoardState.NotFinished;
		private int m_NumberOfRowIndices;
		private int m_NumberOfColumnIndices;
		private int m_NumberOfRows;
		private int m_NumberOfColumns;
		private int m_NumberOfCellVacanciesInBoard;

		public int NumberOfCellVacanciesInBoard
		{
			get => this.m_NumberOfCellVacanciesInBoard;
			set => this.m_NumberOfCellVacanciesInBoard = value;
		}

		public int NumberOfRowIndices
		{
			get => this.m_NumberOfRowIndices;
			set => this.m_NumberOfRowIndices = value;
		}

		public int NumberOfColumnIndices
		{
			get => this.m_NumberOfColumnIndices;
			set => this.m_NumberOfColumnIndices = value;
		}

		public IPlayable GameForBoard => this.r_GameForBoard;

		public eBoardState BoardState
		{
			get => this.m_BoardState;
			set => this.m_BoardState = value;
		}

		public int NumberOfRows
		{
			get => this.m_NumberOfRows;
			set => this.m_NumberOfRows = value;
		}

		public int NumberOfColumns
		{
			get => this.m_NumberOfColumns;
			set => this.m_NumberOfColumns = value;
		}

		public int[] NumberOfCellVacanciesInColumn => this.r_NumberOfCellVacanciesInColumn;

		public Cell[,] CellMatrix => this.r_CellMatrix;

		public Board(int i_ChosenNumberOfRows, int i_ChosenNumberOfColumns, IPlayable i_GameForBoard)
		{
			this.r_GameForBoard = i_GameForBoard;
			this.NumberOfColumns = i_ChosenNumberOfColumns;
			this.NumberOfColumnIndices = i_ChosenNumberOfColumns - k_TransformBoardToMatrixIndicesWith1;
			this.NumberOfRows = i_ChosenNumberOfRows;
			this.NumberOfRowIndices = i_ChosenNumberOfRows - k_TransformBoardToMatrixIndicesWith1;
			this.r_CellMatrix = new Cell[i_ChosenNumberOfRows, i_ChosenNumberOfColumns];
			this.NumberOfCellVacanciesInBoard = i_ChosenNumberOfRows * i_ChosenNumberOfColumns;
			this.r_NumberOfCellVacanciesInColumn = Enumerable.Repeat(i_ChosenNumberOfColumns, i_ChosenNumberOfRows).ToArray();
		}

		public void SlideDiskToBoard(int i_ChosenBoardColumnAdjustedForMatrix, eBoardCellType i_PlayerDiscType)
		{
			int rowIndexOfLastVacantCellInChosenColumn =
				this.NumberOfCellVacanciesInColumn[i_ChosenBoardColumnAdjustedForMatrix] - k_TransformBoardToMatrixIndicesWith1;

			this.NumberOfCellVacanciesInColumn[i_ChosenBoardColumnAdjustedForMatrix]--;
			this.NumberOfCellVacanciesInBoard--;

			this.CellMatrix[rowIndexOfLastVacantCellInChosenColumn, i_ChosenBoardColumnAdjustedForMatrix].CellType = i_PlayerDiscType;
		}

		public bool IsColumnAvailableForDisc(int i_ChosenColumnIndex)
		{
			int chosenColumnTranslatedToMatrixIndices = i_ChosenColumnIndex;
			bool isValidChoice = false;

			if (NumberOperations.ValueInRange(
				i_ChosenColumnIndex,
				k_ZeroIndex,
				this.NumberOfColumnIndices))
			{
				isValidChoice = this.NumberOfCellVacanciesInColumn[chosenColumnTranslatedToMatrixIndices] != 0;
			}

			return isValidChoice;
		}
	}

	public enum eBoardState
	{
		NotFinished = 0,
		FinishedInDraw = 1,
		FinishedInWinByBoard = 2,
		FinishedInWinByQuit = 3
	}
}