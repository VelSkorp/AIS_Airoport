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
		public async Task<EmployeeCredentials> GetEmployeeCredentialsAsync()
		{
			EmployeeCredentialsApiModel employee = mDbContext.Staff.FirstOrDefault((item) => item.Surname == mEmployeeSurname);

			// Get the first column in the login credentials table, or null if none exist
			return await Task.FromResult(new EmployeeCredentials
			{
				ID = employee.ID,
				Surname = employee.Surname,
				FirstName = employee.FirstName,
				Patronymic = employee.Patronymic,
				Phone = employee.Phone,
				Address = employee.Address,
				Password = employee.Password,
				Position = mDbContext.Positions.First((item) => item.Code == employee.Position).Nomination
			});
		}

		/// <summary>
		/// Gets the stored airlines information
		/// </summary>
		public async Task<ObservableCollection<Airline>> GetCollectionOfAirlinesAsync()
		{
			return await Task.FromResult(new ObservableCollection<Airline>(mDbContext.Airlines));
		}

		/// <summary>
		/// Gets the stored airplanes information
		/// </summary>
		public async Task<ObservableCollection<Airplane>> GetCollectionOfAirplanesAsync()
		{
			return await Task.FromResult(new ObservableCollection<Airplane>(mDbContext.Airplanes));
		}

		/// <summary>
		/// Gets the stored destinations information
		/// </summary>
		public async Task<ObservableCollection<Destination>> GetCollectionOfDestinationsAsync()
		{
			return await Task.FromResult(new ObservableCollection<Destination>(mDbContext.Destinations));
		}

		/// <summary>
		/// Gets the stored discounts information
		/// </summary>
		public async Task<ObservableCollection<Discount>> GetCollectionOfDiscountsAsync()
		{
			return await Task.Run(() => new ObservableCollection<Discount>(mDbContext.Discounts));
		}

		/// <summary>
		/// Gets the stored flights information
		/// </summary>
		public async Task<ObservableCollection<Flight>> GetCollectionOfFlightsAsync()
		{
			var flights = new ObservableCollection<Flight>();

			await Task.Run(() =>
			{
				foreach (FlightApiModel flight in mDbContext.Flights)
				{
					flights.Add(new Flight
					{
						Code = flight.Code,
						FlightNumber = flight.FlightNumber,
						StartDate = flight.StartDate,
						StartTime = flight.StartTime,
						Airline = mDbContext.Airlines.First((item) => item.Code == flight.Airline).Nomination,
						TicketPrice = flight.TicketPrice,
						Destination = mDbContext.Destinations.First((item) => item.Code == flight.Destination).Nomination,
						Airplane = mDbContext.Airplanes.First((item) => item.Code == flight.Airplane).BoardNumber,
					});
				}
			});

			return await Task.FromResult(flights);
		}

		/// <summary>
		/// Gets the stored passengers information
		/// </summary>
		public async Task<ObservableCollection<Passenger>> GetCollectionOfPassengersAsync()
		{
			return await Task.Run(() => new ObservableCollection<Passenger>(mDbContext.Passengers));
		}

		/// <summary>
		/// Gets the stored positions information
		/// </summary>
		public async Task<ObservableCollection<Position>> GetCollectionOfPositionsAsync()
		{
			return await Task.Run(() => new ObservableCollection<Position>(mDbContext.Positions));
		}

		/// <summary>
		/// Gets the stored employee information
		/// </summary>
		public async Task<ObservableCollection<EmployeeCredentials>> GetCollectionOfEmployeesAsync()
		{
			var employees = new ObservableCollection<EmployeeCredentials>();

			foreach (EmployeeCredentialsApiModel employee in mDbContext.Staff)
			{
				employees.Add(new EmployeeCredentials
				{
					ID = employee.ID,
					Surname = employee.Surname,
					FirstName = employee.FirstName,
					Patronymic = employee.Patronymic,
					Phone = employee.Phone,
					Address = employee.Address,
					Password = employee.Password,
					Position = mDbContext.Positions.First((item) => item.Code == employee.Position).Nomination,
				});
			}

			return await Task.FromResult(employees);
		}

		/// <summary>
		/// Gets the stored tickets information
		/// </summary>
		public async Task<ObservableCollection<Ticket>> GetCollectionOfTicketsAsync()
		{
			var tickets = new ObservableCollection<Ticket>();

			await Task.Run(() =>
			{
				foreach (TicketApiModel ticket in mDbContext.Tickets)
				{
					tickets.Add(new Ticket
					{
						TicketNumber = ticket.TicketNumber,
						FlightNumber = mDbContext.Flights.First((item) => item.Code == ticket.FlightNumber).FlightNumber,
						Passenger = mDbContext.Passengers.First((item) => item.ID == ticket.Passenger).Surname,
						Employee = mEmployeeSurname,
						DepartureDate = ticket.DepartureDate,
					});
				}
			});

			return await Task.FromResult(tickets);
		}

		/// <summary>
		/// Gets the stored employee right to add new flights 
		/// </summary>
		public async Task<bool> GetEmployeeRightToAddNewFlightsAsync()
		{
			var employee = mDbContext.Staff.First((item) => item.Surname == mEmployeeSurname);

			return await Task.FromResult(mDbContext.Positions.First((item) => item.Code == employee.Position).RightToAddNewFlights) == 1;
		}

		/// <summary>
		/// Gets the stored employee right to sell tickets
		/// </summary>
		public async Task<bool> GetEmployeeRightToSellTicketsAsync()
		{
			var employee = mDbContext.Staff.First((item) => item.Surname == mEmployeeSurname);

			return await Task.FromResult(mDbContext.Positions.First((item) => item.Code == employee.Position).RightToSellTickets) == 1;
		}

		/// <summary>
		/// Gets the stored employee right to add new employees 
		/// </summary>
		public async Task<bool> GetEmployeeRightToAddNewEmployeesAsync()
		{
			var employee = mDbContext.Staff.First((item) => item.Surname == mEmployeeSurname);

			return await Task.FromResult(mDbContext.Positions.First((item) => item.Code == employee.Position).RightToAddNewEmployees) == 1;
		}

		/// <summary>
		/// Stores the given login credentials to the backing data store
		/// </summary>
		/// <param name="employeeCredentials">The login credentials to save</param>
		/// <returns>Returns a task that will finish once the save is complete</returns>
		public async Task<bool> SaveLoginCredentialsAsync(EmployeeCredentials employeeCredentials)
		{
			var employee = new EmployeeCredentialsApiModel
			{
				ID = employeeCredentials.ID,
				Surname = employeeCredentials.Surname,
				FirstName = employeeCredentials.FirstName,
				Patronymic = employeeCredentials.Patronymic,
				Phone = employeeCredentials.Phone,
				Address = employeeCredentials.Address,
				Password = employeeCredentials.Password,
				Position = mDbContext.Positions.First((item) => item.Nomination == employeeCredentials.Position).Code
			};

			if (mDbContext.Staff.Contains(employee))
			{
				return false;
			}

			// Add new one
			mDbContext.Staff.Add(employee);

			// Save changes
			return await mDbContext.SaveChangesAsync() == 1;
		}

		/// <summary>
		/// Stores the given airline credentials to the backing data store
		/// </summary>
		/// <param name="airlineCredentials">The airline credentials to save</param>
		/// <returns>Returns a task that will finish once the save is complete</returns>
		public async Task<bool> SaveAirlineCredentialsAsync(Airline airlineCredentials)
		{
			if (mDbContext.Airlines.Contains(airlineCredentials))
			{
				return false;
			}

			// Add new one
			mDbContext.Airlines.Add(airlineCredentials);

			// Save changes
			return await mDbContext.SaveChangesAsync() == 1;
		}

		/// <summary>
		/// Stores the given airplane credentials to the backing data store
		/// </summary>
		/// <param name="airplaneCredentials">The airplane credentials to save</param>
		/// <returns>Returns a task that will finish once the save is complete</returns>
		public async Task<bool> SaveAirplaneCredentialsAsync(Airplane airplaneCredentials)
		{
			if (mDbContext.Airplanes.Contains(airplaneCredentials))
			{
				return false;
			}

			// Add new one
			mDbContext.Airplanes.Add(airplaneCredentials);

			// Save changes
			return await mDbContext.SaveChangesAsync() == 1;
		}

		/// <summary>
		/// Stores the given destination credentials to the backing data store
		/// </summary>
		/// <param name="destinationCredentials">The destination credentials to save</param>
		/// <returns>Returns a task that will finish once the save is complete</returns>
		public async Task<bool> SaveDestinationCredentialsAsync(Destination destinationCredentials)
		{
			if (mDbContext.Destinations.Contains(destinationCredentials))
			{
				return false;
			}

			// Add new one
			mDbContext.Destinations.Add(destinationCredentials);

			// Save changes
			return await mDbContext.SaveChangesAsync() == 1;
		}

		/// <summary>
		/// Stores the given discount credentials to the backing data store
		/// </summary>
		/// <param name="discountCredentials">The discount credentials to save</param>
		/// <returns>Returns a task that will finish once the save is complete</returns>
		public async Task<bool> SaveDiscountCredentialsAsync(Discount discountCredentials)
		{
			if (mDbContext.Discounts.Contains(discountCredentials))
			{
				return false;
			}

			// Add new one
			mDbContext.Discounts.Add(discountCredentials);

			// Save changes
			return await mDbContext.SaveChangesAsync() == 1;
		}

		/// <summary>
		/// Stores the given flight credentials to the backing data store
		/// </summary>
		/// <param name="flightCredentials">The flight credentials to save</param>
		/// <returns>Returns a task that will finish once the save is complete</returns>
		public async Task<bool> SaveFlightCredentialsAsync(Flight flightCredentials)
		{
			var flight = new FlightApiModel
			{
				Code = flightCredentials.Code,
				FlightNumber = flightCredentials.FlightNumber,
				StartDate = flightCredentials.StartDate,
				StartTime = flightCredentials.StartTime,
				Airline = mDbContext.Airlines.First((item) => item.Nomination == flightCredentials.Airline).Code,
				TicketPrice = flightCredentials.TicketPrice,
				Destination = mDbContext.Destinations.First((item) => item.Nomination == flightCredentials.Destination).Code,
				Airplane = mDbContext.Airplanes.First((item) => item.BoardNumber == flightCredentials.Airplane).Code,
			};

			if (mDbContext.Flights.Contains(flight))
			{
				return false;
			}

			// Add new one
			mDbContext.Flights.Add(flight);

			// Save changes
			return await mDbContext.SaveChangesAsync() == 1;
		}

		/// <summary>
		/// Stores the given passenger credentials to the backing data store
		/// </summary>
		/// <param name="passengerCredentials">The passenger credentials to save</param>
		/// <returns>Returns a task that will finish once the save is complete</returns>
		public async Task<bool> SavePassengerCredentialsAsync(Passenger passengerCredentials)
		{
			if (mDbContext.Passengers.Contains(passengerCredentials))
			{
				return false;
			}

			// Add new one
			mDbContext.Passengers.Add(passengerCredentials);

			// Save changes
			return await mDbContext.SaveChangesAsync() == 1;
		}

		/// <summary>
		/// Stores the given position credentials to the backing data store
		/// </summary>
		/// <param name="positionCredentials">The position credentials to save</param>
		/// <returns>Returns a task that will finish once the save is complete</returns>
		public async Task<bool> SavePositionCredentialsAsync(Position positionCredentials)
		{
			if (mDbContext.Positions.Contains(positionCredentials))
			{
				return false;
			}

			// Add new one
			mDbContext.Positions.Add(positionCredentials);

			// Save changes
			return await mDbContext.SaveChangesAsync() == 1;
		}

		/// <summary>
		/// Stores the given ticket credentials to the backing data store
		/// </summary>
		/// <param name="airlineCredentials">The ticket credentials to save</param>
		/// <returns>Returns a task that will finish once the save is complete</returns>
		public async Task<bool> SaveTicketCredentialsAsync(Ticket ticketCredentials)
		{
			var ticket = new TicketApiModel
			{
				TicketNumber = ticketCredentials.TicketNumber,
			};

			await Task.Run(() =>
			{
				ticket.FlightNumber = mDbContext.Flights.First((item) => item.FlightNumber == ticketCredentials.FlightNumber).Code;
				ticket.Passenger = mDbContext.Passengers.First((item) => item.Surname == ticketCredentials.Passenger).ID;
				ticket.Employee = mDbContext.Staff.First((item) => item.Surname == mEmployeeSurname).ID;
				ticket.DepartureDate = mDbContext.Flights.First((item) => item.FlightNumber == ticketCredentials.FlightNumber).StartDate;
			});

			if (mDbContext.Tickets.Contains(ticket))
			{
				return false;
			}

			// Add new one
			mDbContext.Tickets.Add(ticket);

			// Save changes
			return await mDbContext.SaveChangesAsync() == 1;
		}

		#endregion
	}
}