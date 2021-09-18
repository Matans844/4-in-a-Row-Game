using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic
{
	public class PlayerHuman : Player
	{
		private const ePlayerType k_PlayerType = ePlayerType.Human;
		public event Action SelectedColumn;

		public ePlayerType PlayerType => k_PlayerType;
		
		public PlayerHuman(
			Board i_BoardOfPlayer,
			eBoardCellType i_DiscType,
			eTurnState i_TurnState,
			Action )
			: base(i_BoardOfPlayer, i_DiscType, i_TurnState)
		{
		}

		public override int ChooseColumnForMove()
		{
			int randomChoice = NumberOperations.GetRandomNumber(BoardOfPlayer.NumberOfColumnIndices);

			while (!this.BoardOfPlayer.IsColumnAvailableForDisc(randomChoice))
			{
				randomChoice = NumberOperations.GetRandomNumber(this.BoardOfPlayer.NumberOfColumnIndices);
			}

			return randomChoice;
		}
	}
}