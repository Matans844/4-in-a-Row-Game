using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic
{
	public static class ResultChecker
	{
		private const int k_DistanceBetweenWeightsInJaggedArray = 3;
		private const int k_NumberOfWeightPairs = 3;

		private static readonly int[][] sr_IndexWeightsForChangeByDiscIndexOfConnection = new int[4][]
			{
				new int[3] { 1, 2, 3 }, new int[3] { -1, 1, 2 }, new int[3] { -1, 1, -2 }, new int[3] { -1, -2, -3 }
			};

		private static readonly int[][] sr_IndexWeightsForNegativeChangeByDiscIndexOfConnection = new int[4][]
			{
				new int[3] { -1, -2, -3 }, new int[3] { 1, -1, -2 }, new int[3] { 1, -1, 2 }, new int[3] { 1, 2, 3 }
			};

		private static readonly int[][] sr_EmptyIndexWeights = new int[4][]
			{
				new int[3], new int[3], new int[3], new int[3]
			};

		private static readonly int[][] sr_IndexWeightsForHorizontalConnections =
			JaggedArray2DimOperations.HorizontalConcatInsideJaggedArray(
				EmptyIndexWeights,
				IndexWeightsForChangeByDiscIndexOfConnection);

		private static readonly int[][] sr_IndexWeightsForVerticalConnections =
			JaggedArray2DimOperations.HorizontalConcatInsideJaggedArray(
				IndexWeightsForChangeByDiscIndexOfConnection,
				EmptyIndexWeights);

		private static readonly int[][] sr_IndexWeightsForDiagonalNegativeSlope =
			JaggedArray2DimOperations.HorizontalConcatInsideJaggedArray(
				IndexWeightsForChangeByDiscIndexOfConnection,
				IndexWeightsForChangeByDiscIndexOfConnection);

		private static readonly int[][] sr_IndexWeightsForDiagonalPositiveSlope =
			JaggedArray2DimOperations.HorizontalConcatInsideJaggedArray(
				IndexWeightsForNegativeChangeByDiscIndexOfConnection,
				IndexWeightsForChangeByDiscIndexOfConnection);

		public static int[][] IndexWeightsForChangeByDiscIndexOfConnection => sr_IndexWeightsForChangeByDiscIndexOfConnection;

		public static int[][] IndexWeightsForNegativeChangeByDiscIndexOfConnection => sr_IndexWeightsForNegativeChangeByDiscIndexOfConnection;

		public static int[][] EmptyIndexWeights => sr_EmptyIndexWeights;

		public static int[][] IndexWeightsForHorizontalConnections => sr_IndexWeightsForHorizontalConnections;

		public static int[][] IndexWeightsForVerticalConnections => sr_IndexWeightsForVerticalConnections;

		public static int[][] IndexWeightsForDiagonalNegativeSlope => sr_IndexWeightsForDiagonalNegativeSlope;

		public static int[][] IndexWeightsForDiagonalPositiveSlope => sr_IndexWeightsForDiagonalPositiveSlope;

		public static bool IsGameDrawnByBoard(IPlayable i_Game)
		{
			return ResultChecker.IsGameBoardExhausted(i_Game) && !ResultChecker.HasWinnerByBoard(i_Game);
		}

		public static bool IsGameFinishedByBoard(IPlayable i_Game)
		{
			return ResultChecker.HasWinnerByBoard(i_Game) || ResultChecker.IsGameBoardExhausted(i_Game);
		}

		public static bool IsGameFinished(IPlayable i_Game)
		{
			return IsGameFinishedByBoard(i_Game) || IsGameFinishedByQuit(i_Game);
		}

		public static bool IsGameFinishedByQuit(IPlayable i_Game)
		{
			return i_Game.DidLastPlayerQuitSingleGame();
		}

		public static bool IsGameBoardExhausted(IPlayable i_Game)
		{
			return i_Game.GetBoard().NumberOfCellVacanciesInBoard == 0;
		}

		public static bool HasWinnerByBoard(IPlayable i_Game)
		{
			bool hasWinner = false;

			foreach (eDirectionOfDiscConnection direction in Enum.GetValues(typeof(eDirectionOfDiscConnection)))
			{
				hasWinner = ResultChecker.IsWinningConnection(i_Game.GetBoard(), i_Game.GetLastMove(), direction);
			}

			return hasWinner;
		}

		// A move was made here. So no quitting occurred.
		public static eGameState CalculateGameStateAfterMove(IPlayable i_Game)
		{
			eGameState stateOfGameAfterMove = eGameState.NotFinished;

			if (ResultChecker.IsGameFinishedByBoard(i_Game))
			{
				if (ResultChecker.HasWinnerByBoard(i_Game))
				{
					stateOfGameAfterMove = eGameState.FinishedInWinByBoard;
				}
				else
				{
					stateOfGameAfterMove = eGameState.FinishedInDraw;
				}
			}

			return stateOfGameAfterMove;
		}

		private static bool IsWinningConnection(Board i_Board, Cell i_FocalBoardCell, eDirectionOfDiscConnection i_DirectionOfConnection)
		{
			// The Console board is a rotation of the CellBoard Matrix:
			// 1. The matrix has cell 0,0 in the upper left.
			// 2. The console board has cell 0,0 in the bottom left.
			// Also consider that:
			// 1. A player receives indices from 1 to the width of the board.
			// 2. The matrix has column indices from 0 to with of the board minus 1.
			int focalRowIndex = i_FocalBoardCell.RowIndex;
			int focalColumnIndex = i_FocalBoardCell.ColumnIndex;

			SetWeights(
				i_DirectionOfConnection,
				out int[] weightsForIndex0,
				out int[] weightsForIndex1,
				out int[] weightsForIndex2,
				out int[] weightsForIndex3);

			return CheckDirectionByIndex(i_Board, i_FocalBoardCell, focalRowIndex, focalColumnIndex, weightsForIndex0)
					|| CheckDirectionByIndex(i_Board, i_FocalBoardCell, focalRowIndex, focalColumnIndex, weightsForIndex1)
					|| CheckDirectionByIndex(i_Board, i_FocalBoardCell, focalRowIndex, focalColumnIndex, weightsForIndex2)
					|| CheckDirectionByIndex(i_Board, i_FocalBoardCell, focalRowIndex, focalColumnIndex, weightsForIndex3);
		}

		private static void SetWeights(
			eDirectionOfDiscConnection i_DirectionOfConnection,
			out int[] o_WeightsForIndex0,
			out int[] o_WeightsForIndex1,
			out int[] o_WeightsForIndex2,
			out int[] o_WeightsForIndex3)
		{
			switch (i_DirectionOfConnection)
			{
				case eDirectionOfDiscConnection.Horizontal:
					o_WeightsForIndex0 = IndexWeightsForHorizontalConnections[0];
					o_WeightsForIndex1 = IndexWeightsForHorizontalConnections[1];
					o_WeightsForIndex2 = IndexWeightsForHorizontalConnections[2];
					o_WeightsForIndex3 = IndexWeightsForHorizontalConnections[3];
					break;
				case eDirectionOfDiscConnection.Vertical:
					o_WeightsForIndex0 = IndexWeightsForVerticalConnections[0];
					o_WeightsForIndex1 = IndexWeightsForVerticalConnections[1];
					o_WeightsForIndex2 = IndexWeightsForVerticalConnections[2];
					o_WeightsForIndex3 = IndexWeightsForVerticalConnections[3];
					break;
				case eDirectionOfDiscConnection.DiagonalPositiveSlope:
					o_WeightsForIndex0 = IndexWeightsForDiagonalPositiveSlope[0];
					o_WeightsForIndex1 = IndexWeightsForDiagonalPositiveSlope[1];
					o_WeightsForIndex2 = IndexWeightsForDiagonalPositiveSlope[2];
					o_WeightsForIndex3 = IndexWeightsForDiagonalPositiveSlope[3];
					break;
				case eDirectionOfDiscConnection.DiagonalNegativeSlope:
					o_WeightsForIndex0 = IndexWeightsForDiagonalNegativeSlope[0];
					o_WeightsForIndex1 = IndexWeightsForDiagonalNegativeSlope[1];
					o_WeightsForIndex2 = IndexWeightsForDiagonalNegativeSlope[2];
					o_WeightsForIndex3 = IndexWeightsForDiagonalNegativeSlope[3];
					break;
				default:
					throw new ArgumentOutOfRangeException(
						nameof(i_DirectionOfConnection), i_DirectionOfConnection, null);
			}
		}

		private static bool CheckDirectionByIndex(
			Board i_Board,
			Cell i_FocalBoardCell,
			int i_FocalRow,
			int i_FocalColumn,
			params int[] io_WeightsByDirection)
		{
			bool isConnectionWinning = false;
			int lastDiscFocalRowIndex = i_FocalRow;
			int lastDiscFocalColumnIndex = i_FocalColumn;
			bool connectionIsInMatrixRange = true;
			bool rowCoordinateInRange;
			bool columnCoordinateInRange;
			int weightForRow;
			int weightForColumn;

			// Checking that all coordinates for the 4 discs in connection are in range
			for (int i = 0; i < k_NumberOfWeightPairs; i++)
			{
				weightForRow = io_WeightsByDirection[i];
				weightForColumn = io_WeightsByDirection[i + k_DistanceBetweenWeightsInJaggedArray];

				rowCoordinateInRange = NumberOperations.ValueInRange(
					lastDiscFocalRowIndex + weightForRow, Board.k_ZeroIndex, i_Board.NumberOfRowIndices);

				columnCoordinateInRange = NumberOperations.ValueInRange(
					lastDiscFocalColumnIndex + weightForColumn, Board.k_ZeroIndex, i_Board.NumberOfColumnIndices);

				if (!rowCoordinateInRange || !columnCoordinateInRange)
				{
					connectionIsInMatrixRange = false;

					break;
				}
			}

			// All conditions are in range. We can safely check for connection inside Matrix without stepping out of bounds.
			if (connectionIsInMatrixRange)
			{
				isConnectionWinning = i_FocalBoardCell.HasSameTypeAs(
					i_Board.CellMatrix[lastDiscFocalRowIndex + io_WeightsByDirection[0], lastDiscFocalColumnIndex + io_WeightsByDirection[3]],
					i_Board.CellMatrix[lastDiscFocalRowIndex + io_WeightsByDirection[1], lastDiscFocalColumnIndex + io_WeightsByDirection[4]],
					i_Board.CellMatrix[lastDiscFocalRowIndex + io_WeightsByDirection[2], lastDiscFocalColumnIndex + io_WeightsByDirection[5]]);
			}

			return isConnectionWinning;
		}
	}

	public enum eDirectionOfDiscConnection
	{
		Horizontal = 0,
		Vertical = 1,
		DiagonalPositiveSlope = 2,
		DiagonalNegativeSlope = 3
	}
}
