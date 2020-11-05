using System;

namespace AIS_Airoport.Core
{
	/// <summary>
	/// A flight information
	/// </summary>
	public class Flight
	{
		/// <summary>
		/// The code of flight
		/// </summary>
		public string Code { get; set; }

		/// <summary>
		/// The number of flight
		/// </summary>
		public string FlightNumber { get; set; }

		/// <summary>
		/// A departure date
		/// </summary>
		public DateTime StartDate { get; set; }

		/// <summary>
		/// A departure time
		/// </summary>
		public string StartTime { get; set; }

		/// <summary>
		/// An airline serving the plane
		/// </summary>
		public string Airline { get; set; }

		/// <summary>
		/// A ticket price
		/// </summary>
		public decimal TicketPrice { get; set; }

		/// <summary>
		/// A arrival point
		/// </summary>
		public string Destination { get; set; }

		/// <summary>
		/// Airplane used for flight
		/// </summary>
		public string Airplane { get; set; }
	}
}