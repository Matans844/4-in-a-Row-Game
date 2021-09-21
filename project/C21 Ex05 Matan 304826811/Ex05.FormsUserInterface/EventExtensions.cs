using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Ex05.FormsUserInterface
{
	public static class EventExtensions
	{
		public static void Delay(int i_Milliseconds, EventHandler i_Action)
		{
			var tmp = new Timer { Interval = i_Milliseconds };
			tmp.Tick += new EventHandler((sender, e) => tmp.Enabled = false);
			tmp.Tick += i_Action;
			tmp.Enabled = true;
		}
	}
}
