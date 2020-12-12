using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Threading.Tasks;

namespace AIS_Airoport.Core
{
	/// <summary>
	/// The View Model for a create new ticket screen
	/// </summary>
	public class CreateNewTicketViewModel : BaseViewModel
	{
		#region Public Properties

		/// <summary>
		/// The number of ticket
		/// </summary>
		public string TicketNumber { get; set; }

		/// <summary>
		/// The number of flight
		/// </summary>
		public string FlightNumber { get; set; }

		/// <summary>
		/// The passenger who bought the ticket
		/// </summary>
		public string Passenger { get; set; }

		/// <summary>
		/// A departure date
		/// </summary>
		public ObservableCollection<string> ListOfFlights { get; set; }

		/// <summary>
		/// A departure date
		/// </summary>
		public ObservableCollection<string> ListOfPassengers { get; set; }

		/// <summary>
		/// A flag indicating if the refresh command is running
		/// </summary>
		public bool RefreshIsRunning { get; set; }

		/// <summary>
		/// A flag indicating if the save ticket command is running
		/// </summary>
		public bool SaveIsRunning { get; set; }

		#endregion

		#region Commands

		/// <summary>
		/// The command save new ticket
		/// </summary>
		public ICommand SaveCommand { get; set; }

		/// <summary>
		/// The command go back to TicketSellingPage
		/// </summary>
		public ICommand BackCommand { get; set; }

		/// <summary>
		/// The command to refresh lists of Flights and Passengers
		/// </summary>
		public ICommand RefreshCommand { get; set; }

		#endregion

		#region Constructor

		/// <summary>
		/// Default constructor
		/// </summary>
		public CreateNewTicketViewModel()
		{
			// Create commands
			SaveCommand = new RelayCommand(async () => await SaveAsync());
			BackCommand = new RelayCommand(Back);
			RefreshCommand = new RelayCommand(async () => await RefreshAsync());
		}

		#endregion

		#region Command Methods

		/// <summary>
		/// Save new ticket
		/// </summary>
		public async Task SaveAsync()
		{
			await RunCommandAsync(() => SaveIsRunning, async () =>
			{
				if (TicketNumber == null || FlightNumber == null || Passenger == null)
				{
					await IoC.UI.ShowMessage(new MessageBoxDialogViewModel
					{
						Title = "Empty ticket form",
						Message = "Fill out the ticket form"
					});

					return;
				}

				EmployeeCredentials employee = await IoC.DataStore.GetEmployeeCredentialsAsync();

				bool isSaved = await IoC.DataStore.SaveTicketCredentialsAsync(new Ticket
				{
					TicketNumber = TicketNumber,
					FlightNumber = FlightNumber,
					Passenger = Passenger,
					Employee = employee.Surname,
				});

				if (isSaved)
				{
					IoC.Application.GoToPage(ApplicationPage.TicketSelling);
					return;
				}

				await IoC.UI.ShowMessage(new MessageBoxDialogViewModel
				{
					Title = "Ticket exist",
					Message = "Ticket already exist"
				});
			});
		}

		/// <summary>
		/// Go back to TicketSellingPage
		/// </summary>
		public void Back()
		{
			IoC.Application.GoToPage(ApplicationPage.TicketSelling);
		}

		/// <summary>
		/// Save new ticket
		/// </summary>
		public async Task RefreshAsync()
		{
			await RunCommandAsync(() => RefreshIsRunning, async () =>
			{
				ObservableCollection<Flight> flights = await IoC.DataStore.GetCollectionOfFlightsAsync();
				ListOfFlights = new ObservableCollection<string>(flights.Select((item) => item.FlightNumber));

				ObservableCollection<Passenger> passenger = await IoC.DataStore.GetCollectionOfPassengersAsync();
				ListOfPassengers = new ObservableCollection<string>(passenger.Select((item) => item.Surname));
			});
		}

		#endregion
	}
}