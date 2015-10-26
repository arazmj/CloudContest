using System;
using System.Collections.Generic;

namespace WormHoles
{
	class MainClass
	{
		public const int MAX  = 12;
		public static int holeCount;
		public static int[] partner = new int[MAX + 1];
		public static int[] next = new int[MAX + 1];

		public class Hole {
			public int X { get; set; }
			public int Y { get; set; }
		}
		public static List<Hole> holes = new List<Hole>();


		public static bool IsCycle()
		{
			for (int i = 1; i <= holeCount; i++) {
				int pos = i;
				for (int count=0; count<holeCount; count++)
					pos = next[partner[pos]];
				if (pos != 0) return true;
			}
			return false;
		}

		public static int CountCycles()
		{
			int i, sum = 0;
			for (i = 1; i <= holeCount; i++)
				if (partner[i] == 0) break;

			if (i > holeCount) {
				if (IsCycle()) return 1;
				else return 0;
			}

			for (int j = i + 1; j <= holeCount; j++)
				if (partner[j] == 0) {
					partner[i] = j;
					partner[j] = i;
					sum += CountCycles();
					partner[i] = partner[j] = 0;
				}
			return sum;
		}


		public static void Main (string[] args)
		{
			holeCount = Convert.ToInt32(Console.ReadLine());
			holes.Add (null);
			for (int i = 1; i <= holeCount; i++) {
				string s = Console.ReadLine ();
				string[] sa = s.Split ();
				holes.Add (new Hole() { 
					X = Convert.ToInt32(sa[0]),
					Y = Convert.ToInt32(sa[1])});
			}

			for (int i = 1; i <= holeCount; i++) 
				for (int j=1; j<=holeCount; j++)
					if (holes[j].X > holes[i].X && holes[i].Y == holes[j].Y) 
					if (next[i] == 0 ||
						holes[j].X - holes[i].X < holes[next[i]].X- holes[i].X)
						next[i] = j;
			
			Console.WriteLine (CountCycles());
		}
	}
}
