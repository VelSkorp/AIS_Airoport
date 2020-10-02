namespace AIS_Airoport.Core
{
    /// <summary>
    /// Passenger information for passengers page
    /// </summary>
    public class PassengerViewModel
    {
        /// <summary>
        /// The passenger surname
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// The passenger first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The passenger middle name
        /// </summary>
        public string Patronymic { get; set; }

        /// <summary>
        /// The passenger phone
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// The passenger address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// The passenger passport
        /// </summary>
        public string Passport { get; set; }

        /// <summary>
        /// The discount for this passenger
        /// </summary>
        public string Discount { get; set; }
    }
}