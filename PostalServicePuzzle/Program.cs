using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalServicePuzzle
{
	class Program
	{
		static void Main(string[] args)
		{
			Extensions.test();
			Console.ReadLine();
			
			Stamps stamps = new Stamps(new[] {
				0.01, 0.02, 0.03, 0.04, 0.05, 0.10, 
				0.24, 0.37, 0.39, 0.41, 0.48, 0.60, 
				0.63, 0.70, 0.75, 0.80, 0.83, 0.84,
				0.87, 1.00, 3.85, 4.05, 4.60, 5.00, 14.4 });

			double i = 0.06;
			int numOfStamps;
			do
			{
				numOfStamps = stamps.CalculateMinNumOfStampsNeeded(i);
				Console.WriteLine("{0:0.00} needs {1} stamps", i, numOfStamps);
				i += 0.01;
			} while (numOfStamps < 11);

			Console.Write("Press Enter to exit...");
			Console.ReadLine();
		}
	}

	public static class Extensions
	{
		public static string ToUpper(this string s)
		{
			return s;
		}

		public static void test()
		{
			string s = "Test";
			Console.WriteLine(s.ToUpper());
		}
	}
}
