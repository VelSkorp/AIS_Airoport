using System.Collections.ObjectModel;
using System.Threading.Tasks;
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

		/// <summary>
		/// A flag indicating if the refresh command is running
		/// </summary>
		public bool RefreshIsRunning { get; set; }

		#endregion

		#region Commands

		/// <summary>
		/// The сommand to update data in the table and on the graph in the airline tab
		/// </summary>
		public ICommand AirlinesRefreshCommand { get; set; }

		/// <summary>
		/// The command to update the data in the table and on the graph
		/// in the tab of ticket sales by passengers
		/// </summary>
		public ICommand ProfitFromTicketSalesByPassengerRefreshCommand { get; set; }

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
			ProfitByDestinationRefreshCommand = new RelayCommand(async () => await RefreshProfitByDestinationAsync());
			ProfitOnTransportationRefreshCommand = new RelayCommand(async () => await RefreshProfitOnTransportationAsync());
			TicketDiscountsRefreshCommand = new RelayCommand(async () => await RefreshTicketDiscountsAsync());
			AverageTicketPricesRefreshCommand = new RelayCommand(async () => await RefreshAverageTicketPricesAsync());
			DestinationsRefreshCommand = new RelayCommand(async () => await RefreshDestinationsAsync());
			AirlinesRefreshCommand = new RelayCommand(async () => await RefreshAirlinesAsync());
			ProfitFromTicketSalesByPassengerRefreshCommand = new RelayCommand(async () => await RefreshProfitFromTicketSalesByPassengerAsync());
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
		public virtual async Task RefreshProfitByDestinationAsync()
		{
			// TODO: Implement method to refresh data in table and chart in the profit tab by directions
			
			await RunCommandAsync(() => RefreshIsRunning, async () =>
			{
			});
		}

		/// <summary>
		/// Updating data in the table 
		/// and on the diagram in the profit by transportation tab
		/// </summary>
		public virtual async Task RefreshProfitOnTransportationAsync()
		{
			// TODO: Implement method to refresh data in table and chart in the profit by transportation tab

			await RunCommandAsync(() => RefreshIsRunning, async () =>
			{
			});
		}

		/// <summary>
		/// Updating data in the table and on the graph 
		/// in the tab for the number of used ticket discounts by type
		/// </summary>
		public virtual async Task RefreshTicketDiscountsAsync()
		{
			// TODO: Implement method to refresh data in the tab for the number of used ticket discounts by type

			await RunCommandAsync(() => RefreshIsRunning, async () =>
			{
			});
		}

		/// <summary>
		/// Updating data in the table and on the graph 
		/// in the tab for finding the average cost of tickets
		/// </summary>
		public virtual async Task RefreshAverageTicketPricesAsync()
		{
			// TODO: Implement method to refresh data in the tab for finding the average cost of tickets

			await RunCommandAsync(() => RefreshIsRunning, async () =>
			{
			});
		}

		/// <summary>
		/// Updating data in the table and on the graph in the destinations tab
		/// </summary>
		public virtual async Task RefreshDestinationsAsync()
		{
			// TODO: Implement method to refresh data in the destinations tab

			await RunCommandAsync(() => RefreshIsRunning, async () =>
			{
			});
		}

		/// <summary>
		/// Updating data in the airline tab
		/// </summary>
		public virtual async Task RefreshAirlinesAsync()
		{
			// TODO: Implement method to refresh data in the airline tab

			await RunCommandAsync(() => RefreshIsRunning, async () =>
			{
			});
		}

		/// <summary>
		/// Updating data in the table and on the graph 
		/// in the tab of ticket sales by passengers
		/// </summary>
		public virtual async Task RefreshProfitFromTicketSalesByPassengerAsync()
		{
			// TODO: Implement method to refresh data in the tab of ticket sales by passengers

			await RunCommandAsync(() => RefreshIsRunning, async () =>
			{
			});
		}

		#endregion
	}
}