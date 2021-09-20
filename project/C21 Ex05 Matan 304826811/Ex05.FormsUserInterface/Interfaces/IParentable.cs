using Ex05.GameLogic;
using System.Windows.Forms;

namespace Ex05.FormsUserInterface
{
	public interface IParentable
	{
		IPlayable GetPlayableMember();

		TableLayoutPanel GetBoardTable();
	}
}
