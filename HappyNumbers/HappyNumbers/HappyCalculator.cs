using System;
using System.Collections.Generic;

namespace HappyNumbers
{
	public class HappyCalculator
	{
		private SortedSet<int> _happyNumbers;
		private SortedSet<int> _unhappyNumbers;

		public HappyCalculator()
		{
			_happyNumbers = new SortedSet<int>();
			_unhappyNumbers = new SortedSet<int>();
		}

		public void CalculateForRange(int start, int end)
		{
			for (int x = start ; x <= end ; x++)
			{
				Calculate(x);
			}
		}

		public void Calculate(int number)
		{
			HappyResults result = new HappyResults { HappyNumbers = _happyNumbers,
				                                     UnhappyNumbers = _unhappyNumbers,
													 NumberTried = number };
			result = GetHappyResults(result);
			_happyNumbers.UnionWith(result.HappyNumbers);
			_unhappyNumbers.UnionWith(result.UnhappyNumbers);

			if (result.IsHappy)
			{
				_happyNumbers.Add(number);
			} else {
				_unhappyNumbers.Add(number);
			}
		}

		public SortedSet<int> GetCalculatedHappyNumbers()
		{
			return _happyNumbers;
		}

		private static HappyResults GetHappyResults(HappyResults result)
		{
			int num = result.NumberTried;

			int happiness = 0;

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
				happiness += digit*digit;
			}

			if (happiness == 1)
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
			result.NumberTried = happiness;

			return GetHappyResults(result);
		}

		public bool HasBeenCalculated(int number)
		{
			return _happyNumbers.Contains(number) || _unhappyNumbers.Contains(number);
		}

		public bool IsHappy(int number)
		{
			if (!HasBeenCalculated(number))
			{
				Calculate(number);
			}

			return _happyNumbers.Contains(number);
		}


	}
}

