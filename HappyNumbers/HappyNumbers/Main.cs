using System;
using System.Linq;
using System.Collections.Generic;

namespace HappyNumbers
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var happy = new HappyCalculator();

			Console.WriteLine("Calculating up to 500");
			happy.CalculateForRange(1, 500);
			Console.WriteLine("Finished!");

			Console.WriteLine("Happy numbers are:");
			bool first = true;
			foreach(int i in happy.GetCalculatedHappyNumbers())
			{
				if (first)
					first = false;
				else
					Console.Write(", ");

				Console.Write(i.ToString());
			}
			Console.WriteLine();
		}
	}
}
