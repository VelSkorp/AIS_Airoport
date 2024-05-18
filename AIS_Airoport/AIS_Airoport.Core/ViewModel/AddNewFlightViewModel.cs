using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AIS_Airport.Core
{
	/// <summary>
	/// The View Model for a add new flight screen
	/// </summary>
	public class AddNewFlightViewModel : BaseViewModel
	{
		#region Public Properties

		/// <summary>
		/// The airline title
		/// </summary>
		public string AirlineTitle { get; set; }

		/// <summary>
		/// The airline contacts
		/// </summary>
		public string AirlineContacts { get; set; }

		/// <summary>
		/// The airline head office address
		/// </summary>
		public string AirlineHeadOfficeAddress { get; set; }

		/// <summary>
		/// The airplane board number
		/// </summary>
		public string AirplaneBoardNumber { get; set; }

		/// <summary>
		/// The airplane model
		/// </summary>
		public string AirplaneModel { get; set; }

		/// <summary>
		/// The airplane capacity
		/// </summary>
		public string AirplaneCapacity { get; set; }

		/// <summary>
		/// The airplane date entered
		/// </summary>
		public DateTime? AirplaneDateEntered { get; set; } = null;

		/// <summary>
		/// The destination title
		/// </summary>
		public string DestinationTitle { get; set; }

		/// <summary>
		/// The destination adress
		/// </summary>
		public string DestinationAdress { get; set; }

		/// <summary>
		/// The destination cordinates
		/// </summary>
		public string DestinationCoordinates { get; set; }

		/// <summary>
		/// The flight number
		/// </summary>
		public string FlightNumber { get; set; }

		/// <summary>
		/// The flight start date
		/// </summary>
		public DateTime? FlightStartDate { get; set; } = null;

		/// <summary>
		/// The flight start time
		/// </summary>
		public string FlightStartTime { get; set; }

		/// <summary>
		/// The flight ticket price
		/// </summary>
		public string FlightTicketPrice { get; set; }

		/// <summary>
		/// The flight select airline
		/// </summary>
		public string FlightSelectAirline { get; set; }

		/// <summary>
		/// The flight select destination
		/// </summary>
		public string FlightSelectDestination { get; set; }

		/// <summary>
		/// The flight select airplane
		/// </summary>
		public string FlightSelectAirplane { get; set; }

		/// <summary>
		/// A list of airlines
		/// </summary>
		public ObservableCollection<string> Airlines { get; set; }

		/// <summary>
		/// A list of destinations
		/// </summary>
		public ObservableCollection<string> Destinations { get; set; }

		/// <summary>
		/// A list of airplanes
		/// </summary>
		public ObservableCollection<string> Airplanes { get; set; }

		/// <summary>
		/// A flag indicating if the refresh command is running
		/// </summary>
		public bool RefreshIsRunning { get; set; }

		/// <summary>
		/// A flag indicating if the save airline command is running
		/// </summary>
		public bool SaveAirlineIsRunning { get; set; }

		/// <summary>
		/// A flag indicating if the save airplane command is running
		/// </summary>
		public bool SaveAirplaneIsRunning { get; set; }

		/// <summary>
		/// A flag indicating if the save destination command is running
		/// </summary>
		public bool SaveDestinationIsRunning { get; set; }

		/// <summary>
		/// A flag indicating if the save flight command is running
		/// </summary>
		public bool SaveFlightIsRunning { get; set; }

		#endregion

		#region Commands

		/// <summary>
		/// The command save new airline
		/// </summary>
		public ICommand SaveAirlineCommand { get; set; }

		/// <summary>
		/// The command save new airplane
		/// </summary>
		public ICommand SaveAirplaneCommand { get; set; }

		/// <summary>
		/// The command save new destination
		/// </summary>
		public ICommand SaveDestinationCommand { get; set; }

		/// <summary>
		/// The command save new flight
		/// </summary>
		public ICommand SaveFlightCommand { get; set; }

		/// <summary>
		/// The command go back to FlightListPage
		/// </summary>
		public ICommand BackCommand { get; set; }

		/// <summary>
		/// The command to refresh lists of Airline, Airplanes and Destination
		/// </summary>
		public ICommand RefreshCommand { get; set; }

		#endregion

		#region Constructor

		/// <summary>
		/// Default constructor
		/// </summary>
		public AddNewFlightViewModel()
		{
			// Create commands
			SaveAirlineCommand = new RelayAsyncCommand(SaveAirlineAsync);
			SaveAirplaneCommand = new RelayAsyncCommand(SaveAirplaneAsync);
			SaveDestinationCommand = new RelayAsyncCommand(SaveDestinationAsync);
			SaveFlightCommand = new RelayAsyncCommand(SaveFlightAsync);
			BackCommand = new RelayCommand(Back);
			RefreshCommand = new RelayAsyncCommand(RefreshAsync);
		}

		#endregion

		#region Command Methods

		/// <summary>
		/// Save new airline
		/// </summary>Airline title
		public async Task SaveAirlineAsync()
		{
			await RunCommandAsync(() => SaveAirlineIsRunning, async () =>
			{
				var airline = await IoC.DataStore.GetCollectionOfAirlinesAsync();

				var isSaved = await IoC.DataStore.SaveAirlineCredentialsAsync(new Airline
				{
					Code = airline.Count + 1,
					Title = AirlineTitle,
					Сontacts = AirlineContacts,
					HeadOfficeAddress = AirlineHeadOfficeAddress,
				});

				if (isSaved)
				{
					AirlineTitle = null;
					AirlineContacts = null;
					AirlineHeadOfficeAddress = null;

					await IoC.UI.ShowMessage(new MessageBoxDialogViewModel
					{
						Title = "Successful",
						Message = "Airline successful saved"
					});
					return;
				}

				await IoC.UI.ShowMessage(new MessageBoxDialogViewModel
				{
					Title = "Airline exist",
					Message = "Airline already exist"
				});
			});
		}

		/// <summary>
		/// Save new airplane
		/// </summary>
		public async Task SaveAirplaneAsync()
		{
			await RunCommandAsync(() => SaveAirplaneIsRunning, async () =>
			{
				var airplane = await IoC.DataStore.GetCollectionOfAirplanesAsync();

				var isSaved = await IoC.DataStore.SaveAirplaneCredentialsAsync(new Airplane
				{
					Code = airplane.Count + 1,
					BoardNumber = AirplaneBoardNumber,
					Model = AirplaneModel,
					Capacity = int.Parse(AirplaneCapacity),
					DateEntered = AirplaneDateEntered.Value,
				});

				if (isSaved)
				{
					AirplaneBoardNumber = null;
					AirplaneModel = null;
					AirplaneCapacity = null;
					AirplaneDateEntered = null;

					await IoC.UI.ShowMessage(new MessageBoxDialogViewModel
					{
						Title = "Successful",
						Message = "Airplane successful saved"
					});
					return;
				}

				await IoC.UI.ShowMessage(new MessageBoxDialogViewModel
				{
					Title = "Airplane exist",
					Message = "Airplane already exist"
				});
			});
		}

		/// <summary>
		/// Save new destination
		/// </summary>
		public async Task SaveDestinationAsync()
		{
			await RunCommandAsync(() => SaveDestinationIsRunning, async () =>
			{
				var destination = await IoC.DataStore.GetCollectionOfDestinationsAsync();

				var isSaved = await IoC.DataStore.SaveDestinationCredentialsAsync(new Destination
				{
					Code = destination.Count + 1,
					Title = DestinationTitle,
					Adress = DestinationAdress,
					Сoordinates = DestinationCoordinates,
				});

				if (isSaved)
				{
					DestinationTitle = null;
					DestinationAdress = null;
					DestinationCoordinates = null;

					await IoC.UI.ShowMessage(new MessageBoxDialogViewModel
					{
						Title = "Successful",
						Message = "Destination successful saved"
					});
					return;
				}

				await IoC.UI.ShowMessage(new MessageBoxDialogViewModel
				{
					Title = "Destination exist",
					Message = "Destination already exist"
				});
			});
		}

		/// <summary>
		/// Save new flight
		/// </summary>
		public async Task SaveFlightAsync()
		{
			await RunCommandAsync(() => SaveFlightIsRunning, async () =>
			{
				var flight = await IoC.DataStore.GetCollectionOfFlightsAsync();

				var isSaved = await IoC.DataStore.SaveFlightCredentialsAsync(new Flight
				{
					Code = flight.Count + 1,
					FlightNumber = FlightNumber,
					StartDate = FlightStartDate.Value,
					StartTime = FlightStartTime,
					TicketPrice = int.Parse(FlightTicketPrice),
					Airline = FlightSelectAirline,
					Destination = FlightSelectDestination,
					Airplane = FlightSelectAirplane,
				});

				if (isSaved)
				{
					FlightNumber = null;
					FlightStartDate = null;
					FlightStartTime = null;
					FlightTicketPrice = null;
					FlightSelectAirline = null;
					FlightSelectDestination = null;
					FlightSelectAirplane = null;

					await IoC.UI.ShowMessage(new MessageBoxDialogViewModel
					{
						Title = "Successful",
						Message = "Flight successful saved"
					});
					return;
				}

				await IoC.UI.ShowMessage(new MessageBoxDialogViewModel
				{
					Title = "Flight exist",
					Message = "Flight already exist"
				});
			});
		}

		/// <summary>
		/// Go back to FlightListPage
		/// </summary>
		public void Back()
		{
			IoC.Application.GoToPage(ApplicationPage.FlightList);
		}

		/// <summary>
		/// Refresh lists of Airline, Airplanes and Destination
		/// </summary>
		public async Task RefreshAsync()
		{
			await RunCommandAsync(() => RefreshIsRunning, async () =>
			{
				var airlines = await IoC.DataStore.GetCollectionOfAirlinesAsync();
				Airlines = new ObservableCollection<string>(airlines.Select((item) => item.Title));

				var destination = await IoC.DataStore.GetCollectionOfDestinationsAsync();
				Destinations = new ObservableCollection<string>(destination.Select((item) => item.Title));

				var airplane = await IoC.DataStore.GetCollectionOfAirplanesAsync();
				Airplanes = new ObservableCollection<string>(airplane.Select((item) => item.BoardNumber));
			});
		}

		#endregion
	}
}