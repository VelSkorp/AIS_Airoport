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
        /// Right to sell tickets (1 or 0)
        /// </summary>
        public int RightToSellTickets { get; set; }

        /// <summary>
        /// Right to add new flights (1 or 0)
        /// </summary>
        public int RightToAddNewFlights { get; set; }

        /// <summary>
        /// Right to add new employees (1 or 0)
        /// </summary>
        public int RightToAddNewEmployees { get; set; }
    }
}