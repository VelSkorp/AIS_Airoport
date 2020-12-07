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
		/// Gets the stored airlines information
		/// </summary>
		Task<ObservableCollection<Airline>> GetCollectionOfAirlinesAsync();

		/// <summary>
		/// Gets the stored airplanes information
		/// </summary>
		Task<ObservableCollection<Airplane>> GetCollectionOfAirplanesAsync();

		/// <summary>
		/// Gets the stored destinations information
		/// </summary>
		Task<ObservableCollection<Destination>> GetCollectionOfDestinationsAsync();

		/// <summary>
		/// Gets the stored discounts information
		/// </summary>
		Task<ObservableCollection<Discount>> GetCollectionOfDiscountsAsync();

		/// <summary>
		/// Gets the stored flights information
		/// </summary>
		Task<ObservableCollection<Flight>> GetCollectionOfFlightsAsync();

		/// <summary>
		/// Gets the stored passengers information
		/// </summary>
		Task<ObservableCollection<Passenger>> GetCollectionOfPassengersAsync();

		/// <summary>
		/// Gets the stored positions information
		/// </summary>
		Task<ObservableCollection<Position>> GetCollectionOfPositionsAsync();

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