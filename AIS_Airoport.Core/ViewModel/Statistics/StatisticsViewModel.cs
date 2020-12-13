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
		public ICommand NumberOfticketsByAirlinesRefreshCommand { get; set; }

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
		public ICommand NumberOfticketsByDestinationsRefreshCommand { get; set; }

		/// <summary>
		/// The сommand to update data in the table and on the graph 
		/// in the tab for the number of used ticket discounts by type
		/// </summary>
		public ICommand NumberOfDiscountedTicketsByDiscountRefreshCommand { get; set; }

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
			NumberOfDiscountedTicketsByDiscountRefreshCommand = new RelayCommand(async () => await RefreshNumberOfDiscountedTicketsByDiscountAsync());
			AverageTicketPricesRefreshCommand = new RelayCommand(async () => await RefreshAverageTicketPricesAsync());
			NumberOfticketsByDestinationsRefreshCommand = new RelayCommand(async () => await RefreshNumberOfticketsByDestinationsAsync());
			NumberOfticketsByAirlinesRefreshCommand = new RelayCommand(async () => await RefreshNumberOfticketsByAirlinesAsync());
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
			await RunCommandAsync(() => RefreshIsRunning, async () =>
			{
				Data = await IoC.DataStore.GetProfitByDestinationAsync();
			});
		}

		/// <summary>
		/// Updating data in the table 
		/// and on the diagram in the profit by transportation tab
		/// </summary>
		public virtual async Task RefreshProfitOnTransportationAsync()
		{
			await RunCommandAsync(() => RefreshIsRunning, async () =>
			{
				Data = await IoC.DataStore.GetProfitOnTransportationAsync();
			});
		}

		/// <summary>
		/// Updating data in the table and on the graph 
		/// in the tab for the number of used ticket discounts by type
		/// </summary>
		public virtual async Task RefreshNumberOfDiscountedTicketsByDiscountAsync()
		{
			await RunCommandAsync(() => RefreshIsRunning, async () =>
			{
				Data = await IoC.DataStore.GetNumberOfDiscountedTicketsByDiscountAsync();
			});
		}

		/// <summary>
		/// Updating data in the table and on the graph 
		/// in the tab for finding the average cost of tickets
		/// </summary>
		public virtual async Task RefreshAverageTicketPricesAsync()
		{
			await RunCommandAsync(() => RefreshIsRunning, async () =>
			{
				Data = await IoC.DataStore.GetAverageTicketPricesByAirlinesAsync();
			});
		}

		/// <summary>
		/// Updating data in the table and on the graph in the destinations tab
		/// </summary>
		public virtual async Task RefreshNumberOfticketsByDestinationsAsync()
		{
			await RunCommandAsync(() => RefreshIsRunning, async () =>
			{
				Data = await IoC.DataStore.GetNumberOfticketsByDestinationsAsync();
			});
		}

		/// <summary>
		/// Updating data in the airline tab
		/// </summary>
		public virtual async Task RefreshNumberOfticketsByAirlinesAsync()
		{
			await RunCommandAsync(() => RefreshIsRunning, async () =>
			{
				Data = await IoC.DataStore.GetNumberOfticketsByAirlinesAsync();
			});
		}

		/// <summary>
		/// Updating data in the table and on the graph 
		/// in the tab of ticket sales by passengers
		/// </summary>
		public virtual async Task RefreshProfitFromTicketSalesByPassengerAsync()
		{
			await RunCommandAsync(() => RefreshIsRunning, async () =>
			{
				Data = await IoC.DataStore.GetProfitFromTicketSalesByPassengerAsync();
			});
		}

		#endregion
	}
}