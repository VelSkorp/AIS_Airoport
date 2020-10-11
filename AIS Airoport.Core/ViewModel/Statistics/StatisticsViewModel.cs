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
		/// The сommand for updating data in the table and on the graph 
		/// in the tab for finding the average cost of tickets
		/// </summary>
		public ICommand AverageTicketPricesRefreshCommand { get; set; }

		/// <summary>
		/// The сommand to update data in the table and on the graph in the destinations tab
		/// </summary>
		public ICommand DestinationsRefreshCommand { get; set; }

		/// <summary>
		/// The сommand to update data in the table and on the graph 
		/// in the tab for the number of used ticket discounts by type
		/// </summary>
		public ICommand TicketDiscountsRefreshCommand { get; set; }

		/// <summary>
		/// The сommand for updating data in the table
		/// and on the chart in the profit tab by directions
		/// </summary>
		public ICommand ProfitByDestinationRefreshCommand { get; set; }

		/// <summary>
		/// The command for updating data in the table 
		/// and on the diagram in the profit by transportation tab
		/// </summary>
		public ICommand ProfitOnTransportationRefreshCommand { get; set; }

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
			ProfitByDestinationRefreshCommand = new RelayCommand(RefreshProfitByDestination);
			ProfitOnTransportationRefreshCommand = new RelayCommand(RefreshProfitOnTransportation);
			TicketDiscountsRefreshCommand = new RelayCommand(RefreshTicketDiscounts);
			AverageTicketPricesRefreshCommand = new RelayCommand(RefreshAverageTicketPrices);
			DestinationsRefreshCommand = new RelayCommand(RefreshDestinations);
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
		public virtual void RefreshProfitByDestination()
		{
			// TODO: Implement method to refresh data in table and chart in the profit tab by directions
		}

		/// <summary>
		/// Updating data in the table 
		/// and on the diagram in the profit by transportation tab
		/// </summary>
		public virtual void RefreshProfitOnTransportation()
		{
			// TODO: Implement method to refresh data in table and chart in the profit by transportation tab
		}

		/// <summary>
		/// Updating data in the table and on the graph 
		/// in the tab for the number of used ticket discounts by type
		/// </summary>
		public virtual void RefreshTicketDiscounts()
		{
			// TODO: Implement method to refresh data in the tab for the number of used ticket discounts by type
		}

		/// <summary>
		/// Updating data in the table and on the graph 
		/// in the tab for finding the average cost of tickets
		/// </summary>
		public virtual void RefreshAverageTicketPrices()
		{
			// TODO: Implement method to refresh data in the tab for finding the average cost of tickets
		}

		/// <summary>
		/// Updating data in the table and on the graph in the destinations tab
		/// </summary>
		public virtual void RefreshDestinations()
		{
			// TODO: Implement method to refresh data in the destinations tab
		}

		#endregion
	}
}