using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AIS_Airport.Core
{
	/// <summary>
	/// The View Model for a ticket selling screen
	/// </summary>
	public class TicketSellingViewModel : BaseViewModel
	{
		#region Protected Members

		/// <summary>
		/// The flight list items for the list
		/// </summary>
		protected ObservableCollection<Ticket> mItems;

		#endregion

		#region Public Properties

		/// <summary>
		/// The flight list items for the list
		/// NOTE: Do not call Items.Add to add messages to this list
		///		  as it will make the FilteredIAndSortedtems out of sync
		/// </summary>
		public ObservableCollection<Ticket> Items
		{
			get => mItems;
			set
			{
				// Make sure list has changed
				if (mItems == value)
				{
					return; 
				}

				// Update value
				mItems = value;

				// Update filtered list to match
				FilteredIAndSortedtems = new ObservableCollection<Ticket>(mItems);
			}
		}

		/// <summary>
		/// The flight list items for the list that include search filtering
		/// </summary>
		public ObservableCollection<Ticket> FilteredIAndSortedtems { get; set; }

		/// <summary>
		/// The date to filter from
		/// </summary>
		public DateTime? FilterFrom { get; set; } = null;

		/// <summary>
		/// The date to filter by
		/// </summary>
		public DateTime? FilterBy { get; set; } = null;

		/// <summary>
		/// The right to sell tickets
		/// </summary>
		public bool HasRightToSellTickets { get; set; } = IoC.DataStore.GetEmployeeRightToSellTicketsAsync().Result;

		/// <summary>
		/// A flag indicating if the refresh command is running
		/// </summary>
		public bool RefreshIsRunning { get; set; }

		/// <summary>
		/// A flag indicating if the generate ticket command is running
		/// </summary>
		public bool GenerateIsRunning { get; set; }

		/// <summary>
		/// Selected ticket from the list
		/// </summary>
		public Ticket SelectedTicket { get; set; }


		#endregion

		#region Commands

		/// <summary>
		/// The command to sort <see cref="FlightListItems"/> by number
		/// </summary>
		public ICommand SortByTicketNumberCommand { get; set; }

		/// <summary>
		/// The command to sort <see cref="FlightListItems"/> by start date
		/// </summary>
		public ICommand SortByStartDateCommand { get; set; }

		/// <summary>
		/// The command to disable <see cref="FlightListItems"/> sorting
		/// </summary>
		public ICommand DoNotSortCommand { get; set; }

		/// <summary>
		/// The command to filter <see cref="FlightListItems"/>
		/// </summary>
		public ICommand FilterCommand { get; set; }

		/// <summary>
		/// The command to go back to the main menu
		/// </summary>
		public ICommand BackCommand { get; set; }


		/// <summary>
		/// The command to create a new ticket
		/// </summary>
		public ICommand CreateCommand { get; set; }

		/// <summary>
		/// The command to change this ticket
		/// </summary>
		public ICommand ChangeCommand { get; set; }

		/// <summary>
		/// The command to generate a ticket for print
		/// </summary>
		public ICommand GenerateCommand { get; set; }

		/// <summary>
		/// The command to refresh a list of tickets
		/// </summary>
		public ICommand RefreshCommand { get; set; }

		#endregion

		#region Constructor

		/// <summary>
		/// Default constructor
		/// </summary>
		public TicketSellingViewModel()
		{
			// Create commands
			FilterCommand = new RelayCommand(Filter);
			BackCommand = new RelayCommand(Back);

			SortByTicketNumberCommand = new RelayCommand(SortByTicketNumber);
			SortByStartDateCommand = new RelayCommand(SortByStartDate);
			DoNotSortCommand = new RelayCommand(DisableSorting);

			CreateCommand = new RelayCommand(Create);
			ChangeCommand = new RelayCommand(Change);
			GenerateCommand = new RelayAsyncCommand(GenerateAsync);
			RefreshCommand = new RelayAsyncCommand(RefreshAsync);

			// Update info
			RefreshAsync();
		}

		#endregion

		#region Command Methods

		/// <summary>
		/// Filter <see cref="FlightListItems"/>
		/// </summary>
		public void Filter()
		{
			// Make sure we don't search a FilterFrom date smaller than FilterBy
			if (FilterFrom > FilterBy)
			{
				return;
			}

			// If we have no search text, or no items
			if (Items is null || Items.Count <= 0)
			{
				// Make filtered list the same
				FilteredIAndSortedtems = new ObservableCollection<Ticket>(Items ?? Enumerable.Empty<Ticket>());
				return;
			}

			// Find all items that contain the given text 
			FilteredIAndSortedtems = new ObservableCollection<Ticket>(Items.Where(item => item.DepartureDate > FilterFrom && item.DepartureDate < FilterBy));
		}

		/// <summary>
		/// Go back to main menu page
		/// </summary>
		public void Back()
		{
			IoC.Application.GoToPage(ApplicationPage.MainMenu);
		}

		/// <summary>
		/// Sorting <see cref="FlightListItems"/> by number
		/// </summary>
		public void SortByTicketNumber()
		{
			FilteredIAndSortedtems = new ObservableCollection<Ticket>(Items.OrderBy(item => item.FlightNumber));
		}

		/// <summary>
		/// Sorting <see cref="FlightListItems"/> by start date
		/// </summary>
		public void SortByStartDate()
		{
			FilteredIAndSortedtems = new ObservableCollection<Ticket>(Items.OrderBy(item => item.DepartureDate));
		}

		/// <summary>
		/// Disable <see cref="FlightListItems"/> sorting
		/// </summary>
		public void DisableSorting()
		{
			FilteredIAndSortedtems = new ObservableCollection<Ticket>(Items);
		}

		/// <summary>
		/// Create a new ticket
		/// </summary>
		public void Create()
		{
			IoC.Application.GoToPage(ApplicationPage.AddOrUpdateTicket);
		}

		/// <summary>
		/// Change this ticket
		/// </summary>
		public void Change()
		{
			IoC.Application.GoToPage(ApplicationPage.AddOrUpdateTicket, new AddOrUpdateTicketViewModel(SelectedTicket));
		}

		/// <summary>
		/// Generate a ticket for print
		/// </summary>
		public async Task GenerateAsync()
		{
			await RunCommandAsync(() => GenerateIsRunning, async () =>
			{
				await IoC.File.SaveTicketDocumentAsync(SelectedTicket, $"{SelectedTicket.TicketNumber}TicketInformation.docx");
			});

			await IoC.UI.ShowMessage(new MessageBoxDialogViewModel
			{
				Title = "Successful",
				Message = $"Ticket successful generated by name '{SelectedTicket.TicketNumber}TicketInformation.docx'"
			});
		}

		/// <summary>
		/// Refresh a list of tickets
		/// </summary>
		public async Task RefreshAsync()
		{
			await RunCommandAsync(() => RefreshIsRunning, async () =>
			{
				await Task.Delay(1000);

				Items = await IoC.DataStore.GetCollectionOfTicketsAsync();
			});
		}

		#endregion
	}
}