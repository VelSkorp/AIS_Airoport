using AIS_Airport.Core;
using System.Diagnostics;

namespace AIS_Airport
{
	/// <summary>
	/// Converts the <see cref="ApplicationPage"/> to an actual view/page
	/// </summary>
	public static class ApplicationPageHelpers
	{
		/// <summary>
		/// Takes a <see cref="ApplicationPage"/> and a view model, if any, and creates the dessired page
		/// </summary>
		/// <param name="page"></param>
		/// <param name="viewModel"></param>
		/// <returns></returns>
		public static BasePage ToBasePage(this ApplicationPage page, object viewModel = null)
		{
			// Find the appropriate page
			switch (page)
			{
				case ApplicationPage.Login:
					return new LoginPage(viewModel as LoginViewModel);

				case ApplicationPage.MainMenu:
					return new MainMenuPage(viewModel as MainMenuViewModel);

				case ApplicationPage.TicketSelling:
					return new TicketSellingPage(viewModel as TicketSellingViewModel);

				case ApplicationPage.FlightList:
					return new FlightListPage(viewModel as FlightListViewModel);

				case ApplicationPage.Passengers:
					return new PassengersPage(viewModel as PassengersListViewModel);

				case ApplicationPage.Statistics:
					return new StatisticsPage(viewModel as StatisticsViewModel);

				case ApplicationPage.AddOrUpdateTicket:
					return new AddOrUpdateTicketPage(viewModel as AddOrUpdateTicketViewModel);

				case ApplicationPage.AddOrUpdatePassenger:
					return new AddOrUpdatePassengerPage(viewModel as AddOrUpdatePassengerViewModel);

				case ApplicationPage.AddNewFlight:
					return new AddNewFlightPage(viewModel as AddNewFlightViewModel);

				case ApplicationPage.AddNewEmployee:
					return new AddNewEmployeePage(viewModel as AddNewEmployeeViewModel);

				default:
					Debugger.Break();
					return null;
			}
		}

		/// <summary>
		/// Converts a <see cref="BasePage"/> to the specific <see cref="ApplicationPage"/> that is for that type of page
		/// </summary>
		/// <param name="page"></param>
		/// <param name="viewModel"></param>
		/// <returns></returns>
		public static ApplicationPage ToApplicationPage(this BasePage page)
		{
			// Find application page that matches the base page
			if (page is MainMenuPage)
				return ApplicationPage.MainMenu;

			if (page is FlightListPage)
				return ApplicationPage.FlightList;

			if (page is PassengersPage)
				return ApplicationPage.Passengers;

			if (page is TicketSellingPage)
				return ApplicationPage.TicketSelling;

			if (page is StatisticsPage)
				return ApplicationPage.Statistics;

			if (page is LoginPage)
				return ApplicationPage.Login;

			if (page is AddOrUpdateTicketPage)
				return ApplicationPage.AddOrUpdateTicket;

			if (page is AddOrUpdatePassengerPage)
				return ApplicationPage.AddOrUpdatePassenger;

			if (page is AddNewFlightPage)
				return ApplicationPage.AddNewFlight;

			if (page is AddNewEmployeePage)
				return ApplicationPage.AddNewEmployee;

			// Alert developer of issue
			Debugger.Break();
			return default;
		}
	}
}