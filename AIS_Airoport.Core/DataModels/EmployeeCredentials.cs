namespace AIS_Airoport.Core
{
	/// <summary>
	/// The data model for the login credentials of a employee
	/// </summary>
	public class EmployeeCredentials
	{
		/// <summary>
		/// The unique Id
		/// </summary>
		public string ID { get; set; }

		/// <summary>
		/// The employee last name
		/// </summary>
		public string Surname { get; set; }

		/// <summary>
		/// The employee first name
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// The employee patronymic
		/// </summary>
		public string Patronymic { get; set; }

		/// <summary>
		/// The employee phone
		/// </summary>
		public string Phone { get; set; }

		/// <summary>
		/// The employee address
		/// </summary>
		public string Address { get; set; }

		/// <summary>
		/// The employee password
		/// </summary>
		public string Password { get; set; }

		/// <summary>
		/// The position occupied by the employee
		/// </summary>
		public string Position { get; set; }
	}
}