
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
			this.LabelSectionPlayerChooseName = new System.Windows.Forms.Label();
			this.LabelPlayer1ChooseName = new System.Windows.Forms.Label();
			this.LabelPlayer2ChooseName = new System.Windows.Forms.Label();
			this.TextBoxPlayer1ChooseName = new System.Windows.Forms.TextBox();
			this.TextBoxPlayer2ChooseName = new System.Windows.Forms.TextBox();
			this.CheckBoxHumanOpponent = new System.Windows.Forms.CheckBox();
			this.LabelSectionBoardSize = new System.Windows.Forms.Label();
			this.LabelChooseRowNumber = new System.Windows.Forms.Label();
			this.NumericUpDownChooseNumberOfRows = new System.Windows.Forms.NumericUpDown();
			this.LabelChooseColumnNumber = new System.Windows.Forms.Label();
			this.NumericUpDownChooseNumberOfColumns = new System.Windows.Forms.NumericUpDown();
			this.StartButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.NumericUpDownChooseNumberOfRows)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NumericUpDownChooseNumberOfColumns)).BeginInit();
			this.SuspendLayout();
			// 
			// LabelSectionPlayerChooseName
			// 
			this.LabelSectionPlayerChooseName.AutoSize = true;
			this.LabelSectionPlayerChooseName.Location = new System.Drawing.Point(26, 31);
			this.LabelSectionPlayerChooseName.Name = "LabelSectionPlayerChooseName";
			this.LabelSectionPlayerChooseName.Size = new System.Drawing.Size(118, 32);
			this.LabelSectionPlayerChooseName.TabIndex = 10;
			this.LabelSectionPlayerChooseName.Text = "Players:";
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
			// TextBoxPlayer1ChooseName
			// 
			this.TextBoxPlayer1ChooseName.Location = new System.Drawing.Point(282, 86);
			this.TextBoxPlayer1ChooseName.Name = "TextBoxPlayer1ChooseName";
			this.TextBoxPlayer1ChooseName.Size = new System.Drawing.Size(336, 38);
			this.TextBoxPlayer1ChooseName.TabIndex = 30;
			// 
			// TextBoxPlayer2ChooseName
			// 
			this.TextBoxPlayer2ChooseName.Enabled = false;
			this.TextBoxPlayer2ChooseName.HideSelection = false;
			this.TextBoxPlayer2ChooseName.Location = new System.Drawing.Point(282, 145);
			this.TextBoxPlayer2ChooseName.Name = "TextBoxPlayer2ChooseName";
			this.TextBoxPlayer2ChooseName.ReadOnly = true;
			this.TextBoxPlayer2ChooseName.Size = new System.Drawing.Size(336, 38);
			this.TextBoxPlayer2ChooseName.TabIndex = 60;
			this.TextBoxPlayer2ChooseName.Text = "[Computer]";
			// 
			// CheckBoxHumanOpponent
			// 
			this.CheckBoxHumanOpponent.AutoSize = true;
			this.CheckBoxHumanOpponent.Location = new System.Drawing.Point(67, 145);
			this.CheckBoxHumanOpponent.Name = "CheckBoxHumanOpponent";
			this.CheckBoxHumanOpponent.Size = new System.Drawing.Size(34, 33);
			this.CheckBoxHumanOpponent.TabIndex = 40;
			this.CheckBoxHumanOpponent.UseVisualStyleBackColor = true;
			this.CheckBoxHumanOpponent.CheckedChanged += new System.EventHandler(this.CheckBoxHumanOpponent_CheckedChanged);
			// 
			// LabelSectionBoardSize
			// 
			this.LabelSectionBoardSize.AutoSize = true;
			this.LabelSectionBoardSize.Location = new System.Drawing.Point(26, 225);
			this.LabelSectionBoardSize.Name = "LabelSectionBoardSize";
			this.LabelSectionBoardSize.Size = new System.Drawing.Size(162, 32);
			this.LabelSectionBoardSize.TabIndex = 70;
			this.LabelSectionBoardSize.Text = "Board Size:";
			// 
			// LabelChooseRowNumber
			// 
			this.LabelChooseRowNumber.AutoSize = true;
			this.LabelChooseRowNumber.Location = new System.Drawing.Point(59, 282);
			this.LabelChooseRowNumber.Name = "LabelChooseRowNumber";
			this.LabelChooseRowNumber.Size = new System.Drawing.Size(93, 32);
			this.LabelChooseRowNumber.TabIndex = 70;
			this.LabelChooseRowNumber.Text = "Rows:";
			// 
			// NumericUpDownChooseNumberOfRows
			// 
			this.NumericUpDownChooseNumberOfRows.Location = new System.Drawing.Point(168, 282);
			this.NumericUpDownChooseNumberOfRows.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
			this.NumericUpDownChooseNumberOfRows.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
			this.NumericUpDownChooseNumberOfRows.Name = "NumericUpDownChooseNumberOfRows";
			this.NumericUpDownChooseNumberOfRows.Size = new System.Drawing.Size(82, 38);
			this.NumericUpDownChooseNumberOfRows.TabIndex = 80;
			this.NumericUpDownChooseNumberOfRows.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
			// 
			// LabelChooseColumnNumber
			// 
			this.LabelChooseColumnNumber.AutoSize = true;
			this.LabelChooseColumnNumber.Location = new System.Drawing.Point(315, 282);
			this.LabelChooseColumnNumber.Name = "LabelChooseColumnNumber";
			this.LabelChooseColumnNumber.Size = new System.Drawing.Size(80, 32);
			this.LabelChooseColumnNumber.TabIndex = 81;
			this.LabelChooseColumnNumber.Text = "Cols:";
			// 
			// NumericUpDownChooseNumberOfColumns
			// 
			this.NumericUpDownChooseNumberOfColumns.Location = new System.Drawing.Point(415, 280);
			this.NumericUpDownChooseNumberOfColumns.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
			this.NumericUpDownChooseNumberOfColumns.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
			this.NumericUpDownChooseNumberOfColumns.Name = "NumericUpDownChooseNumberOfColumns";
			this.NumericUpDownChooseNumberOfColumns.Size = new System.Drawing.Size(82, 38);
			this.NumericUpDownChooseNumberOfColumns.TabIndex = 82;
			this.NumericUpDownChooseNumberOfColumns.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
			// 
			// StartButton
			// 
			this.StartButton.Location = new System.Drawing.Point(97, 378);
			this.StartButton.Name = "StartButton";
			this.StartButton.Size = new System.Drawing.Size(438, 48);
			this.StartButton.TabIndex = 83;
			this.StartButton.Text = "Start!";
			this.StartButton.UseVisualStyleBackColor = true;
			this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
			// 
			// FormGameSetup
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(653, 466);
			this.Controls.Add(this.StartButton);
			this.Controls.Add(this.NumericUpDownChooseNumberOfColumns);
			this.Controls.Add(this.LabelChooseColumnNumber);
			this.Controls.Add(this.NumericUpDownChooseNumberOfRows);
			this.Controls.Add(this.LabelChooseRowNumber);
			this.Controls.Add(this.LabelSectionBoardSize);
			this.Controls.Add(this.CheckBoxHumanOpponent);
			this.Controls.Add(this.TextBoxPlayer2ChooseName);
			this.Controls.Add(this.TextBoxPlayer1ChooseName);
			this.Controls.Add(this.LabelPlayer2ChooseName);
			this.Controls.Add(this.LabelPlayer1ChooseName);
			this.Controls.Add(this.LabelSectionPlayerChooseName);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormGameSetup";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "PlayableGame Settings";
			((System.ComponentModel.ISupportInitialize)(this.NumericUpDownChooseNumberOfRows)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NumericUpDownChooseNumberOfColumns)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label LabelSectionPlayerChooseName;
		private System.Windows.Forms.Label LabelPlayer1ChooseName;
		private System.Windows.Forms.Label LabelPlayer2ChooseName;
		private System.Windows.Forms.TextBox TextBoxPlayer1ChooseName;
		private System.Windows.Forms.TextBox TextBoxPlayer2ChooseName;
		private System.Windows.Forms.CheckBox CheckBoxHumanOpponent;
		private System.Windows.Forms.Label LabelSectionBoardSize;
		private System.Windows.Forms.Label LabelChooseRowNumber;
		private System.Windows.Forms.NumericUpDown NumericUpDownChooseNumberOfRows;
		private System.Windows.Forms.Label LabelChooseColumnNumber;
		private System.Windows.Forms.NumericUpDown NumericUpDownChooseNumberOfColumns;
		private System.Windows.Forms.Button StartButton;
	}
}

