using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Ex05.FormsUserInterface
{
	public class BoardSizeSettings
	{
		private const int k_LabelHeight = 40;
		private const int k_LabelWidth = 100;
		private const int k_ButtonCellHeight = 100;
		private const int k_ButtonCellWidth = 100;
		private const int k_DistanceBetweenBoardRowElements = 20;
		private const int k_DistanceBetweenBoardColumnElements = 20;
		private int m_BoardNumberOfRows;
		private int m_BoardNumberOfColumns;
		private int m_BoardHeight;
		private int m_BoardWidth;

		public int BoardRows
		{
			get => this.m_BoardNumberOfRows;
			set => this.m_BoardNumberOfRows = value;
		}

		public int BoardColumns
		{
			get => this.m_BoardNumberOfColumns;
			set => this.m_BoardNumberOfColumns = value;
		}

		public int BoardHeight
		{
			get => this.m_BoardHeight;
			private set => this.m_BoardHeight = value;
		}

		public int BoardWidth
		{
			get => this.m_BoardWidth;
			private set => this.m_BoardWidth = value;
		}

		public BoardSizeSettings()
		{
		}

		public void UpdateBoardDimensions()
		{
			this.BoardWidth = (this.BoardColumns * (k_DistanceBetweenBoardColumnElements + k_ButtonCellWidth)) - k_DistanceBetweenBoardColumnElements;
			this.BoardHeight = (this.BoardRows * (k_DistanceBetweenBoardRowElements + k_ButtonCellHeight)) + k_LabelHeight;
		}

		/*		private int MeasureStringMin(string i_StringToMeasure, PaintEventArgs e)
				{
					SizeF stringSize = new SizeF();
		
					// Set up string.
					string measureString = "Measure String";
					Font stringFont = new Font("Arial", k_FontSize);
		
					// Measure string.
					stringSize = e.Graphics.MeasureString(i_StringToMeasure, stringFont);
		
					return (int)stringSize.Width + k_SpacingBuffer;
				}*/
	}
}
