namespace Ex05.GameLogic
{
	public class GameSettings
	{
		public const string k_DefaultComputerPlayerName = "Computer";
		public const string k_DefaultHumanPlayer1Name = "Player 1";
		public const string k_DefaultHumanPlayer2Name = "Player 2";
		public const int k_MinimumBoardDimension = 4;
		public const int k_MaximumBoardDimension = 8;
		private static string s_Player1Name = k_DefaultHumanPlayer1Name;
		private static string s_Player2Name = k_DefaultHumanPlayer2Name;
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
				int integerToSet;

				if (value.HasValue)
				{
					integerToSet = (int)value;

					if (NumberOperations.ValueInRange(integerToSet, k_MinimumBoardDimension, k_MaximumBoardDimension))
					{
						s_RowsForGame = integerToSet;
					}
				}
			}
		}

		public static int? ColumnsForGame
		{
			get => s_ColumnsForGame;
			set
			{
				int integerToSet;

				if (value.HasValue)
				{
					integerToSet = (int)value;

					if (NumberOperations.ValueInRange(integerToSet, k_MinimumBoardDimension, k_MaximumBoardDimension))
					{
						s_ColumnsForGame = integerToSet;
					}
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

		public GameSettings()
		{
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
