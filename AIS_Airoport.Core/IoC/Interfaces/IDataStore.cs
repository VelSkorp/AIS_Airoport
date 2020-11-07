using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace AIS_Airoport.Core
{
	/// <summary>
	/// Stores and retrieves information about the client application 
	/// such as login credentials and so on
	/// </summary>
	public interface IDataStore
	{
		/// <summary>
		/// Logs into the application
		/// </summary>
		/// <param name="loginCredentialsApiModel">The credentials for an client to log into the application</param>
		Task<bool> LoginAsync(LoginCredentialsApiModel loginCredentialsApiModel);

		/// <summary>
		/// Makes sure the client data store is correctly set up
		/// </summary>
		/// <returns>Returns a task that will finish once setup is complete</returns>
		Task EnsureDataStoreAsync();

		/// <summary>
		/// Gets the stored ticket information
		/// </summary>
		Task<ObservableCollection<Ticket>> GetCollectionOfTicketsAsync();

		/// <summary>
		/// Gets the stored employee credentials for this client
		/// </summary>
		/// <returns>Returns the employee credentials if they exist, or null if none exist</returns>
		Task<EmployeeCredentials> GetEmployeeCredentialsAsync();

		/// <summary>
		/// Stores the given login credentials to the backing data store
		/// </summary>
		/// <param name="employeeCredentials">The login credentials to save</param>
		/// <returns>Returns a task that will finish once the save is complete</returns>
		Task SaveLoginCredentialsAsync(EmployeeCredentials employeeCredentials);
	}
}