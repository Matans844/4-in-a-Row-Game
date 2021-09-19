﻿
namespace Ex05.FormsUserInterface
{
	partial class FormGamePlay
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
			this.LabelPlayer1Name = new System.Windows.Forms.Label();
			this.LabelPlayer2Name = new System.Windows.Forms.Label();
			this.LabelPlayer1Score = new System.Windows.Forms.Label();
			this.LabelPlayer2Score = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// LabelPlayer1Name
			// 
			this.LabelPlayer1Name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.LabelPlayer1Name.AutoSize = true;
			this.LabelPlayer1Name.Location = new System.Drawing.Point(108, 111);
			this.LabelPlayer1Name.Name = "LabelPlayer1Name";
			this.LabelPlayer1Name.Size = new System.Drawing.Size(127, 32);
			this.LabelPlayer1Name.TabIndex = 0;
			this.LabelPlayer1Name.Text = "Player 1:";
			// 
			// LabelPlayer2Name
			// 
			this.LabelPlayer2Name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.LabelPlayer2Name.AutoSize = true;
			this.LabelPlayer2Name.Location = new System.Drawing.Point(498, 111);
			this.LabelPlayer2Name.Name = "LabelPlayer2Name";
			this.LabelPlayer2Name.Size = new System.Drawing.Size(127, 32);
			this.LabelPlayer2Name.TabIndex = 1;
			this.LabelPlayer2Name.Text = "Player 2:";
			this.LabelPlayer2Name.Click += new System.EventHandler(this.LabelPlayer2Name_Click);
			// 
			// LabelPlayer1Score
			// 
			this.LabelPlayer1Score.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.LabelPlayer1Score.AutoSize = true;
			this.LabelPlayer1Score.Location = new System.Drawing.Point(241, 111);
			this.LabelPlayer1Score.Name = "LabelPlayer1Score";
			this.LabelPlayer1Score.Size = new System.Drawing.Size(112, 32);
			this.LabelPlayer1Score.TabIndex = 2;
			this.LabelPlayer1Score.Text = "Score 1";
			this.LabelPlayer1Score.Click += new System.EventHandler(this.LabelScorePlayer1_Click);
			// 
			// LabelPlayer2Score
			// 
			this.LabelPlayer2Score.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.LabelPlayer2Score.AutoSize = true;
			this.LabelPlayer2Score.Location = new System.Drawing.Point(631, 111);
			this.LabelPlayer2Score.Name = "LabelPlayer2Score";
			this.LabelPlayer2Score.Size = new System.Drawing.Size(112, 32);
			this.LabelPlayer2Score.TabIndex = 3;
			this.LabelPlayer2Score.Text = "Score 2";
			// 
			// FormGamePlay
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(859, 188);
			this.Controls.Add(this.LabelPlayer2Score);
			this.Controls.Add(this.LabelPlayer1Score);
			this.Controls.Add(this.LabelPlayer2Name);
			this.Controls.Add(this.LabelPlayer1Name);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "FormGamePlay";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "4 In A Row !!";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label LabelPlayer1Name;
		private System.Windows.Forms.Label LabelPlayer2Name;
		private System.Windows.Forms.Label LabelPlayer1Score;
		private System.Windows.Forms.Label LabelPlayer2Score;
	}
}