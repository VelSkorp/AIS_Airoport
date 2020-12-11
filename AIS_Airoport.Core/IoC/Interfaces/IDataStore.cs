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
		/// Gets the stored employee information
		/// </summary>
		Task<ObservableCollection<EmployeeCredentials>> GetCollectionOfEmployeesAsync();

		/// <summary>
		/// Gets the stored employee credentials for this client
		/// </summary>
		/// <returns>Returns the employee credentials if they exist, or null if none exist</returns>
		Task<EmployeeCredentials> GetEmployeeCredentialsAsync();

		/// <summary>
		/// Gets the stored employee right to add new flights information
		/// </summary>
		Task<bool> GetEmployeeRightToAddNewFlightsAsync();

		/// <summary>
		/// Gets the stored employee right to sell tickets
		/// </summary>
		Task<bool> GetEmployeeRightToSellTicketsAsync();

		/// <summary>
		/// Gets the stored employee right to add new employees 
		/// </summary>
		Task<bool> GetEmployeeRightToAddNewEmployeesAsync();

		/// <summary>
		/// Stores the given login credentials to the backing data store
		/// </summary>
		/// <param name="employeeCredentials">The login credentials to save</param>
		/// <returns>Returns a task that will finish once the save is complete</returns>
		Task<bool> SaveLoginCredentialsAsync(EmployeeCredentials employeeCredentials);

		/// <summary>
		/// Stores the given airline credentials to the backing data store
		/// </summary>
		/// <param name="airlineCredentials">The airline credentials to save</param>
		/// <returns>Returns a task that will finish once the save is complete</returns>
		Task<bool> SaveAirlineCredentialsAsync(Airline airlineCredentials);

		/// <summary>
		/// Stores the given airplane credentials to the backing data store
		/// </summary>
		/// <param name="airplaneCredentials">The airplane credentials to save</param>
		/// <returns>Returns a task that will finish once the save is complete</returns>
		Task<bool> SaveAirplaneCredentialsAsync(Airplane airplaneCredentials);

		/// <summary>
		/// Stores the given destination credentials to the backing data store
		/// </summary>
		/// <param name="destinationCredentials">The destination credentials to save</param>
		/// <returns>Returns a task that will finish once the save is complete</returns>
		Task<bool> SaveDestinationCredentialsAsync(Destination destinationCredentials);

		/// <summary>
		/// Stores the given discount credentials to the backing data store
		/// </summary>
		/// <param name="discountCredentials">The discount credentials to save</param>
		/// <returns>Returns a task that will finish once the save is complete</returns>
		Task<bool> SaveDiscountCredentialsAsync(Discount discountCredentials);

		/// <summary>
		/// Stores the given flight credentials to the backing data store
		/// </summary>
		/// <param name="flightCredentials">The flight credentials to save</param>
		/// <returns>Returns a task that will finish once the save is complete</returns>
		Task<bool> SaveFlightCredentialsAsync(Flight flightCredentials);

		/// <summary>
		/// Stores the given passenger credentials to the backing data store
		/// </summary>
		/// <param name="passengerCredentials">The passenger credentials to save</param>
		/// <returns>Returns a task that will finish once the save is complete</returns>
		Task<bool> SavePassengerCredentialsAsync(Passenger passengerCredentials);

		/// <summary>
		/// Stores the given position credentials to the backing data store
		/// </summary>
		/// <param name="positionCredentials">The position credentials to save</param>
		/// <returns>Returns a task that will finish once the save is complete</returns>
		Task<bool> SavePositionCredentialsAsync(Position positionCredentials);

		/// <summary>
		/// Stores the given ticket credentials to the backing data store
		/// </summary>
		/// <param name="ticketCredentials">The ticket credentials to save</param>
		/// <returns>Returns a task that will finish once the save is complete</returns>
		Task<bool> SaveTicketCredentialsAsync(Ticket ticketCredentials);
	}
}