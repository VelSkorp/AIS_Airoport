using System.Collections.ObjectModel;
using AIS_Airport.Core;
using Microsoft.EntityFrameworkCore;

namespace AIS_Airport.Relational
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

			var password = MD5.Encrypt(loginCredentialsApiModel.Password);
			var user = await mDbContext.Staff.AsNoTracking().Where(employee => employee.Surname.Equals(loginCredentialsApiModel.Surname)
				&& employee.Password.Equals(password)).FirstOrDefaultAsync();

			return user != null;
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
			var employee = await mDbContext.Staff.AsNoTracking().FirstOrDefaultAsync(employee => employee.Surname.Equals(mEmployeeSurname));

			// Get the first column in the login credentials table, or null if none exist
			return new EmployeeCredentials
			{
				ID = employee.ID,
				Surname = employee.Surname,
				FirstName = employee.FirstName,
				MiddleName = employee.MiddleName,
				Phone = employee.Phone,
				Address = employee.Address,
				Password = employee.Password,
				Position = await mDbContext.Positions.AsNoTracking().Where(position => position.Code == employee.Position).Select(position => position.Title).FirstOrDefaultAsync()
			};
		}

		/// <summary>
		/// Gets the stored airlines information
		/// </summary>
		public async Task<ObservableCollection<Airline>> GetCollectionOfAirlinesAsync()
		{
			var airlines = await mDbContext.Airlines.AsNoTracking().ToListAsync();
			return new ObservableCollection<Airline>(airlines);
		}

		/// <summary>
		/// Gets the stored airplanes information
		/// </summary>
		public async Task<ObservableCollection<Airplane>> GetCollectionOfAirplanesAsync()
		{
			var airplanes = await mDbContext.Airplanes.AsNoTracking().ToListAsync();
			return new ObservableCollection<Airplane>(airplanes);
		}

		/// <summary>
		/// Gets the stored destinations information
		/// </summary>
		public async Task<ObservableCollection<Destination>> GetCollectionOfDestinationsAsync()
		{
			var destinations = await mDbContext.Destinations.AsNoTracking().ToListAsync();
			return new ObservableCollection<Destination>(destinations);
		}

		/// <summary>
		/// Gets the stored discounts information
		/// </summary>
		public async Task<ObservableCollection<Discount>> GetCollectionOfDiscountsAsync()
		{
			var discounts = await mDbContext.Discounts.AsNoTracking().ToListAsync();
			return new ObservableCollection<Discount>(discounts);
		}

		/// <summary>
		/// Gets the stored flights information
		/// </summary>
		public async Task<ObservableCollection<Flight>> GetCollectionOfFlightsAsync()
		{
			var flights = new ObservableCollection<Flight>();
			var airlines = await mDbContext.Airlines.AsNoTracking().ToDictionaryAsync(airline => airline.Code, airline => airline.Title);
			var destinations = await mDbContext.Destinations.AsNoTracking().ToDictionaryAsync(destination => destination.Code, destination => destination.Title);
			var airplanes = await mDbContext.Airplanes.AsNoTracking().ToDictionaryAsync(airplane => airplane.Code, airplane => airplane.BoardNumber);
			var flightRecords = await mDbContext.Flights.ToListAsync();

			foreach (var flight in flightRecords)
			{
				flights.Add(new Flight
				{
					Code = flight.Code,
					FlightNumber = flight.FlightNumber,
					StartDate = flight.StartDate,
					StartTime = flight.StartTime,
					Airline = airlines[flight.Airline],
					TicketPrice = flight.TicketPrice,
					Destination = destinations[flight.Destination],
					Airplane = airplanes[flight.Airplane],
				});
			}

			return flights;
		}

		/// <summary>
		/// Gets the stored passengers information
		/// </summary>
		public async Task<ObservableCollection<Passenger>> GetCollectionOfPassengersAsync()
		{
			var passengers = await mDbContext.Passengers.AsNoTracking().ToListAsync();
			return new ObservableCollection<Passenger>(passengers);
		}

		/// <summary>
		/// Gets the stored positions information
		/// </summary>
		public async Task<ObservableCollection<Position>> GetCollectionOfPositionsAsync()
		{
			var positions = await mDbContext.Positions.AsNoTracking().ToListAsync();
			return new ObservableCollection<Position>(positions);
		}

		/// <summary>
		/// Gets the stored employee information
		/// </summary>
		public async Task<ObservableCollection<EmployeeCredentials>> GetCollectionOfEmployeesAsync()
		{
			var employees = new ObservableCollection<EmployeeCredentials>();
			var positions = await mDbContext.Positions.AsNoTracking().ToDictionaryAsync(position => position.Code, position => position.Title);
			var employeesRecords = await mDbContext.Staff.ToListAsync();

			foreach (var employee in employeesRecords)
			{
				employees.Add(new EmployeeCredentials
				{
					ID = employee.ID,
					Surname = employee.Surname,
					FirstName = employee.FirstName,
					MiddleName = employee.MiddleName,
					Phone = employee.Phone,
					Address = employee.Address,
					Password = employee.Password,
					Position = positions[employee.Position],
				});
			};

			return employees;
		}

		/// <summary>
		/// Gets the stored tickets information
		/// </summary>
		public async Task<ObservableCollection<Ticket>> GetCollectionOfTicketsAsync()
		{
			var tickets = new ObservableCollection<Ticket>();
			var flights = await mDbContext.Flights.AsNoTracking().ToDictionaryAsync(flight => flight.Code, flight => flight.FlightNumber);
			var passengers = await mDbContext.Passengers.AsNoTracking().ToDictionaryAsync(passenger => passenger.ID, passenger => passenger.Surname);
			var staff = await mDbContext.Staff.AsNoTracking().ToDictionaryAsync(employee => employee.ID, employee => employee.Surname);
			var ticketsRecords = await mDbContext.Tickets.ToListAsync();

			foreach (var ticket in ticketsRecords)
			{
				tickets.Add(new Ticket
				{
					TicketNumber = ticket.TicketNumber,
					FlightNumber = flights[ticket.FlightNumber],
					Passenger = passengers[ticket.Passenger],
					Employee = staff[ticket.Employee],
					DepartureDate = ticket.DepartureDate,
					Cost = ticket.Cost,
				});
			};

			return tickets;
		}

		/// <summary>
		/// Gets information about profit from flights
		/// </summary>
		public async Task<ObservableCollection<DataItem>> GetProfitOnTransportationAsync()
		{
			var data = new Dictionary<string, DataItem>();
			var flights = await mDbContext.Flights.AsNoTracking().ToDictionaryAsync(flight => flight.Code, flight => flight.FlightNumber);
			var ticketsRecords = await mDbContext.Tickets.ToListAsync();

			foreach (var ticket in ticketsRecords)
			{
				var flightNumber = flights[ticket.FlightNumber];

				if (data.TryGetValue(flightNumber, out var value))
				{
					value.Value += ticket.Cost;
					continue;
				}

				data.Add(flightNumber, new DataItem
				{
					Name = flightNumber,
					Value = ticket.Cost
				});
			}

			var result = new ObservableCollection<DataItem>(data.Values);

			return result;
		}

		/// <summary>
		/// Gets information about profit from destinations
		/// </summary>
		public async Task<ObservableCollection<DataItem>> GetProfitByDestinationAsync()
		{
			var data = new Dictionary<string, DataItem>();
			var destinations = await mDbContext.Destinations.AsNoTracking().ToDictionaryAsync(destination => destination.Code, destination => destination.Title);
			var ticketsRecords = await mDbContext.Tickets.ToListAsync();

			foreach (var ticket in ticketsRecords)
			{
				var destination = destinations[ticket.Destination];

				if (data.TryGetValue(destination, out var value))
				{
					value.Value += ticket.Cost;
					continue;
				}

				data.Add(destination, new DataItem
				{
					Name = destination,
					Value = ticket.Cost
				});
			}

			var result = new ObservableCollection<DataItem>(data.Values);

			return result;
		}

		/// <summary>
		/// Gets information about profit from ticket sales by passengers
		/// </summary>
		public async Task<ObservableCollection<DataItem>> GetProfitFromTicketSalesByPassengerAsync()
		{
			var data = new Dictionary<string, DataItem>();
			var passengers = await mDbContext.Passengers.AsNoTracking().ToDictionaryAsync(flight => flight.ID, flight => flight.Surname);
			var ticketsRecords = await mDbContext.Tickets.ToListAsync();

			foreach (var ticket in ticketsRecords)
			{
				var passengerSurname = passengers[ticket.Passenger];

				if (data.TryGetValue(passengerSurname, out var value))
				{
					value.Value += ticket.Cost;
					continue;
				}

				data.Add(passengerSurname, new DataItem
				{
					Name = passengerSurname,
					Value = ticket.Cost
				});
			}

			var result = new ObservableCollection<DataItem>(data.Values);

			return result;
		}

		/// <summary>
		/// Gets information about number of discounted tickets by discounts
		/// </summary>
		public async Task<ObservableCollection<DataItem>> GetNumberOfDiscountedTicketsByDiscountAsync()
		{
			var data = new Dictionary<string, DataItem>();
			var passengers = await mDbContext.Passengers.AsNoTracking().ToDictionaryAsync(passenger => passenger.ID, passenger => passenger.Discount);
			var ticketsRecords = await mDbContext.Tickets.ToListAsync();

			foreach (var ticket in ticketsRecords)
			{
				var discount = passengers[ticket.Passenger];

				if (data.TryGetValue(discount, out var value))
				{
					value.Value += 1;
					continue;
				}

				data.Add(discount, new DataItem
				{
					Name = discount,
					Value = 1
				});
			}

			var result = new ObservableCollection<DataItem>(data.Values);

			return result;
		}

		/// <summary>
		/// Gets information about number of tickets by destinations
		/// </summary>
		public async Task<ObservableCollection<DataItem>> GetNumberOfticketsByDestinationsAsync()
		{
			var data = new Dictionary<string, DataItem>();
			var destinations = await mDbContext.Destinations.AsNoTracking().ToDictionaryAsync(destination => destination.Code, destination => destination.Title);
			var flightsRecords = await mDbContext.Flights.ToListAsync();

			foreach (var flight in flightsRecords)
			{
				var destination = destinations[flight.Destination];

				if (data.TryGetValue(destination, out var value))
				{
					value.Value += 1;
					continue;
				}

				data.Add(destination, new DataItem
				{
					Name = destination,
					Value = 1
				});
			}

			var result = new ObservableCollection<DataItem>(data.Values);

			return result;
		}

		/// <summary>
		/// Gets information about number of tickets by airlines
		/// </summary>
		public async Task<ObservableCollection<DataItem>> GetNumberOfticketsByAirlinesAsync()
		{
			var data = new Dictionary<string, DataItem>();
			var airlines = await mDbContext.Airlines.AsNoTracking().ToDictionaryAsync(airline => airline.Code, airline => airline.Title);
			var flightsRecords = await mDbContext.Flights.ToListAsync();

			foreach (var flight in flightsRecords)
			{
				var airline = airlines[flight.Airline];

				if (data.TryGetValue(airline, out var value))
				{
					value.Value += 1;
					continue;
				}

				data.Add(airline, new DataItem
				{
					Name = airline,
					Value = 1
				});
			}

			var result = new ObservableCollection<DataItem>(data.Values);

			return result;
		}

		/// <summary>
		/// Gets information about average ticket prices by airlines
		/// </summary>
		public async Task<ObservableCollection<DataItem>> GetAverageTicketPricesByAirlinesAsync()
		{
			var data = new HashSet<DataItem>();
			var airlines = await mDbContext.Airlines.AsNoTracking().ToDictionaryAsync(airline => airline.Code, airline => airline.Title);
			var tickets = await mDbContext.Tickets.AsNoTracking().Select(ticket => new { ticket.Airline, ticket.Cost }).ToListAsync();

			foreach (var airline in airlines)
			{
				if (tickets.Any(ticket => ticket.Airline == airline.Key))
				{
					data.Add(new DataItem
					{
						Name = airline.Value,
						Value = tickets.Where(ticket => ticket.Airline == airline.Key).Average(item => item.Cost)
					});
					continue;
				}

				data.Add(new DataItem
				{
					Name = airline.Value,
					Value = 0
				});
			}

			var result = new ObservableCollection<DataItem>(data);

			return result;
		}

		/// <summary>
		/// Gets the stored employee right to add new flights 
		/// </summary>
		public async Task<bool> GetEmployeeRightToAddNewFlightsAsync()
		{
			var employee = await mDbContext.Staff.AsNoTracking().FirstOrDefaultAsync(employee => employee.Surname.Equals(mEmployeeSurname));
			var position = await mDbContext.Positions.AsNoTracking().FirstOrDefaultAsync(position => position.Code == employee.Position);
			return position.RightToAddNewFlights == 1;
		}

		/// <summary>
		/// Gets the stored employee right to sell tickets
		/// </summary>
		public async Task<bool> GetEmployeeRightToSellTicketsAsync()
		{
			var employee = await mDbContext.Staff.AsNoTracking().FirstOrDefaultAsync(employee => employee.Surname.Equals(mEmployeeSurname));
			var position = await mDbContext.Positions.AsNoTracking().FirstOrDefaultAsync(position => position.Code == employee.Position);
			return position.RightToSellTickets == 1;
		}

		/// <summary>
		/// Gets the stored employee right to add new employees 
		/// </summary>
		public async Task<bool> GetEmployeeRightToAddNewEmployeesAsync()
		{
			var employee = await mDbContext.Staff.AsNoTracking().FirstOrDefaultAsync((employee) => employee.Surname.Equals(mEmployeeSurname));
			var position = await mDbContext.Positions.AsNoTracking().FirstOrDefaultAsync(position => position.Code == employee.Position);
			return position.RightToAddNewEmployees == 1;
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
				MiddleName = employeeCredentials.MiddleName,
				Phone = employeeCredentials.Phone,
				Address = employeeCredentials.Address,
				Password = MD5.Encrypt(employeeCredentials.Password),
				Position = await mDbContext.Positions.AsNoTracking().Where(position => position.Title.Equals(employeeCredentials.Position)).Select(position => position.Code).FirstOrDefaultAsync()
			};

			if (await mDbContext.Staff.ContainsAsync(employee))
			{
				return false;
			}

			// Add new one
			await mDbContext.Staff.AddAsync(employee);

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
			if (await mDbContext.Airlines.ContainsAsync(airlineCredentials))
			{
				return false;
			}

			// Add new one
			await mDbContext.Airlines.AddAsync(airlineCredentials);

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
			if (await mDbContext.Airplanes.ContainsAsync(airplaneCredentials))
			{
				return false;
			}

			// Add new one
			await mDbContext.Airplanes.AddAsync(airplaneCredentials);

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
			if (await mDbContext.Destinations.ContainsAsync(destinationCredentials))
			{
				return false;
			}

			// Add new one
			await mDbContext.Destinations.AddAsync(destinationCredentials);

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
			if (await mDbContext.Discounts.ContainsAsync(discountCredentials))
			{
				return false;
			}

			// Add new one
			await mDbContext.Discounts.AddAsync(discountCredentials);

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
				Airline = await mDbContext.Airlines.AsNoTracking().Where(airline => airline.Title.Equals(flightCredentials.Airline)).Select(airline => airline.Code).FirstOrDefaultAsync(),
				TicketPrice = flightCredentials.TicketPrice,
				Destination = await mDbContext.Destinations.AsNoTracking().Where(destination => destination.Title.Equals(flightCredentials.Destination)).Select(destination => destination.Code).FirstOrDefaultAsync(),
				Airplane = await mDbContext.Airplanes.AsNoTracking().Where(airplane => airplane.BoardNumber.Equals(flightCredentials.Airplane)).Select(airplane => airplane.Code).FirstOrDefaultAsync(),
			};

			if (await mDbContext.Flights.ContainsAsync(flight))
			{
				return false;
			}

			// Add new one
			await mDbContext.Flights.AddAsync(flight);

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
			var existingPassenger = await mDbContext.Passengers.SingleOrDefaultAsync(p => p.ID == passengerCredentials.ID);

			if (existingPassenger is not null)
			{
				// Update existing
				existingPassenger.Surname = passengerCredentials.Surname;
				existingPassenger.FirstName = passengerCredentials.FirstName;
				existingPassenger.MiddleName = passengerCredentials.MiddleName;
				existingPassenger.Phone = passengerCredentials.Phone;
				existingPassenger.Address = passengerCredentials.Address;
				existingPassenger.Passport = passengerCredentials.Passport;
				existingPassenger.Discount = passengerCredentials.Discount;
			}
			else
			{
				// Add new one
				await mDbContext.Passengers.AddAsync(passengerCredentials);
			}

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
			if (await mDbContext.Positions.ContainsAsync(positionCredentials))
			{
				return false;
			}

			// Add new one
			await mDbContext.Positions.AddAsync(positionCredentials);

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
			var existingTicket = await mDbContext.Tickets.SingleOrDefaultAsync(t => t.TicketNumber == ticketCredentials.TicketNumber);

			var flight = await mDbContext.Flights.AsNoTracking()
				.Where(flight => flight.FlightNumber == ticketCredentials.FlightNumber)
				.Select(flight => new { flight.FlightNumber, flight.Code, flight.StartDate, flight.TicketPrice, flight.Airline, flight.Destination })
				.FirstOrDefaultAsync();

			var passenger = await mDbContext.Passengers.AsNoTracking()
				.Where(passenger => passenger.Surname == ticketCredentials.Passenger)
				.Select(passenger => new { passenger.ID, passenger.Discount })
				.FirstOrDefaultAsync();

			var discount = passenger.Discount;
			var discountPercentage = await mDbContext.Discounts.AsNoTracking()
				.Where(item => item.DiscountName == discount)
				.Select(discount => discount.DiscountPercentage)
				.FirstOrDefaultAsync();

			var ticketPrice = flight.TicketPrice;
			var calculatedCost = (ticketPrice / 100) * discountPercentage;

			var employee = await mDbContext.Staff.AsNoTracking()
					.Where(e => e.Surname.Equals(mEmployeeSurname))
					.Select(e => e.ID)
					.FirstOrDefaultAsync();

			if (existingTicket is not null)
			{
				// Update existing
				existingTicket.Employee = employee;
				existingTicket.Airline = flight.Airline;
				existingTicket.Destination = flight.Destination;
				existingTicket.FlightNumber = flight.Code;
				existingTicket.DepartureDate = flight.StartDate;
				existingTicket.Passenger = passenger.ID;
				existingTicket.Cost = calculatedCost;
			}
			else
			{
			    // Add new one
				var ticket = new TicketApiModel
				{
					TicketNumber = ticketCredentials.TicketNumber,
					Employee = employee,
					Airline = flight.Airline,
					Destination = flight.Destination,
					FlightNumber = flight.Code,
					DepartureDate = flight.StartDate,
					Passenger = passenger.ID,
					Cost = calculatedCost
				};

				await mDbContext.Tickets.AddAsync(ticket);
			}

			// Save changes
			return await mDbContext.SaveChangesAsync() == 1;
		}

		#endregion
	}
}