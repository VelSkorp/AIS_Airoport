using AIS_Airoport.Core;
using System;
using System.Diagnostics;

namespace AIS_Airoport
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

                case ApplicationPage.Register:
                    throw new NotImplementedException("Implement Register Page");

                case ApplicationPage.MainMenu:
                    return new MainMenuPage(viewModel as MainMenuViewModel);

                case ApplicationPage.TicketSelling:
                    return new TicketSellingPage(viewModel as TicketSellingViewModel);

                case ApplicationPage.FlightList:
                    return new FlightListPage(viewModel as FlightListViewModel);

                case ApplicationPage.Passengers:
                    throw new NotImplementedException("Implement Passengers Page");

                case ApplicationPage.Statistics:
                    throw new NotImplementedException("Implement Statistics Page");

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

            if (page is TicketSellingPage)
                return ApplicationPage.TicketSelling;

            if (page is LoginPage)
                return ApplicationPage.Login;

            //if (page is RegisterPage)
            //    return ApplicationPage.Register;

            // Alert developer of issue
            Debugger.Break();
            return default;
        }
    }
}