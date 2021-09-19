using System.Linq;

namespace Ex05.GameLogic
{

	public static class Array2DimOperations<T>
	{
		public const int k_RowDimension = 0;
		public const int k_ColumnDimension = 1;

		public static T[] GetDimension1Row(T[,] i_Matrix, int i_ColumnNumber)
		{
			return Enumerable.Range(0, i_Matrix.GetLength(k_RowDimension))
				.Select(i_IndexForEnumeration => i_Matrix[i_IndexForEnumeration, i_ColumnNumber]).ToArray();
		}

		public static T[] GetDimension2Column(T[,] i_Matrix, int i_RowNumber)
		{
			return Enumerable.Range(0, i_Matrix.GetLength(k_ColumnDimension))
				.Select(i_IndexForEnumeration => i_Matrix[i_RowNumber, i_IndexForEnumeration]).ToArray();
		}
	}
}