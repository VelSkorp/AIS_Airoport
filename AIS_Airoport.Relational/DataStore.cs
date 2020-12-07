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
		/// Gets the stored airlines information
		/// </summary>
		public Task<ObservableCollection<Airline>> GetCollectionOfAirlinesAsync()
		{
			return Task.FromResult(new ObservableCollection<Airline>(mDbContext.Airlines));
		}

		/// <summary>
		/// Gets the stored destinations information
		/// </summary>
		public Task<ObservableCollection<Destination>> GetCollectionOfDestinationsAsync()
		{
			return Task.FromResult(new ObservableCollection<Destination>(mDbContext.Destinations));
		}

		/// <summary>
		/// Gets the stored airplanes information
		/// </summary>
		public Task<ObservableCollection<Airplane>> GetCollectionOfAirplanesAsync()
		{
			return Task.FromResult(new ObservableCollection<Airplane>(mDbContext.Airplanes));
		}

		/// <summary>
		/// Gets the stored discounts information
		/// </summary>
		public Task<ObservableCollection<Discount>> GetCollectionOfDiscountsAsync()
		{
			return Task.FromResult(new ObservableCollection<Discount>(mDbContext.Discounts));
		}

		/// <summary>
		/// Gets the stored flights information
		/// </summary>
		public Task<ObservableCollection<Flight>> GetCollectionOfFlightsAsync()
		{
			var flights = new ObservableCollection<Flight>(mDbContext.Flights);

			if (flights.First().Airline.IsInt())
			{
				foreach (Flight flight in flights)
				{
					flight.Airline = mDbContext.Airlines.First((item) => item.Code == flight.Airline).Nomination;
				}
			}

			if (flights.First().Destination.IsInt())
			{
				foreach (Flight flight in flights)
				{
					flight.Destination = mDbContext.Destinations.First((item) => item.Code == flight.Destination).Nomination;
				}
			}

			if (flights.First().Airplane.IsInt())
			{
				foreach (Flight flight in flights)
				{
					flight.Airplane = mDbContext.Airplanes.First((item) => item.Code == flight.Airplane).Model;
				}
			}

			return Task.FromResult(flights);
		}

		/// <summary>
		/// Gets the stored passengers information
		/// </summary>
		public Task<ObservableCollection<Passenger>> GetCollectionOfPassengersAsync()
		{
			return Task.FromResult(new ObservableCollection<Passenger>(mDbContext.Passengers));
		}

		/// <summary>
		/// Gets the stored positions information
		/// </summary>
		public Task<ObservableCollection<Position>> GetCollectionOfPositionsAsync()
		{
			return Task.FromResult(new ObservableCollection<Position>(mDbContext.Positions));
		}

		/// <summary>
		/// Gets the stored tickets information
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