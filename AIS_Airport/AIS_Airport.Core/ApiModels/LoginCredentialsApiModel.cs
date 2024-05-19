namespace AIS_Airport.Core
{
	/// <summary>
	/// The credentials for an client to log into the application and receive login credentials
	/// </summary>
	public class LoginCredentialsApiModel
	{
		/// <summary>
		/// The users username
		/// </summary>
		public string Surname { get; set; }

		/// <summary>
		/// The users password
		/// </summary>
		public string Password { get; set; }
	}
}