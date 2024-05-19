﻿namespace AIS_Airport.Core
{
	/// <summary>
	/// A ticket information
	/// </summary>
	public class Ticket
	{
		/// <summary>
		/// The number of ticket
		/// </summary>
		public string TicketNumber { get; set; }

		/// <summary>
		/// The number of flight
		/// </summary>
		public string FlightNumber { get; set; }

		/// <summary>
		/// An airline serving the plane
		/// </summary>
		public string Airline { get; set; }

		/// <summary>
		/// The destination of flight
		/// </summary>
		public string Destination { get; set; }

		/// <summary>
		/// The passenger who bought the ticket
		/// </summary>
		public string Passenger { get; set; }

		/// <summary>
		/// The employee who sold the ticket
		/// </summary>
		public string Employee { get; set; }

		/// <summary>
		/// A departure date
		/// </summary>
		public DateTime DepartureDate { get; set; }

		/// <summary>
		/// A ticket price
		/// </summary>
		public decimal Cost { get; set; }
	}
}