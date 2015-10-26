using System;

namespace ASpiralwalk
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			int n = Convert.ToInt32 (Console.ReadLine ());
			int[,] a = new int[n + 1,n + 2];

			for (int k = 0; k <= n; k++) {
				a [k, 0] = -1; 
				//a [0, k] = -1;
				a [n, k + 1] = -1; 
				a [k, n + 1] = -1; 
			}

			int r = 0, c = 1;
			int i = 1;
			int dir = 0;
			while (true) {
				int d = dir % 4;
				a[r, c] = i++;
				if (d == 0) {
					c ++; 

					if (a [r, c] != 0) {
						dir++;
						c--;
						r++;
					}

				} else if (d == 1) {
					r ++;
					if (a [r, c] != 0) {
						dir++;
						r--;
						c--;
					}
				} else if (d == 2) {
					c --;
					if (a [r, c] != 0) {
						dir++;
						c++;
						r--;
					}
				} else if (d == 3) {
					r --; 
					if (a [r, c] != 0) {
						dir++;
						r++;
						c++;
					}
				} 
				if (i >=  (n ) * (n) + 1)
					break;
			}

			for (i = 0; i <= n - 1; i++) {
				for (int j = 1; j <= n; j++) {
					Console.Write (a [i, j] + " ");
				}
				Console.WriteLine();
			}
		}
	}
}
