using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace AIS_Airoport.Core
{
    /// <summary>
    /// The View Model for a flight list screen
    /// </summary>
    public class FlightListViewModel : BaseViewModel
    {
        #region Protected Members

        /// <summary>
        /// The flight list items for the list
        /// </summary>
        protected ObservableCollection<Flight> mItems;

        #endregion

        #region Public Properties

        /// <summary>
        /// The flight list items for the list
        /// NOTE: Do not call Items.Add to add messages to this list
        ///		  as it will make the FilteredIAndSortedtems out of sync
        /// </summary>
        public ObservableCollection<Flight> Items
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
                FilteredIAndSortedtems = new ObservableCollection<Flight>(mItems);
            }
        }

        /// <summary>
        /// The flight list items for the list that include search filtering
        /// </summary>
        public ObservableCollection<Flight> FilteredIAndSortedtems { get; set; }

        /// <summary>
        /// The date to filter from
        /// </summary>
        public DateTime? FilterFrom { get; set; } = null;

        /// <summary>
        /// The date to filter by
        /// </summary>
        public DateTime? FilterBy { get; set; } = null;

        #endregion

        #region Commands

        /// <summary>
        /// The command to sort <see cref="FlightListItems"/> by number
        /// </summary>
        public ICommand SortByNumberCommand { get; set; }

        /// <summary>
        /// The command to sort <see cref="FlightListItems"/> by ticket price
        /// </summary>
        public ICommand SortByTicketPriceCommand { get; set; }

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
        /// The command to refresh a list of flights
        /// </summary>
        public ICommand RefreshCommand { get; set; }

        /// <summary>
        /// The command to go back to the main menu
        /// </summary>
        public ICommand BackCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public FlightListViewModel()
        {
            // Create commands
            FilterCommand = new RelayCommand(Filter);
            BackCommand = new RelayCommand(Back);
            SortByNumberCommand = new RelayCommand(SortByNumber);
            SortByTicketPriceCommand = new RelayCommand(SortByTicketPrice);
            SortByStartDateCommand = new RelayCommand(SortByStartDate);
            DoNotSortCommand = new RelayCommand(DisableSorting);
            RefreshCommand = new RelayCommand(RefreshAsync);
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Filter <see cref="FlightListItems"/>
        /// </summary>
        public void Filter()
        {
            // Make sure we don't search empty date
            if ((string.IsNullOrEmpty(FilterFrom.ToString()) && string.IsNullOrEmpty(FilterBy.ToString())) ||
                (FilterFrom > FilterBy))
                return;

            // If we have no search text, or no items
            if (Items == null || Items.Count <= 0)
            {
                // Make filtered list the same
                FilteredIAndSortedtems = new ObservableCollection<Flight>(Items ?? Enumerable.Empty<Flight>());

                return;
            }

            // Find all items that contain the given text 
            // TODO: Make more efficient search
            FilteredIAndSortedtems = new ObservableCollection<Flight>(Items.Where(item => item.StartDate > FilterFrom && item.StartDate < FilterBy));
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
        public void SortByNumber()
        {
            FilteredIAndSortedtems = new ObservableCollection<Flight>(Items.OrderBy(item => item.FlightNumber));
        }

        /// <summary>
        /// Sorting <see cref="FlightListItems"/> by ticket price
        /// </summary>
        public void SortByTicketPrice()
        {
            FilteredIAndSortedtems = new ObservableCollection<Flight>(Items.OrderBy(item => item.TicketPrice));
        }

        /// <summary>
        /// Sorting <see cref="FlightListItems"/> by start date
        /// </summary>
        public void SortByStartDate()
        {
            FilteredIAndSortedtems = new ObservableCollection<Flight>(Items.OrderBy(item => item.StartDate));
        }

        /// <summary>
        /// Disable <see cref="FlightListItems"/> sorting
        /// </summary>
        public void DisableSorting()
        {
            FilteredIAndSortedtems = new ObservableCollection<Flight>(Items);
        }

        /// <summary>
        /// The command to refresh a list of flights
        /// </summary>
        public async void RefreshAsync()
        {
            Items = await IoC.DataStore.GetCollectionOfFlightsAsync();
        }

        #endregion
    }
}