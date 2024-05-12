using System.Windows.Input;

namespace AIS_Airport.Core
{
    /// <summary>
    /// The View Model for a login screen
    /// </summary>
    public class MainMenuViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The right to add new employees 
        /// </summary>
        public bool HasRightToAddNewEmployees { get; set; } = IoC.DataStore.GetEmployeeRightToAddNewEmployeesAsync().Result;

        #endregion

        #region Commands

        /// <summary>
        /// The command to login
        /// </summary>
        public ICommand TicketSellingCommand { get; set; }

        /// <summary>
        /// The command to login
        /// </summary>
        public ICommand FlightListCommand { get; set; }

        /// <summary>
        /// The command to login
        /// </summary>
        public ICommand PassengersCommand { get; set; }

        /// <summary>
        /// The command to login
        /// </summary>
        public ICommand StatisticsCommand { get; set; }

        /// <summary>
        /// The command add new employee
        /// </summary>
        public ICommand AddNewEmployeeCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public MainMenuViewModel()
        {
            // Create commands
            TicketSellingCommand = new RelayCommand(TicketSelling);
            FlightListCommand = new RelayCommand(FlightList);
            PassengersCommand = new RelayCommand(Passengers);
            StatisticsCommand = new RelayCommand(Statistics);
            AddNewEmployeeCommand = new RelayCommand(AddNewEmployee);
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Transition to ticket sales
        /// </summary>
        public void TicketSelling()
        {
            // Go to Ticket Selling page
            IoC.Application.GoToPage(ApplicationPage.TicketSelling);
        }

        /// <summary>
        /// Go to the list of flights
        /// </summary>
        public void FlightList()
        {
            // Go to Flight List page
            IoC.Application.GoToPage(ApplicationPage.FlightList);
        }

        /// <summary>
        /// Go to the list of passengers
        /// </summary>
        public void Passengers()
        {
            // Go to Passengers page
            IoC.Application.GoToPage(ApplicationPage.Passengers);
        }

        /// <summary>
        /// Go to view statistics
        /// </summary>
        public void Statistics()
        {
            // Go to Statistics page
            IoC.Application.GoToPage(ApplicationPage.Statistics);
        }

        /// <summary>
        /// Go to the page for adding a new employee
        /// </summary>
        public void AddNewEmployee()
        {
            // Go to Statistics page
            IoC.Application.GoToPage(ApplicationPage.AddNewEmployee);
        } 

        #endregion
    }
}