using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1 {
	public partial class Form1 : Form {
		Graphics gb, gf; Bitmap gi;

		public Form1() {InitializeComponent();}
		private void Form1_Load(object sender, EventArgs e) {
			gi = new Bitmap(Width, Height);
			gb = Graphics.FromImage(gi);
			gf = CreateGraphics();

			gb.Clear(Color.Red); bool dot = false;
			long k = 0xFFFFFFFFFFFF000; long y = k;
			for(int Y = 0 ; Y < 1024 ; Y++) {
				y = Y + k;
				for(int x = 0 ; x < 200 ; x++) {
					dot = (0.5 < Math.Floor((Math.Floor(y / 17.0) * Math.Pow(2.0, -17.0 * x - (y % 17.0))) % 2.0));
					gi.SetPixel(x, 1023 - Y, dot ? Color.White : Color.Black);
				}
			}
		
		}

		private void Form1_Paint(object sender, PaintEventArgs e) {
			gf.DrawImage(gi, 0, 0);
		}

		private void Form1_KeyDown(object sender, KeyEventArgs e) {
			switch(e.KeyCode) {
				case Keys.Escape: Close(); break;

			}
		}
	}
}
