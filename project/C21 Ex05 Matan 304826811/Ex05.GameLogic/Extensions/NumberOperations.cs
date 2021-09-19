using System;

namespace Ex05.GameLogic
{
	public class NumberOperations
	{
		public const int k_Zero = 0;
		private static readonly Random sr_GetRandomInteger = new Random();

		public static bool ValueInRange(int i_ValueToCheck, int i_MinValue, int i_MaxValue)
		{
			return i_MinValue <= i_ValueToCheck && i_ValueToCheck <= i_MaxValue;
		}

		public static Random GetRandomInteger => sr_GetRandomInteger;

		public static int GetRandomNumber(int i_MinimumNumber, int i_MaximumNumber)
		{
			return GetRandomInteger.Next(i_MinimumNumber, i_MaximumNumber);
		}

		public static int GetRandomNumber(int i_MaximumNumber)
		{
			return GetRandomNumber(k_Zero, i_MaximumNumber);
		}
	}
}
