using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex05.FormsUserInterface
{
	using System.Windows.Forms;

	public class GameLauncher
	{
		private readonly FormGameSetup r_FormSetup;
		private FormGamePlay m_FormPlay;

		public FormGameSetup FormSetup => this.r_FormSetup;

		public FormGamePlay FormPlay
		{
			get => this.m_FormPlay;
			set => this.m_FormPlay = value;
		}

		public GameLauncher()
		{
			this.r_FormSetup = new FormGameSetup();
		}

		public void Start()
		{
			this.FormSetup.ShowDialog();
			this.FormPlay = new FormGamePlay(this.FormSetup.GameSettingsManager, this.FormSetup.BoardSizeManager);

			do
			{
				this.FormPlay.ShowDialog();
			}
			while (this.FormPlay.DialogResult == DialogResult.OK);
		}
	}
}
