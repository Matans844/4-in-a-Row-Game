using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic
{
	public class PlayerHuman : Player
	{
		private const ePlayerType k_PlayerType = ePlayerType.Human;

		public ePlayerType PlayerType => k_PlayerType;

		public PlayerHuman(Board i_BoardOfPlayer, eBoardCellType i_DiscType, eTurnState i_TurnState, string i_PlayerName)
			: base(i_BoardOfPlayer, i_DiscType, i_TurnState, i_PlayerName)
		{
		}

		public override int ChooseColumnForMove()
		{
			return this.GameForBoard.GetLastMove().ColumnIndex;
		}
	}
}