using System;

using static System.Array;

namespace GameLogic
{
	public static class JaggedArray2DimOperations
	{
		public static int[][] HorizontalConcatInsideJaggedArray(int[][] i_2DArray1, int[][] i_2DArray2)
		{
			int lengthOfInternalArray;
			int[][] concatenatedArray = new int[i_2DArray1.Length][];

			if (i_2DArray1.Length == i_2DArray2.Length)
			{
				for (int j = 0; j < i_2DArray1.Length; j++)
				{
					lengthOfInternalArray = i_2DArray1[j].Length + i_2DArray2[j].Length;
					concatenatedArray[j] = new int[lengthOfInternalArray];
				}

				for (int i = 0; i < i_2DArray1.Length; i++)
				{
					Copy(i_2DArray1[i], 0, concatenatedArray[i], 0, i_2DArray1[i].Length);
					Copy(i_2DArray2[i], 0, concatenatedArray[i], i_2DArray1[i].Length, i_2DArray2[i].Length);
				}
			}
			else
			{
				throw new Exception();
			}

			return concatenatedArray;
		}
	}
}
