using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
	public static class Extensions
	{
		public static bool IsPositive(this double input)
		{
			return (!double.IsNaN(input) && input > 0);
		}
		public static bool IsPositive(this int input)
		{
			return (input > 0);
		}
		public static bool IsNegative(this double input)
		{
			return (!double.IsNaN(input) && input < 0);
		}
		public static bool IsNegative(this int input)
		{
			return (input < 0);
		}
		public static bool IsZero(this double input)
		{
			return (!double.IsNaN(input) && input == 0);
		}
		public static bool IsZero(this int input)
		{
			return (input == 0);
		}
		public static bool IsAbove(this double input, double comparer)
		{
			return input > comparer;
		}
		public static bool IsAboveOrEqual(this double input, double comparer)
		{
			return input >= comparer;
		}
		public static bool IsBelow(this double input, double comparer)
		{
			return input < comparer;
		}
		public static bool IsBelowOrEqual(this double input, double comparer)
		{
			return input <= comparer;
		}
		public static bool IsBetween(this double input, double comparerA, double comparerB)
		{
			if (comparerA >= comparerB)
			{
				return input.IsBelowOrEqual(comparerA) && input.IsAboveOrEqual(comparerB);
			}
			else if (comparerA <= comparerB)
			{
				return input.IsBelowOrEqual(comparerB) && input.IsAboveOrEqual(comparerA);
			}
			else
				return input == comparerA && input == comparerB;
		}
		public static bool IsAbove(this int input, int comparer)
		{
			return input > comparer;
		}
		public static bool IsAboveOrEqual(this int input, int comparer)
		{
			return input >= comparer;
		}
		public static bool IsBelow(this int input, int comparer)
		{
			return input < comparer;
		}
		public static bool IsBelowOrEqual(this int input, int comparer)
		{
			return input <= comparer;
		}
		public static bool IsBetween(this int input, int comparerA, int comparerB)
		{
			if (comparerA >= comparerB)
			{
				return input.IsBelowOrEqual(comparerA) && input.IsAboveOrEqual(comparerB);
			}
			else if (comparerA <= comparerB)
			{
				return input.IsBelowOrEqual(comparerB) && input.IsAboveOrEqual(comparerA);
			}
			else
				return input == comparerA && input == comparerB;
		}

	}
}
