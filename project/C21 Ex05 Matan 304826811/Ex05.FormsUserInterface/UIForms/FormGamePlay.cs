using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ex05.GameLogic;

namespace Ex05.FormsUserInterface
{
	public partial class FormGamePlay : Form
	{
		public FormGamePlay(GameSettings i_GameSettingsManager, BoardSizeSettings i_BoardSizeSettingsManager)
		{
			InitializeComponent();
		}
	}
}
