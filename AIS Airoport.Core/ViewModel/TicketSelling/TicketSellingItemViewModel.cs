using System;

namespace AIS_Airoport.Core
{
    /// <summary>
    /// A ticket selling item
    /// </summary>
    public class TicketSellingItemViewModel
    {
        /// <summary>
        /// The number of flight
        /// </summary>
        public string FlightNumber { get; set; }

        /// <summary>
        /// The number of ticket
        /// </summary>
        public string TicketNumber { get; set; }

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
    }
}