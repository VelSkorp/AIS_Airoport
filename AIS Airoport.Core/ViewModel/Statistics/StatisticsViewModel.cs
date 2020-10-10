using System.Collections.ObjectModel;

namespace AIS_Airoport.Core
{
	/// <summary>
	/// The View Model for a statistics screen
	/// </summary>
	public class StatisticsViewModel : BaseViewModel
	{
		#region Public Properties

		/// <summary>
		/// Data on profit from transportation by destination
		/// </summary>
		public ObservableCollection<DataItem> DestinationItems { get; set; }

		/// <summary>
		/// Shipping Profit Data
		/// </summary>
		public ObservableCollection<DataItem> TransportationItems { get; set; }

		#endregion

		#region Constructor

		/// <summary>
		/// Default constructor
		/// </summary>
		public StatisticsViewModel()
		{
			// Create commands
			
		}

		#endregion
	}
}