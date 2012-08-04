using System;
using System.Linq;
using System.Collections.Generic;

namespace HappyNumbers
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			SortedSet<int> happyNumbers = new SortedSet<int>();
			SortedSet<int> unhappyNumbers = new SortedSet<int>();

			for (int x = 1 ; x <= 500 ; x++)
			{
				HappyResults result = new HappyResults { HappyNumbers = happyNumbers,
					                                     UnhappyNumbers = unhappyNumbers,
														 NumberTried = x };
				result = GetHappyResults(result);
				happyNumbers.UnionWith(result.HappyNumbers);
				unhappyNumbers.UnionWith(result.UnhappyNumbers);

				if (result.IsHappy)
				{
					if ( x > 1 )
					{
						Console.Write(", ");
					}
					Console.Write(x.ToString());
				}
			}
			Console.WriteLine();

			Console.WriteLine("Finished!");
		}

		public static HappyResults GetHappyResults(HappyResults result)
		{
			int num = result.NumberTried;

			int happyness = 0;

			// Check if we know about this number already
			if (result.HappyNumbers.Contains(num))
			{
				result.IsHappy = true;
				return result;
			}
			if (result.UnhappyNumbers.Contains(num))
			{
				result.IsHappy = false;
				return result;
			}
			if (result.NumbersTried.Contains(num)) // already tried so must be unhappy
			{
				result.UnhappyNumbers.Add(num);
				result.IsHappy = false;
				return result;
			}

			result.NumbersTried.Add(num);
			string stringNum = num.ToString();

			// split the digits up
			List<int> digits = new List<int>();
			for (int i=0; i < stringNum.Length; i++)
			{
				string s = stringNum.Substring(i, 1);
				digits.Add(Int32.Parse(s));
			}

			foreach(int digit in digits)
			{
				happyness += digit*digit;
			}

			if (happyness == 1)
			{
				result.HappyNumbers.Add(num);
				result.IsHappy = true;
				return result;
			}
			if (result.TriesLeft == 0)
			{
				Console.WriteLine("Out of tries for " + result.NumberTried.ToString() + " assuming unhappy");
				result.UnhappyNumbers.Add(num);
				result.IsHappy = false;
			    return result;
			}

			result.TriesLeft--;
			result.NumberTried = happyness;

			return GetHappyResults(result);
		}
	}
}
