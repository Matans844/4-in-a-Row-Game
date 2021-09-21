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
			DialogResult setupResult = this.FormSetup.ShowDialog();

			if (setupResult == DialogResult.OK)
			{
				this.FormPlay = new FormGamePlay(this.FormSetup.GameSettingsManager);

				do
				{
					this.FormPlay.ShowDialog();
				}
				while (this.FormPlay.DialogResult == DialogResult.OK);
			}
		}
	}
}
