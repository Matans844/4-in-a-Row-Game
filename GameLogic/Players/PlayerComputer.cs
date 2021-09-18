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

		public PlayerComputer(Board i_BoardOfPlayer, eBoardCellType i_DiscType, eTurnState i_TurnState)
			: base(i_BoardOfPlayer, i_DiscType, i_TurnState)
		{
		}

		public override void MakeMove(int i_ChosenColumn)
		{
			this.BoardOfPlayer.SlideDiskToBoard(this.ChooseColumnForMove(), this.DiscType);
			this.TurnState = eTurnState.NotYourTurn;
		}

		public int ChooseColumnForMove()
		{
			int randomChoice = NumberOperations.GetRandomNumber(BoardOfPlayer.NumberOfColumnIndices);

			while (!BoardOfPlayer.IsColumnAvailableForDisc(randomChoice))
			{
				randomChoice = NumberOperations.GetRandomNumber(BoardOfPlayer.NumberOfColumnIndices);
			}

			return randomChoice;
		}
	}
}