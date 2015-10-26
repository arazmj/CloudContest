using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvancedASCIICubes
{
	class MainClass
	{
		public const int x = 4, y = 3, z = 2;

		public static string [] cube = 
		{	"..+---+",
			"./   /|",      
			"+---+ |",      
			"|   | +", 
			"|   |/.",
			"+---+.."};

		public class Position {
			public int X { set; get; }
			public int Y { set; get; }
			public override int GetHashCode ()
			{
				return (X + " " + Y).GetHashCode (); 
			}
			public override bool Equals (object obj)
			{
				Position p = (Position)obj;
				return (p.X == X && p.Y == Y);
			}
		}

		public static Dictionary<Position, Char> view = new Dictionary<Position, Char> ();
		
		public static void putCube(int cc, int rc, int zc) {
			int ix = x * cc - rc - rc, iy = rc * z - y * zc;
			for (int r = 0; r < cube.Length; r++)
				for (int c = 0; c < cube[0].Length; c++) {
					var pos = new Position () {
						X = c + ix,
						Y = r + iy
					};
					if (view.ContainsKey (pos)) {
						if (cube [r] [c] != '.')
							view [pos] = cube [r] [c];
					}
					else
						view.Add(pos, cube [r][c]);
				}
		}

		public static void printView() { 
			int minX = view.Keys.Select (p => p.X).Min ();
			int minY = view.Keys.Select (p => p.Y).Min ();
			int maxX = view.Keys.Select (p => p.X).Max ();
			int maxY = view.Keys.Select (p => p.Y).Max ();

			Position pos = new Position ();
			for (int r = minY; r <= maxY; r++) {
				for (int c = minX; c <= maxX; c++) {
					pos.X = c;
					pos.Y = r;
					if (view.ContainsKey (pos))
						Console.Write (view [pos]);
					else
						Console.Write (".");

				}
				Console.WriteLine ();
			}
		}

		public static void Main (string[] args)
		{
			int[,] a;
			string s; string[] sa; 
			s = Console.ReadLine ();
			sa = s.Split (' ');
			int m = Int32.Parse (sa [0]);
			int n = Int32.Parse (sa [1]);
			a = new int[m, n];
			for (int i = 0; i < m; i++) {
				s = Console.ReadLine ();
				sa = s.Split (' ');
				for (int j = 0; j < n; j++)
					a [i, j] = Int32.Parse(sa [j]);
			}

			int zmax =  a.Cast<int>().Max();
			for (int z = 0; z < zmax; z++) {
				for (int r = 0; r < a.GetLength (0); r++) {
					for (int c = 0; c < a.GetLength (1); c++) {
						if (a [r, c] > 0) {
							putCube (c, r, z);
							a [r, c]--;
						}

					}
				}
			}

			printView();
		}
	}
}
