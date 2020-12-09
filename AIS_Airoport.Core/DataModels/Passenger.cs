namespace AIS_Airoport.Core
{
	/// <summary>
	/// A passenger information
	/// </summary>
	public class Passenger
	{
		/// <summary>
		/// The passenger ID
		/// </summary>
		public int ID { get; set; }

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
		public int Passport { get; set; }

		/// <summary>
		/// The discount for this passenger
		/// </summary>
		public string Discount { get; set; }
	}
}