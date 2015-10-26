using System;
using System.Collections.Generic;
using System.Linq;

namespace Argus
{
	class MainClass
	{
		static int GCD(int[] numbers)
		{
			return numbers.Aggregate(GCD);
		}

		static int GCD(int a, int b)
		{
			return b == 0 ? a : GCD(b, a % b);
		}
			
		public class Query {
			public int Q { get; set; }
			public int P { get; set; }
			public int T { get; set; }
		}
		public static void Main (string[] args)
		{
			List<Query> list = new List<Query>();

			string s;
			string[] sa;
			do {
				s = Console.ReadLine();
				if (s.Contains("#"))
					break;
				sa = s.Split();
				list.Add (new Query () { 
					Q = Convert.ToInt32(sa[1]), 
					P = Convert.ToInt32(sa[2])});
			} while (true);
			int k = Convert.ToInt32 (Console.ReadLine ());

			List<Query> generated = new List<Query>();

			int gcd = GCD (list.Select (p => p.P).ToArray ());

			for (int time = gcd; generated.Count < k; time += gcd) {
				foreach (Query q in list) {
					if (time % q.P == 0)
						generated.Add (new Query () { Q = q.Q, P = q.P, T = time });
				}
			}

			var sorted = generated
				.OrderBy (p => p.T)
				.ThenBy(q => q.Q)
				.Take(k);

			foreach (Query q in sorted) {
				Console.WriteLine (q.Q);
			}
		}
	}
}
