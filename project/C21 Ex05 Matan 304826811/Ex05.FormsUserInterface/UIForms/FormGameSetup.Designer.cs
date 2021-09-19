
namespace Ex05.FormsUserInterface
{
	partial class FormGameSetup
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.SectionPlayerChooseName = new System.Windows.Forms.Label();
			this.LabelPlayer1ChooseName = new System.Windows.Forms.Label();
			this.LabelPlayer2ChooseName = new System.Windows.Forms.Label();
			this.Player1ChosenName = new System.Windows.Forms.TextBox();
			this.Player2ChosenName = new System.Windows.Forms.TextBox();
			this.HumanOpponent = new System.Windows.Forms.CheckBox();
			this.SectionBoardSize = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// SectionPlayerChooseName
			// 
			this.SectionPlayerChooseName.AutoSize = true;
			this.SectionPlayerChooseName.Location = new System.Drawing.Point(26, 31);
			this.SectionPlayerChooseName.Name = "SectionPlayerChooseName";
			this.SectionPlayerChooseName.Size = new System.Drawing.Size(118, 32);
			this.SectionPlayerChooseName.TabIndex = 10;
			this.SectionPlayerChooseName.Text = "Players:";
			// 
			// LabelPlayer1ChooseName
			// 
			this.LabelPlayer1ChooseName.AutoSize = true;
			this.LabelPlayer1ChooseName.Location = new System.Drawing.Point(59, 89);
			this.LabelPlayer1ChooseName.Name = "LabelPlayer1ChooseName";
			this.LabelPlayer1ChooseName.Size = new System.Drawing.Size(127, 32);
			this.LabelPlayer1ChooseName.TabIndex = 20;
			this.LabelPlayer1ChooseName.Text = "Player 1:";
			// 
			// LabelPlayer2ChooseName
			// 
			this.LabelPlayer2ChooseName.AutoSize = true;
			this.LabelPlayer2ChooseName.Location = new System.Drawing.Point(107, 148);
			this.LabelPlayer2ChooseName.Name = "LabelPlayer2ChooseName";
			this.LabelPlayer2ChooseName.Size = new System.Drawing.Size(127, 32);
			this.LabelPlayer2ChooseName.TabIndex = 50;
			this.LabelPlayer2ChooseName.Text = "Player 2:";
			// 
			// Player1ChosenName
			// 
			this.Player1ChosenName.Location = new System.Drawing.Point(282, 86);
			this.Player1ChosenName.Name = "Player1ChosenName";
			this.Player1ChosenName.Size = new System.Drawing.Size(336, 38);
			this.Player1ChosenName.TabIndex = 30;
			// 
			// Player2ChosenName
			// 
			this.Player2ChosenName.Enabled = false;
			this.Player2ChosenName.HideSelection = false;
			this.Player2ChosenName.Location = new System.Drawing.Point(282, 145);
			this.Player2ChosenName.Name = "Player2ChosenName";
			this.Player2ChosenName.ReadOnly = true;
			this.Player2ChosenName.Size = new System.Drawing.Size(336, 38);
			this.Player2ChosenName.TabIndex = 60;
			this.Player2ChosenName.Text = "[Computer]";
			// 
			// HumanOpponent
			// 
			this.HumanOpponent.AutoSize = true;
			this.HumanOpponent.Location = new System.Drawing.Point(67, 145);
			this.HumanOpponent.Name = "HumanOpponent";
			this.HumanOpponent.Size = new System.Drawing.Size(34, 33);
			this.HumanOpponent.TabIndex = 40;
			this.HumanOpponent.UseVisualStyleBackColor = true;
			this.HumanOpponent.CheckedChanged += new System.EventHandler(this.HumanOpponent_CheckedChanged);
			// 
			// SectionBoardSize
			// 
			this.SectionBoardSize.AutoSize = true;
			this.SectionBoardSize.Location = new System.Drawing.Point(26, 225);
			this.SectionBoardSize.Name = "SectionBoardSize";
			this.SectionBoardSize.Size = new System.Drawing.Size(405, 80);
			this.SectionBoardSize.TabIndex = 70;
			this.SectionBoardSize.Text = "Board Size:";
			// 
			// FormGameSetup
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(681, 485);
			this.Controls.Add(this.SectionBoardSize);
			this.Controls.Add(this.HumanOpponent);
			this.Controls.Add(this.Player2ChosenName);
			this.Controls.Add(this.Player1ChosenName);
			this.Controls.Add(this.LabelPlayer2ChooseName);
			this.Controls.Add(this.LabelPlayer1ChooseName);
			this.Controls.Add(this.SectionPlayerChooseName);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormGameSetup";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Game Settings";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label SectionPlayerChooseName;
		private System.Windows.Forms.Label LabelPlayer1ChooseName;
		private System.Windows.Forms.Label LabelPlayer2ChooseName;
		private System.Windows.Forms.TextBox Player1ChosenName;
		private System.Windows.Forms.TextBox Player2ChosenName;
		private System.Windows.Forms.CheckBox HumanOpponent;
		private System.Windows.Forms.Label SectionBoardSize;
	}
}

