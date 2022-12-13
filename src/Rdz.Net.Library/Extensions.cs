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
		#region Object
		/// <summary>
		/// Test if an object is null.
		/// </summary>
		public static bool IsNull(this object input)
		{
			return input == null;
		}
		#endregion

		#region Double
		/// <summary>
		/// Returns true when it's positive.
		/// </summary>
		public static bool IsPositive(this double input)
		{
			return (!double.IsNaN(input) && input > 0);
		}
		/// <summary>
		/// Returns true when it's negative.
		/// </summary>
		public static bool IsNegative(this double input)
		{
			return (!double.IsNaN(input) && input < 0);
		}
		/// <summary>
		/// Returns true when it's zero.
		/// </summary>
		public static bool IsZero(this double input)
		{
			return (!double.IsNaN(input) && input == 0);
		}
		/// <summary>
		/// Returns true when it's above the comparer.
		/// </summary>
		/// <param name="comparer">The value to compare.</param>
		public static bool IsAbove(this double input, double comparer)
		{
			return input > comparer;
		}
		/// <summary>
		/// Returns true when it's above or equal the comparer.
		/// </summary>
		/// <param name="comparer">The value to compare.</param>
		public static bool IsAboveOrEqual(this double input, double comparer)
		{
			return input >= comparer;
		}
		/// <summary>
		/// Returns true when it's below the comparer.
		/// </summary>
		/// <param name="comparer">The value to compare.</param>
		public static bool IsBelow(this double input, double comparer)
		{
			return input < comparer;
		}
		/// <summary>
		/// Returns true when it's below or equal the comparer.
		/// </summary>
		/// <param name="comparer">The value to compare.</param>
		public static bool IsBelowOrEqual(this double input, double comparer)
		{
			return input <= comparer;
		}
		/// <summary>
		/// Returns true when it's between both comparer.
		/// </summary>
		/// <param name="comparerA">The floor value to compare.</param>
		/// <param name="comparerB">The ceiling value to compare.</param>
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

		/// <summary>
		/// Returns true when it's NaN (undefined).
		/// </summary>
		public static bool IsNaN(this double input)
		{
			return double.IsNaN(input);
		}

		/// <summary>
		/// Adds the number precisely (this fix the precision issue.
		/// </summary>
		/// <param name="value">The value to add.</param>
		public static double Add(this double input, double value)
		{
			if (value.IsNaN())
				return double.NaN;
			return input.Add(Convert.ToDecimal(value));
		}

		/// <summary>
		/// Adds the number precisely (this fix the precision issue.
		/// </summary>
		/// <param name="value">The value to add.</param>
		public static double Add(this double input, decimal value)
		{
			if (input.IsNaN())
				return double.NaN;
			return Convert.ToDouble(Convert.ToDecimal(input) + value);
		}
		#endregion

		#region Int32
		/// <summary>
		/// Returns true when it's positive.
		/// </summary>
		public static bool IsPositive(this int input)
		{
			return (input > 0);
		}
		/// <summary>
		/// Returns true when it's negative.
		/// </summary>
		public static bool IsNegative(this int input)
		{
			return (input < 0);
		}
		/// <summary>
		/// Returns true when it's zero.
		/// </summary>
		public static bool IsZero(this int input)
		{
			return (input == 0);
		}
		/// <summary>
		/// Returns true when it's above the comparer.
		/// </summary>
		/// <param name="comparer">The value to compare.</param>
		public static bool IsAbove(this int input, int comparer)
		{
			return input > comparer;
		}
		/// <summary>
		/// Returns true when it's above or equal the comparer.
		/// </summary>
		/// <param name="comparer">The value to compare.</param>
		public static bool IsAboveOrEqual(this int input, int comparer)
		{
			return input >= comparer;
		}
		/// <summary>
		/// Returns true when it's below the comparer.
		/// </summary>
		/// <param name="comparer">The value to compare.</param>
		public static bool IsBelow(this int input, int comparer)
		{
			return input < comparer;
		}
		/// <summary>
		/// Returns true when it's below or equal the comparer.
		/// </summary>
		/// <param name="comparer">The value to compare.</param>
		public static bool IsBelowOrEqual(this int input, int comparer)
		{
			return input <= comparer;
		}

		/// <summary>
		/// Returns true when it's between both comparer.
		/// </summary>
		/// <param name="comparerA">The floor value to compare.</param>
		/// <param name="comparerB">The ceiling value to compare.</param>
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
		/// <summary>
		/// Test whether string is exist (not null, not empty, nor whitespace)
		/// </summary>
		public static bool IsExist(this string input)
		{
			return input != null && !string.IsNullOrEmpty(input) && !string.IsNullOrWhiteSpace(input);
		}

		/// <summary>
		/// Format a string template based on the dynamic input data.
		/// </summary>
		public static string FormatTemplate(this string input, dynamic data)
		{
			int indexer = 0;
			List<object> values = new List<object>();
			string output = input;

			if (!input.IsExist())
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

		#region DateTime
		/// <summary>
		/// Convert DateTime to string in ISO 8601 format.
		/// </summary>
		public static string ToISO8601(this DateTime input)
		{
			return input.ToString("s", System.Globalization.CultureInfo.InvariantCulture);
		}
		#endregion
	}
}
