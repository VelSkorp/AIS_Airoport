namespace AIS_Airport.Relational
{
	/// <summary>
	/// A flight api information
	/// </summary>
	public class FlightApiModel
	{
		/// <summary>
		/// The code of flight
		/// </summary>
		public int Code { get; set; }

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
		public int Airline { get; set; }

		/// <summary>
		/// A ticket price
		/// </summary>
		public int TicketPrice { get; set; }

		/// <summary>
		/// A arrival point
		/// </summary>
		public int Destination { get; set; }

		/// <summary>
		/// Airplane used for flight
		/// </summary>
		public int Airplane { get; set; }
	}
}