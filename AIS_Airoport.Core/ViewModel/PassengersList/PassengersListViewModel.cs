using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AIS_Airoport.Core
{
	/// <summary>
	/// The View Model for a passengers list screen
	/// </summary>
	public class PassengersListViewModel : BaseViewModel
	{
		#region Protected Members

		/// <summary>
		/// The flight list items for the list
		/// </summary>
		protected ObservableCollection<Passenger> mItems;

		#endregion

		#region Public Properties

		/// <summary>
		/// The flight list items for the list
		/// NOTE: Do not call Items.Add to add messages to this list
		///		  as it will make the FilteredIAndSortedtems out of sync
		/// </summary>
		public ObservableCollection<Passenger> Items
		{
			get => mItems;
			set
			{
				// Make sure list has changed
				if (mItems == value)
					return;

				// Update value
				mItems = value;

				// Update filtered list to match
				FilteredIAndSortedtems = new ObservableCollection<Passenger>(mItems);
			}
		}

		/// <summary>
		/// The flight list items for the list that include search filtering
		/// </summary>
		public ObservableCollection<Passenger> FilteredIAndSortedtems { get; set; }

		#endregion

		#region Commands

		/// <summary>
		/// The command to add a new passenger
		/// </summary>
		public ICommand AddCommand { get; set; }

		/// <summary>
		/// The command to change data about the current passenger
		/// </summary>
		public ICommand ChangeCommand { get; set; }

		/// <summary>
		/// The command to go back to the main menu
		/// </summary>
		public ICommand BackCommand { get; set; }

		/// <summary>
		/// The command to refresh a list of passengers
		/// </summary>
		public ICommand RefreshCommand { get; set; }

		#endregion

		#region Constructor

		/// <summary>
		/// Default constructor
		/// </summary>
		public PassengersListViewModel()
		{
			// Create commands
			AddCommand = new RelayCommand(AddNewPassenger);
			ChangeCommand = new RelayCommand(ChangeCurrentPassenger);
			BackCommand = new RelayCommand(Back);
			RefreshCommand = new RelayCommand(RefreshAsync);
		}

		#endregion

		#region Command Methods

		/// <summary>
		/// Go back to main menu page
		/// </summary>
		public void Back()
		{
			IoC.Application.GoToPage(ApplicationPage.MainMenu);
		}

		/// <summary>
		/// Adds information about the new passenger
		/// </summary>
		public void AddNewPassenger()
		{
			// TODO: Implement method to add information about the new passenger
		}

		/// <summary>
		/// Changes data about the current passenger
		/// </summary>
		public void ChangeCurrentPassenger()
		{
			// TODO: Implement method to change data about the current passenger
		}

		/// <summary>
		/// The command to refresh a list of passengers
		/// </summary>
		public async void RefreshAsync()
		{
			Items = await IoC.DataStore.GetCollectionOfPassengersAsync();
		}

		#endregion
	}
}