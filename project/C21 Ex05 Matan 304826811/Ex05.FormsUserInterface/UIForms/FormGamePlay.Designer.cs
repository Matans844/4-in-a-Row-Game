
namespace Ex05.FormsUserInterface
{
	using System.Drawing;

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
			this.TableBoardCells = new System.Windows.Forms.TableLayoutPanel();
			this.FlowAllSection = new System.Windows.Forms.FlowLayoutPanel();
			this.FlowSectionBoard = new System.Windows.Forms.FlowLayoutPanel();
			this.TableRowOfColumnLabels = new System.Windows.Forms.TableLayoutPanel();
			this.FlowSectionInfo = new System.Windows.Forms.FlowLayoutPanel();
			this.FlowPlayer1Info = new System.Windows.Forms.FlowLayoutPanel();
			this.LabelPlayer1Score = new Ex05.FormsUserInterface.LabelPlayerScore();
			this.FlowPlayer2Info = new System.Windows.Forms.FlowLayoutPanel();
			this.LabelPlayer2Score = new Ex05.FormsUserInterface.LabelPlayerScore();
			this.FlowAllSection.SuspendLayout();
			this.FlowSectionBoard.SuspendLayout();
			this.FlowSectionInfo.SuspendLayout();
			this.FlowPlayer1Info.SuspendLayout();
			this.FlowPlayer2Info.SuspendLayout();
			this.SuspendLayout();
			// 
			// LabelPlayer1Name
			// 
			this.LabelPlayer1Name.AutoSize = true;
			this.LabelPlayer1Name.BackColor = System.Drawing.SystemColors.Control;
			this.LabelPlayer1Name.Enabled = false;
			this.LabelPlayer1Name.Location = new System.Drawing.Point(15, 15);
			this.LabelPlayer1Name.Margin = new System.Windows.Forms.Padding(5, 5, 1, 5);
			this.LabelPlayer1Name.Name = "LabelPlayer1Name";
			this.LabelPlayer1Name.Padding = new System.Windows.Forms.Padding(10, 10, 1, 10);
			this.LabelPlayer1Name.Size = new System.Drawing.Size(138, 52);
			this.LabelPlayer1Name.TabIndex = 0;
			this.LabelPlayer1Name.Text = "Player 1:";
			// 
			// LabelPlayer2Name
			// 
			this.LabelPlayer2Name.AutoSize = true;
			this.LabelPlayer2Name.BackColor = System.Drawing.SystemColors.Control;
			this.LabelPlayer2Name.Enabled = false;
			this.LabelPlayer2Name.Location = new System.Drawing.Point(15, 15);
			this.LabelPlayer2Name.Margin = new System.Windows.Forms.Padding(5, 5, 1, 5);
			this.LabelPlayer2Name.Name = "LabelPlayer2Name";
			this.LabelPlayer2Name.Padding = new System.Windows.Forms.Padding(10, 10, 1, 10);
			this.LabelPlayer2Name.Size = new System.Drawing.Size(138, 52);
			this.LabelPlayer2Name.TabIndex = 1;
			this.LabelPlayer2Name.Text = "Player 2:";
			// 
			// TableBoardCells
			// 
			this.TableBoardCells.AutoSize = true;
			this.TableBoardCells.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.TableBoardCells.ColumnCount = 4;
			this.TableBoardCells.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.TableBoardCells.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.TableBoardCells.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.TableBoardCells.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.TableBoardCells.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TableBoardCells.Location = new System.Drawing.Point(3, 9);
			this.TableBoardCells.Name = "TableBoardCells";
			this.TableBoardCells.RowCount = 4;
			this.TableBoardCells.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableBoardCells.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableBoardCells.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableBoardCells.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableBoardCells.Size = new System.Drawing.Size(0, 0);
			this.TableBoardCells.TabIndex = 8;
			// 
			// FlowAllSection
			// 
			this.FlowAllSection.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.FlowAllSection.AutoSize = true;
			this.FlowAllSection.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.FlowAllSection.Controls.Add(this.FlowSectionBoard);
			this.FlowAllSection.Controls.Add(this.FlowSectionInfo);
			this.FlowAllSection.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.FlowAllSection.Location = new System.Drawing.Point(20, 34);
			this.FlowAllSection.Margin = new System.Windows.Forms.Padding(10);
			this.FlowAllSection.Name = "FlowAllSection";
			this.FlowAllSection.Padding = new System.Windows.Forms.Padding(10);
			this.FlowAllSection.Size = new System.Drawing.Size(490, 156);
			this.FlowAllSection.TabIndex = 9;
			// 
			// FlowSectionBoard
			// 
			this.FlowSectionBoard.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.FlowSectionBoard.AutoSize = true;
			this.FlowSectionBoard.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.FlowSectionBoard.Controls.Add(this.TableRowOfColumnLabels);
			this.FlowSectionBoard.Controls.Add(this.TableBoardCells);
			this.FlowSectionBoard.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.FlowSectionBoard.Location = new System.Drawing.Point(242, 13);
			this.FlowSectionBoard.Name = "FlowSectionBoard";
			this.FlowSectionBoard.Size = new System.Drawing.Size(6, 12);
			this.FlowSectionBoard.TabIndex = 11;
			// 
			// TableRowOfColumnLabels
			// 
			this.TableRowOfColumnLabels.AutoSize = true;
			this.TableRowOfColumnLabels.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.TableRowOfColumnLabels.ColumnCount = 2;
			this.TableRowOfColumnLabels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.TableRowOfColumnLabels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.TableRowOfColumnLabels.Location = new System.Drawing.Point(3, 3);
			this.TableRowOfColumnLabels.Name = "TableRowOfColumnLabels";
			this.TableRowOfColumnLabels.RowCount = 2;
			this.TableRowOfColumnLabels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.TableRowOfColumnLabels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.TableRowOfColumnLabels.Size = new System.Drawing.Size(0, 0);
			this.TableRowOfColumnLabels.TabIndex = 12;
			// 
			// FlowSectionInfo
			// 
			this.FlowSectionInfo.AutoSize = true;
			this.FlowSectionInfo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.FlowSectionInfo.Controls.Add(this.FlowPlayer1Info);
			this.FlowSectionInfo.Controls.Add(this.FlowPlayer2Info);
			this.FlowSectionInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.FlowSectionInfo.Location = new System.Drawing.Point(13, 31);
			this.FlowSectionInfo.Name = "FlowSectionInfo";
			this.FlowSectionInfo.Padding = new System.Windows.Forms.Padding(10);
			this.FlowSectionInfo.Size = new System.Drawing.Size(464, 112);
			this.FlowSectionInfo.TabIndex = 10;
			// 
			// FlowPlayer1Info
			// 
			this.FlowPlayer1Info.AutoSize = true;
			this.FlowPlayer1Info.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.FlowPlayer1Info.Controls.Add(this.LabelPlayer1Name);
			this.FlowPlayer1Info.Controls.Add(this.LabelPlayer1Score);
			this.FlowPlayer1Info.Location = new System.Drawing.Point(15, 15);
			this.FlowPlayer1Info.Margin = new System.Windows.Forms.Padding(5);
			this.FlowPlayer1Info.Name = "FlowPlayer1Info";
			this.FlowPlayer1Info.Padding = new System.Windows.Forms.Padding(10);
			this.FlowPlayer1Info.Size = new System.Drawing.Size(212, 82);
			this.FlowPlayer1Info.TabIndex = 12;
			// 
			// LabelPlayer1Score
			// 
			this.LabelPlayer1Score.AutoSize = true;
			this.LabelPlayer1Score.Location = new System.Drawing.Point(155, 15);
			this.LabelPlayer1Score.Margin = new System.Windows.Forms.Padding(1, 5, 5, 5);
			this.LabelPlayer1Score.Name = "LabelPlayer1Score";
			this.LabelPlayer1Score.Padding = new System.Windows.Forms.Padding(1, 10, 10, 10);
			this.LabelPlayer1Score.PlayerNumber = Ex05.GameLogic.ePlayerNumber.Player1;
			this.LabelPlayer1Score.Size = new System.Drawing.Size(42, 52);
			this.LabelPlayer1Score.TabIndex = 12;
			this.LabelPlayer1Score.Text = "0";
			// 
			// FlowPlayer2Info
			// 
			this.FlowPlayer2Info.AutoSize = true;
			this.FlowPlayer2Info.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.FlowPlayer2Info.Controls.Add(this.LabelPlayer2Name);
			this.FlowPlayer2Info.Controls.Add(this.LabelPlayer2Score);
			this.FlowPlayer2Info.Location = new System.Drawing.Point(237, 15);
			this.FlowPlayer2Info.Margin = new System.Windows.Forms.Padding(5);
			this.FlowPlayer2Info.Name = "FlowPlayer2Info";
			this.FlowPlayer2Info.Padding = new System.Windows.Forms.Padding(10);
			this.FlowPlayer2Info.Size = new System.Drawing.Size(212, 82);
			this.FlowPlayer2Info.TabIndex = 12;
			// 
			// LabelPlayer2Score
			// 
			this.LabelPlayer2Score.AutoSize = true;
			this.LabelPlayer2Score.Location = new System.Drawing.Point(155, 15);
			this.LabelPlayer2Score.Margin = new System.Windows.Forms.Padding(1, 5, 5, 5);
			this.LabelPlayer2Score.Name = "LabelPlayer2Score";
			this.LabelPlayer2Score.Padding = new System.Windows.Forms.Padding(1, 10, 10, 10);
			this.LabelPlayer2Score.PlayerNumber = Ex05.GameLogic.ePlayerNumber.Player2;
			this.LabelPlayer2Score.Size = new System.Drawing.Size(42, 52);
			this.LabelPlayer2Score.TabIndex = 12;
			this.LabelPlayer2Score.Text = "0";
			// 
			// FormGamePlay
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(539, 596);
			this.Controls.Add(this.FlowAllSection);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "FormGamePlay";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "4 In A Row !!";
			this.FlowAllSection.ResumeLayout(false);
			this.FlowAllSection.PerformLayout();
			this.FlowSectionBoard.ResumeLayout(false);
			this.FlowSectionBoard.PerformLayout();
			this.FlowSectionInfo.ResumeLayout(false);
			this.FlowSectionInfo.PerformLayout();
			this.FlowPlayer1Info.ResumeLayout(false);
			this.FlowPlayer1Info.PerformLayout();
			this.FlowPlayer2Info.ResumeLayout(false);
			this.FlowPlayer2Info.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label LabelPlayer1Name;
		private System.Windows.Forms.Label LabelPlayer2Name;
		private System.Windows.Forms.TableLayoutPanel TableBoardCells;
		private System.Windows.Forms.FlowLayoutPanel FlowAllSection;
		private System.Windows.Forms.FlowLayoutPanel FlowSectionInfo;
		private System.Windows.Forms.FlowLayoutPanel FlowSectionBoard;
		private System.Windows.Forms.FlowLayoutPanel FlowPlayer1Info;
		private System.Windows.Forms.TableLayoutPanel TableRowOfColumnLabels;
		private LabelPlayerScore LabelPlayer1Score;
		private System.Windows.Forms.FlowLayoutPanel FlowPlayer2Info;
		private LabelPlayerScore LabelPlayer2Score;
	}
}