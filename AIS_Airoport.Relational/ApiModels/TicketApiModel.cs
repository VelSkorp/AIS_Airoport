using System;

namespace AIS_Airoport.Core
{
	/// <summary>
	/// A ticket information
	/// </summary>
	public class TicketApiModel
	{
		/// <summary>
		/// The number of ticket
		/// </summary>
		public string TicketNumber { get; set; }

		/// <summary>
		/// The number of flight
		/// </summary>
		public int FlightNumber { get; set; }

		/// <summary>
		/// The passenger who bought the ticket
		/// </summary>
		public int Passenger { get; set; }

		/// <summary>
		/// The employee who sold the ticket
		/// </summary>
		public int Employee { get; set; }

		/// <summary>
		/// A departure date
		/// </summary>
		public DateTime DepartureDate { get; set; }
	}
}