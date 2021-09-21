namespace Ex05.GameLogic
{
	public class PlayerComputer : Player
	{
		public PlayerComputer(IPlayable i_Game, Board i_BoardOfPlayer, eBoardCellType i_DiscType, eTurnState i_TurnState, string i_PlayerName)
			: base(i_Game, i_BoardOfPlayer, i_DiscType, i_TurnState, i_PlayerName)
		{
			this.PlayerType = ePlayerType.Computer;
		}
	}
}