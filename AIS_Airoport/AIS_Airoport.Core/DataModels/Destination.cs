﻿namespace AIS_Airport.Core
{
	/// <summary>
	/// An destination information
	/// </summary>
	public class Destination
	{
		/// <summary>
		/// The code of destination
		/// </summary>
		public int Code { get; set; }

		/// <summary>
		/// The destination name
		/// </summary>
		public string Nomination { get; set; }

		/// <summary>
		/// Destination adress
		/// </summary>
		public string Adress { get; set; }

		/// <summary>
		/// Destination coordinates
		/// </summary>
		public string Сoordinates { get; set; }
	}
}