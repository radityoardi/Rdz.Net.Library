using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace System
{
	public static class Extensions
	{
		#region Double
		public static bool IsPositive(this double input)
		{
			return (!double.IsNaN(input) && input > 0);
		}
		public static bool IsNegative(this double input)
		{
			return (!double.IsNaN(input) && input < 0);
		}
		public static bool IsZero(this double input)
		{
			return (!double.IsNaN(input) && input == 0);
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
		#endregion

		#region Int32
		public static bool IsPositive(this int input)
		{
			return (input > 0);
		}
		public static bool IsNegative(this int input)
		{
			return (input < 0);
		}
		public static bool IsZero(this int input)
		{
			return (input == 0);
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
		#endregion

		#region String
		public static string FormatTemplate(this string input, dynamic data)
		{
			int indexer = 0;
			List<object> values = new List<object>();
			string output = input;

			if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
			{
				throw new ArgumentNullException("input is required.");
			}

			if (data == null)
			{
				throw new ArgumentNullException("data is required.");
			}

			foreach (System.Reflection.PropertyInfo prop in data.GetType().GetProperties())
			{
				string dynamicPatterns = "(?<=\\{)" + prop.Name + "(?=(,[^\\{\\}]*){0,1}(:[^\\{\\}]*){0,1}\\})";
				Regex re = new Regex(dynamicPatterns);
				if (re.IsMatch(input))
				{
					output = re.Replace(output, indexer.ToString());
					values.Add(prop.GetValue(data));
					indexer++;
				}
			}
			return values.Count > 0 ? String.Format(output, values.ToArray()) : output;
		}
		#endregion

	}
}
