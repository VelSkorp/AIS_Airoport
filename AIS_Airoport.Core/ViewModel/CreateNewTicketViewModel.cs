using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

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
		public DateTime? DepartureDate { get; set; }

		/// <summary>
		/// A departure date
		/// </summary>
		public ObservableCollection<string> ListOfFlights { get; set; }

		/// <summary>
		/// A departure date
		/// </summary>
		public ObservableCollection<string> ListOfPassengers { get; set; }

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
			SaveCommand = new RelayCommand(Save);
			BackCommand = new RelayCommand(Back);
			RefreshCommand = new RelayCommand(RefreshAsync);
		}

		#endregion

		#region Command Methods

		/// <summary>
		/// Save new ticket
		/// </summary>
		public void Save()
		{
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
		public async void RefreshAsync()
		{
			ObservableCollection<Flight> flights = await IoC.DataStore.GetCollectionOfFlightsAsync();
			ListOfFlights = new ObservableCollection<string>(flights.Select((item) => item.FlightNumber));

			ObservableCollection<Passenger> passenger = await IoC.DataStore.GetCollectionOfPassengersAsync();
			ListOfPassengers = new ObservableCollection<string>(passenger.Select((item) => item.Surname));
		}

		#endregion
	}
}