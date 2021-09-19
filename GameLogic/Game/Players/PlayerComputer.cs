using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic
{
	public class PlayerComputer : Player
	{
		private const ePlayerType k_PlayerType = ePlayerType.Computer;

		public ePlayerType PlayerType => k_PlayerType;

		public PlayerComputer(Board i_BoardOfPlayer, eBoardCellType i_DiscType, eTurnState i_TurnState, string i_PlayerName)
			: base(i_BoardOfPlayer, i_DiscType, i_TurnState, i_PlayerName)
		{
		}

		public override int ChooseColumnForMove()
		{
			int randomChoice = NumberOperations.GetRandomNumber(this.BoardOfPlayer.NumberOfColumnIndices);

			while (!this.BoardOfPlayer.IsColumnAvailableForDisc(randomChoice))
			{
				randomChoice = NumberOperations.GetRandomNumber(this.BoardOfPlayer.NumberOfColumnIndices);
			}

			return randomChoice;
		}
	}
}