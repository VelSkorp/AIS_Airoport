namespace AIS_Airoport.Core
{
    /// <summary>
    /// Employee position
    /// </summary>
    public class Position
    {
        /// <summary>
        /// Position code
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Job Title
        /// </summary>
        public string Nomination { get; set; }

        /// <summary>
        /// Right to sell tickets
        /// </summary>
        public bool RightToSellTickets { get; set; }

        /// <summary>
        /// Right to add new flights
        /// </summary>
        public bool RightToAddNewFlights { get; set; }

        /// <summary>
        /// Right to add new employees
        /// </summary>
        public bool RightToAddNewEmployees { get; set; }
    }
}