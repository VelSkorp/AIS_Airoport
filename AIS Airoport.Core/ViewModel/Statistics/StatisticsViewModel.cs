using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AIS_Airoport.Core
{
	/// <summary>
	/// The View Model for a statistics screen
	/// </summary>
	public class StatisticsViewModel : BaseViewModel
	{
		#region Public Properties

		/// <summary>
		/// Data in tables and in charts
		/// </summary>
		public ObservableCollection<DataItem> Data { get; set; }

		#endregion

		#region Commands

		/// <summary>
		/// The сommand for updating data in the table
		/// and on the chart in the profit tab by directions
		/// </summary>
		public ICommand DestinationRefreshCommand { get; set; }

		/// <summary>
		/// The command for updating data in the table 
		/// and on the diagram in the profit by transportation tab
		/// </summary>
		public ICommand TransportationRefreshCommand { get; set; }

		/// <summary>
		/// The command to go back to the main menu
		/// </summary>
		public ICommand BackCommand { get; set; }

		#endregion

		#region Constructor

		/// <summary>
		/// Default constructor
		/// </summary>
		public StatisticsViewModel()
		{
			// Create commands
			DestinationRefreshCommand = new RelayCommand(RefreshDestination);
			TransportationRefreshCommand = new RelayCommand(RefreshTransportation);
			BackCommand = new RelayCommand(Back);
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
		/// Refresh data in table and chart
		/// in the profit tab by directions
		/// </summary>
		public virtual void RefreshDestination()
		{
			// TODO: Implement method to refresh data in table and chart in the profit tab by directions
		}

		/// <summary>
		/// Updating data in the table 
		/// and on the diagram in the profit by transportation tab
		/// </summary>
		public virtual void RefreshTransportation()
		{
			// TODO: Implement method to refresh data in table and chart in the profit by transportation tab
		}

		#endregion
	}
}