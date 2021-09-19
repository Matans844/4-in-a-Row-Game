using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic
{
	public class GameSettings
	{
		public const string k_DefaultComputerPlayerName = "Computer";
		public const int k_MinimumBoardDimension = 4;
		// public const int k_MaximumBoardDimension = 8;
		private static string s_Player1Name;
		private static string s_Player2Name;
		private static int? s_RowsForGame;
		private static int? s_ColumnsForGame;
		private static eGameMode? s_GameMode;
		private static bool s_ReadyForGame = false;

		public static bool ReadyForGame
		{
			get => s_ReadyForGame;
			set => s_ReadyForGame = value;
		}

		public static string Player1Name
		{
			get => s_Player1Name;
			set => s_Player1Name = value;
		}

		public static string Player2Name
		{
			get => s_Player2Name;
			set => s_Player2Name = value;
		}

		public static int? RowsForGame
		{
			get => s_RowsForGame;
			set
			{
				if (value >= k_MinimumBoardDimension)
				{
					s_RowsForGame = value;
				}
			}
		}

		public static int? ColumnsForGame
		{
			get => s_ColumnsForGame;
			set
			{
				if (value >= k_MinimumBoardDimension)
				{
					s_ColumnsForGame = value;
				}
			}
		}

		public static eGameMode? ModeForGame
		{
			get => s_GameMode;
			set
			{
				if (value.Equals(eGameMode.PlayerVsComputer))
				{
					Player2Name = k_DefaultComputerPlayerName;
				}

				s_GameMode = value;
			}
		}

		public static bool CanGameBegin()
		{
			if (allRequiredSettingsAreSet())
			{
				ReadyForGame = true;
			}

			return ReadyForGame;
		}

		private static bool allRequiredSettingsAreSet()
		{
			bool allNullableValuesSet = RowsForGame.HasValue
										&& ColumnsForGame.HasValue
										&& ModeForGame.HasValue
										&& !string.IsNullOrEmpty(Player1Name)
										&& !string.IsNullOrEmpty(Player2Name);

			return allNullableValuesSet;
		}
	}
}
