using System;

namespace CowTreats
{
	class MainClass
	{
		public static int [,] SwapColumn(int c1, int c2, int [,] f) {
			int temp;
			for (int i = 0; i < f.GetLength(0); i++)
			{
				temp = f [i, c1];
				f [i, c1] = f [i, c2];
				f [i, c2] = temp;

			}
			return f;
		}

		public static int [,] SwapRow(int r1, int r2, int [,] f) {
			int temp;
			for (int i = 0; i < f.GetLength(1); i++)
			{
				temp = f [r1, i];
				f [r1, i] = f [r2, i];
				f [r2, i] = temp;

			}
			return f;
		}

		public static void Main (string[] args)
		{
//			int w = 4, h = 3;
			int[,] f = {
				{ 5, 7, 4, 1 },
				{ 9, 99, 2, 6 },
				{ 8, 3, 10, 11 }
			};

			SwapRow(0, 1, f);

			for (int r = 0; r < f.GetLength (0); r++) {
				for (int c = 0; c < f.GetLength (1); c++) {
					Console.Write (String.Format("{0,3}", f [r, c]));
				}
				Console.WriteLine ();
			}


		}
	}
}
