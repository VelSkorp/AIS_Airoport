using System;
using System.Collections.ObjectModel;

namespace AIS_Airoport.Core
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
        protected ObservableCollection<TicketSellingItemViewModel> mItems;

        #endregion

        #region Public Properties

        /// <summary>
        /// The flight list items for the list
        /// NOTE: Do not call Items.Add to add messages to this list
        ///		  as it will make the FilteredIAndSortedtems out of sync
        /// </summary>
        public ObservableCollection<TicketSellingItemViewModel> Items
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
                FilteredIAndSortedtems = new ObservableCollection<TicketSellingItemViewModel>(mItems);
            }
        }

        /// <summary>
        /// The flight list items for the list that include search filtering
        /// </summary>
        public ObservableCollection<TicketSellingItemViewModel> FilteredIAndSortedtems { get; set; }

        /// <summary>
        /// The date to filter from
        /// </summary>
        public DateTime? FilterFrom { get; set; } = null;

        /// <summary>
        /// The date to filter by
        /// </summary>
        public DateTime? FilterBy { get; set; } = null;

        #endregion
    }
}