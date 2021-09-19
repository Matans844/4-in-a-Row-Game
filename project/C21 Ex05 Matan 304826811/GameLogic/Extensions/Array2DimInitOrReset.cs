using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic
{
	public static class Array2DimInitOrReset
	{
		public const int k_RowDimension = 0;
		public const int k_ColumnDimension = 1;

		public static void InitWithEmptyCells<T>(this T[,] io_Matrix)
			where T : new()
		{
			for (int i = 0; i < io_Matrix.GetLength(k_RowDimension); i++)
			{
				for (int j = 0; j < io_Matrix.GetLength(k_ColumnDimension); j++)
				{
					io_Matrix[i, j] = new T();
				}
			}
		}

		public static void InitWithBoardCells(this Cell[,] io_Matrix)
		{
			int numberOfRowsInMatrix = io_Matrix.GetLength(k_RowDimension);
			int numberOfColumnsInMatrix = io_Matrix.GetLength(k_ColumnDimension);

			for (int i = 0; i < numberOfRowsInMatrix; i++)
			{
				for (int j = 0; j < numberOfColumnsInMatrix; j++)
				{
					io_Matrix[i, j] = new Cell(i, j);
				}
			}
		}

		public static void ResetBoardCells(this Cell[,] io_Matrix)
		{
			int numberOfRowsInMatrix = io_Matrix.GetLength(k_RowDimension);
			int numberOfColumnsInMatrix = io_Matrix.GetLength(k_ColumnDimension);

			for (int i = 0; i < numberOfRowsInMatrix; i++)
			{
				for (int j = 0; j < numberOfColumnsInMatrix; j++)
				{
					io_Matrix[i, j].Reset();
				}
			}
		}
	}
}
