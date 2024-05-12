namespace AIS_Airport.Core
{
    /// <summary>
    /// The credentials for an client to log into the application and receive login credentials
    /// </summary>
    public class LoginCredentialsApiModel
    {
        #region Public Properties

        /// <summary>
        /// The users username
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// The users password
        /// </summary>
        public string Password { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public LoginCredentialsApiModel()
        {

        }

        #endregion
    }
}