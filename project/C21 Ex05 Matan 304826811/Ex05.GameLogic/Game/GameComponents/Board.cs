using System;
using System.Linq;

namespace Ex05.GameLogic
{
	public delegate void BoardColumnByIndexBecameFullEventHandler(object sender, BoardColumnByIndexBecameFullEventArgs e);

	public class Board
	{
		public const int k_ConversionFactor1NumberToIndices = 1;
		public const int k_ZeroIndex = 0;
		private readonly IPlayable r_GameForBoard;
		private readonly Cell[,] r_CellMatrix;
		private readonly int[] r_NumberOfCellVacanciesByColumn;
		private readonly bool[] r_IsColumnFullArray;
		private int m_NumberOfRowIndices;
		private int m_NumberOfColumnIndices;
		private int m_NumberOfRows;
		private int m_NumberOfColumns;
		private int m_NumberOfCellVacanciesInBoard;

		public event Action NewGameRequested;

		public event BoardColumnByIndexBecameFullEventHandler BoardColumnByIndexBecameFull;

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

		public int[] NumberOfCellVacanciesByColumn => this.r_NumberOfCellVacanciesByColumn;

		public Cell[,] CellMatrix => this.r_CellMatrix;

		public bool[] IsColumnFullArrayArray => this.r_IsColumnFullArray;

		public Board(int i_ChosenNumberOfRows, int i_ChosenNumberOfColumns, IPlayable i_GameForBoard)
		{
			this.r_GameForBoard = i_GameForBoard;
			this.NumberOfColumns = i_ChosenNumberOfColumns;
			this.NumberOfColumnIndices = i_ChosenNumberOfColumns - k_ConversionFactor1NumberToIndices;
			this.NumberOfRows = i_ChosenNumberOfRows;
			this.NumberOfRowIndices = i_ChosenNumberOfRows - k_ConversionFactor1NumberToIndices;
			this.r_CellMatrix = new Cell[i_ChosenNumberOfRows, i_ChosenNumberOfColumns];
			this.r_CellMatrix.InitWithBoardCells(this.GameForBoard);
			this.NumberOfCellVacanciesInBoard = i_ChosenNumberOfRows * i_ChosenNumberOfColumns;

			this.r_NumberOfCellVacanciesByColumn = Enumerable.Repeat(i_ChosenNumberOfRows, i_ChosenNumberOfColumns).ToArray();

			this.r_IsColumnFullArray = Enumerable.Repeat(false, i_ChosenNumberOfColumns).ToArray();
		}

		public void SlideDiskToBoard(int i_ChosenBoardColumnAdjustedForMatrix, eBoardCellType i_PlayerDiscType)
		{
			int rowIndexOfLastVacantCellInChosenColumn =
				this.NumberOfCellVacanciesByColumn[i_ChosenBoardColumnAdjustedForMatrix] - k_ConversionFactor1NumberToIndices;

			this.NumberOfCellVacanciesByColumn[i_ChosenBoardColumnAdjustedForMatrix]--;
			this.NumberOfCellVacanciesInBoard--;

			if (!this.IsColumnAvailableForDisc(i_ChosenBoardColumnAdjustedForMatrix))
			{
				this.markColumnFull(i_ChosenBoardColumnAdjustedForMatrix);
			}

			this.CellMatrix[rowIndexOfLastVacantCellInChosenColumn, i_ChosenBoardColumnAdjustedForMatrix].CellType = i_PlayerDiscType;
		}

		private void markColumnFull(int i_FullColumnIndex)
		{
			this.IsColumnFullArrayArray[i_FullColumnIndex] = true;

			BoardColumnByIndexBecameFullEventArgs e = new BoardColumnByIndexBecameFullEventArgs
			{
				m_FilledBoardColumnIndex = i_FullColumnIndex
			};

			this.OnBoardColumnByIndexBecameFull(e);
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
				isValidChoice = this.NumberOfCellVacanciesByColumn[chosenColumnTranslatedToMatrixIndices] != 0;
			}

			return isValidChoice;
		}

		public Cell GetLastAvailableCellInGivenColumn(int i_ColumnIndex)
		{
			int availableRowIndexInColumn = this.NumberOfCellVacanciesByColumn[i_ColumnIndex] - k_ConversionFactor1NumberToIndices;

			return this.CellMatrix[availableRowIndexInColumn, i_ColumnIndex];
		}

		protected virtual void OnBoardColumnByIndexBecameFull(BoardColumnByIndexBecameFullEventArgs e)
		{
			this.BoardColumnByIndexBecameFull?.Invoke(this, e);
		}

		public void OnNewGameRequested()
		{
			this.NewGameRequested?.Invoke();
			this.resetCellMatrix();
			this.resetNumberOfCellVacanciesInBoard();
			this.resetNumberOfCellVacanciesByColumn();
			this.resetIsColumnAvailableForDisc();
		}

		private void resetCellMatrix()
		{
			this.CellMatrix.ResetBoardCells();
		}

		private void resetNumberOfCellVacanciesInBoard()
		{
			this.NumberOfCellVacanciesInBoard = this.NumberOfRows * this.NumberOfColumns;
		}

		private void resetNumberOfCellVacanciesByColumn()
		{
			int numberOfColumnsStartingFrom1 =
				this.NumberOfColumnIndices + Board.k_ConversionFactor1NumberToIndices;

			for (int i = 0; i < numberOfColumnsStartingFrom1; i++)
			{
				this.r_NumberOfCellVacanciesByColumn[i] = this.NumberOfRows;
			}
		}

		private void resetIsColumnAvailableForDisc()
		{
			int numberOfColumnsStartingFrom1 =
				this.NumberOfColumnIndices + Board.k_ConversionFactor1NumberToIndices;

			for (int i = 0; i < numberOfColumnsStartingFrom1; i++)
			{
				this.r_IsColumnFullArray[i] = false;
			}
		}
	}
}