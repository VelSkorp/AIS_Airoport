using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using AIS_Airoport.Core;

namespace AIS_Airoport.Relational
{
	/// <summary>
	/// Stores and retrieves information about the client application 
	/// such as login credentials and so on
	/// in an SQLite database
	/// </summary>
	public class DataStore : IDataStore
	{
		#region Private Members

		/// <summary>
		/// The name of the employee who logged in
		/// </summary>
		private string mEmployeeSurname;

		#endregion

		#region Protected Members

		/// <summary>
		/// The database context for the client data store
		/// </summary>
		protected DataStoreDbContext mDbContext;

		#endregion

		#region Constructor

		/// <summary>
		/// Default constructor
		/// </summary>
		/// <param name="dbContext">The database to use</param>
		public DataStore(DataStoreDbContext dbContext)
		{
			// Set local member
			mDbContext = dbContext;
		}

		#endregion

		#region Interface Implementation

		/// <summary>
		/// Logs into the application
		/// </summary>
		/// <param name="loginCredentialsApiModel">The credentials for an client to log into the application</param>
		/// <returns>Returns application login was successful or not</returns>
		public async Task<bool> LoginAsync(LoginCredentialsApiModel loginCredentialsApiModel)
		{
			mEmployeeSurname = loginCredentialsApiModel.Surname;

			return await Task.FromResult(mDbContext.Staff.FirstOrDefault((item) => item.Surname == loginCredentialsApiModel.Surname
			&& item.Password == loginCredentialsApiModel.Password) != null);
		}

		/// <summary>
		/// Makes sure the data store is correctly set up
		/// </summary>
		/// <returns>Returns a task that will finish once setup is complete</returns>
		public async Task EnsureDataStoreAsync()
		{
			// Make sure the database exists and is created
			await mDbContext.Database.EnsureCreatedAsync();
		}

		/// <summary>
		/// Gets the stored login credentials for this client
		/// </summary>
		/// <returns>Returns the login credentials if they exist, or null if none exist</returns>
		public Task<EmployeeCredentials> GetEmployeeCredentialsAsync()
		{
			// Get the first column in the login credentials table, or null if none exist
			return Task.FromResult(mDbContext.Staff.FirstOrDefault((item) => item.Surname == mEmployeeSurname));
		}

		/// <summary>
		/// Gets the stored ticket information
		/// </summary>
		public Task<ObservableCollection<Ticket>> GetCollectionOfTicketsAsync()
		{
			var tickets = new ObservableCollection<Ticket>(mDbContext.Tickets);

			if (tickets.First().FlightNumber.IsInt())
			{
				foreach (Ticket ticket in tickets)
				{
					ticket.FlightNumber = mDbContext.Flights.First((item) => item.Code == ticket.FlightNumber).FlightNumber;
					ticket.Passenger = mDbContext.Passengers.First((item) => item.ID == ticket.Passenger).Surname;
					ticket.Employee = mDbContext.Staff.First((item) => item.ID == ticket.Employee).Surname;
				}
			}

			return Task.FromResult(tickets);
		}

		/// <summary>
		/// Stores the given login credentials to the backing data store
		/// </summary>
		/// <param name="loginCredentials">The login credentials to save</param>
		/// <returns>Returns a task that will finish once the save is complete</returns>
		public async Task SaveLoginCredentialsAsync(EmployeeCredentials loginCredentials)
		{
			// Clear all entries
			mDbContext.Staff.RemoveRange(mDbContext.Staff);

			// Add new one
			mDbContext.Staff.Add(loginCredentials);

			// Save changes
			await mDbContext.SaveChangesAsync();
		}

		#endregion
	}
}