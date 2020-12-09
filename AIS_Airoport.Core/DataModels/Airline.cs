namespace AIS_Airoport.Core
{
	/// <summary>
	/// An airline information
	/// </summary>
	public class Airline
	{
		/// <summary>
		/// The code of airline
		/// </summary>
		public int Code { get; set; }

		/// <summary>
		/// The airline name
		/// </summary>
		public string Nomination { get; set; }

		/// <summary>
		/// The airline contact details
		/// </summary>
		public string Сontacts { get; set; }

		/// <summary>
		/// Airline head office address
		/// </summary>
		public string HeadOfficeAddress { get; set; }
	}
}