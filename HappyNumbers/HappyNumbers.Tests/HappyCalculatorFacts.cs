using System;
using NUnit.Framework;
using HappyNumbers;
using System.Collections.Generic;

namespace HappyNumbers.Tests
{
	[TestFixture]
	public class HappyCalculatorFacts
	{
		public class TheIsHappyMethodShould
		{
			[Test]
			public void Given1ReturnTrue()
			{
				var happy = new HappyCalculator();

				Assert.AreEqual(true, happy.IsHappy(1));
			}

			[Test]
			public void Given2ReturnFalse()
			{
				var happy = new HappyCalculator();

				Assert.AreEqual(false, happy.IsHappy(2));
			}

			[Test]
			public void Given7ReturnTrue()
			{
				var happy = new HappyCalculator();

				Assert.AreEqual(true, happy.IsHappy(7));
			}
		}

		public class TheCalculateForRangeMethod
		{
			[Test]
			public void Given1To500ShouldFindFirst500HappyNumbers()
			{
				var happy = new HappyCalculator();

				// Source: http://en.wikipedia.org/wiki/Happy_number
				SortedSet<int> first500 = new SortedSet<int>(new int[] { 1, 7, 10, 13, 19, 23, 28, 31, 32, 44, 49, 68, 70, 79, 82, 86, 91, 94, 97, 100, 103, 109, 129, 130, 133, 139, 167, 176, 188, 190, 192, 193, 203, 208, 219, 226, 230, 236, 239, 262, 263, 280, 291, 293, 301, 302, 310, 313, 319, 320, 326, 329, 331, 338, 356, 362, 365, 367, 368, 376, 379, 383, 386, 391, 392, 397, 404, 409, 440, 446, 464, 469, 478, 487, 490, 496 });

				happy.CalculateForRange(1, 500);
				SortedSet<int> calculated = happy.GetCalculatedHappyNumbers();

				Assert.IsTrue(first500.SetEquals(calculated));
			}
		}
	}
}

