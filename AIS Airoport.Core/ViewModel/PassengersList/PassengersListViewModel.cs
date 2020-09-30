using System.Collections.ObjectModel;

namespace AIS_Airoport.Core
{
    /// <summary>
    /// The View Model for a flight list screen
    /// </summary>
    public class PassengersListViewModel : BaseViewModel
    {
        #region Protected Members

        /// <summary>
        /// The flight list items for the list
        /// </summary>
        protected ObservableCollection<FlightListItemViewModel> mItems;

        #endregion

        #region Public Properties

        /// <summary>
        /// The flight list items for the list
        /// NOTE: Do not call Items.Add to add messages to this list
        ///		  as it will make the FilteredIAndSortedtems out of sync
        /// </summary>
        public ObservableCollection<FlightListItemViewModel> Items
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
                FilteredIAndSortedtems = new ObservableCollection<FlightListItemViewModel>(mItems);
            }
        }

        /// <summary>
        /// The flight list items for the list that include search filtering
        /// </summary>
        public ObservableCollection<FlightListItemViewModel> FilteredIAndSortedtems { get; set; }

        #endregion

        #region Commands
        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public PassengersListViewModel()
        {
            // Create commands
        }

        #endregion

        #region Command Methods
        #endregion
    }
}