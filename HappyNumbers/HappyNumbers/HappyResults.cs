using System;
using System.Collections.Generic;

namespace HappyNumbers
{
	public class HappyResults
	{
		public SortedSet<int> HappyNumbers;
		public SortedSet<int> UnhappyNumbers;
		public SortedSet<int> NumbersTried;
		public int NumberTried;
		public bool IsHappy;
		public int MaxTries = 1000;
		public int TriesLeft = 1000;

		public HappyResults()
		{
			HappyNumbers = new SortedSet<int>();
			UnhappyNumbers = new SortedSet<int>();
			NumbersTried = new SortedSet<int>();
			NumberTried = 0;
			IsHappy = false;
		}
	}
}

