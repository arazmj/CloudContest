using System;
using System.Collections.Generic;
using System.Linq;

namespace FlowLayout
{
	class MainClass
	{
		public class Rect {
			public int Width {get; set;}
			public int Hieght {get; set;}

		}
		public static void Main (string[] args)
		{
			while (true) {
				int w = Convert.ToInt32(Console.ReadLine());
				if (w == 0)
					break;
				List<Rect> rects = new List<Rect> ();

				while (true) {
					string s = Console.ReadLine ();
					int a = Convert.ToInt32 (s.Split() [0]);
					int b = Convert.ToInt32 (s.Split() [1]);
					if (a == -1 || b == -1)
						break;
					rects.Add (new Rect () { Width = a, Hieght = b });
				}


				var win = new List<List<Rect>> ();

				int row = 0;
				win.Add (new List<Rect> ());
				foreach (Rect r in rects) {
					
					if (win[row].Select (p => p.Width).Sum () + r.Width > w) {
						win.Add (new List<Rect> ());
						row++;
					}
					win[row].Add (r);

				}

//				foreach (var l in win) {
//					foreach (var r in l) {
//						Console.Write (r.Width + ":" + r.Hieght + " ");
//					}
//					Console.WriteLine ();
//				}
//
				int width = win.Select (list => list.Select (r => r.Width).Sum ()).Max ();
				int height = win.Select (list => list.Select (r => r.Hieght).Max ()).Sum ();
				Console.WriteLine (width + " x " + height);

			}
		}
	}
}
