namespace AIS_Airport.Core
{
	/// <summary>
	/// A helper for strings
	/// </summary>
	public static class StringHelpers
	{
		/// <summary>
		/// Converts the string representation of a number to its 32-bit signed integer equivalent.
		//  A return value indicates whether the conversion succeeded.
		/// </summary>
		/// <param name="s">A string containing a number to convert.</param>
		/// <returns>True if s was converted successfully; otherwise, false.</returns>
		public static bool IsInt(this string s)
		{
			return int.TryParse(s, out int x);
		}
	}
}