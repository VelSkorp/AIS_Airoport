using System.Linq;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System;

namespace AIS_Airoport.Core
{
    /// <summary>
    /// The View Model for a add new flight screen
    /// </summary>
    public class AddNewFlightViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The airline nomination
        /// </summary>
        public string AirlineNomination { get; set; }

        /// <summary>
        /// The airline contacts
        /// </summary>
        public string AirlineContacts { get; set; }

        /// <summary>
        /// The airline head office address
        /// </summary>
        public string AirlineHeadOfficeAddress { get; set; }

        /// <summary>
        /// The airplane board number
        /// </summary>
        public string AirplaneBoardNumber { get; set; }

        /// <summary>
        /// The airplane model
        /// </summary>
        public string AirplaneModel { get; set; }

        /// <summary>
        /// The airplane capacity
        /// </summary>
        public string AirplaneCapacity { get; set; }

        /// <summary>
        /// The airplane date entered
        /// </summary>
        public DateTime? AirplaneDateEntered { get; set; } = null;

        /// <summary>
        /// The destination nomination
        /// </summary>
        public string DestinationNomination { get; set; }

        /// <summary>
        /// The destination adress
        /// </summary>
        public string DestinationAdress { get; set; }

        /// <summary>
        /// The destination cordinates
        /// </summary>
        public string DestinationCoordinates { get; set; }

        /// <summary>
        /// The discount name
        /// </summary>
        public string DiscountName { get; set; }

        /// <summary>
        /// The discount percentage
        /// </summary>
        public string DiscountPercentage { get; set; }

        /// <summary>
        /// The flight number
        /// </summary>
        public string FlightNumber { get; set; }

        /// <summary>
        /// The flight start date
        /// </summary>
        public DateTime? FlightStartDate { get; set; } = null;

        /// <summary>
        /// The flight start time
        /// </summary>
        public string FlightStartTime { get; set; }

        /// <summary>
        /// The flight ticket price
        /// </summary>
        public string FlightTicketPrice { get; set; }

        /// <summary>
        /// The flight select airline
        /// </summary>
        public string FlightSelectAirline { get; set; }

        /// <summary>
        /// The flight select destination
        /// </summary>
        public string FlightSelectDestination { get; set; }

        /// <summary>
        /// The flight select airplane
        /// </summary>
        public string FlightSelectAirplane { get; set; }

        /// <summary>
        /// A list of airlines
        /// </summary>
        public ObservableCollection<string> Airlines { get; set; }

        /// <summary>
        /// A list of destinations
        /// </summary>
        public ObservableCollection<string> Destinations { get; set; }

        /// <summary>
        /// A list of airplanes
        /// </summary>
        public ObservableCollection<string> Airplanes { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// The command save new airline
        /// </summary>
        public ICommand SaveAirlineCommand { get; set; }

        /// <summary>
        /// The command save new airplane
        /// </summary>
        public ICommand SaveAirplaneCommand { get; set; }

        /// <summary>
        /// The command save new destination
        /// </summary>
        public ICommand SaveDestinationCommand { get; set; }

        /// <summary>
        /// The command save new discount
        /// </summary>
        public ICommand SaveDiscountCommand { get; set; }

        /// <summary>
        /// The command save new flight
        /// </summary>
        public ICommand SaveFlightCommand { get; set; }

        /// <summary>
        /// The command go back to FlightListPage
        /// </summary>
        public ICommand BackCommand { get; set; }

        /// <summary>
        /// The command to refresh lists of Airline, Airplanes and Destination
        /// </summary>
        public ICommand RefreshCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public AddNewFlightViewModel()
        {
            // Create commands
            SaveAirlineCommand = new RelayCommand(SaveAirlineAsync);
            SaveAirplaneCommand = new RelayCommand(SaveAirplaneAsync);
            SaveDestinationCommand = new RelayCommand(SaveDestinationAsync);
            SaveDiscountCommand = new RelayCommand(SaveDiscountAsync);
            SaveFlightCommand = new RelayCommand(SaveFlightAsync);
            BackCommand = new RelayCommand(Back);
            RefreshCommand = new RelayCommand(RefreshAsync);
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Save new airline
        /// </summary>
        public async void SaveAirlineAsync()
        {
            if (AirlineNomination == null || AirlineContacts == null || AirlineHeadOfficeAddress == null)
            {
                await IoC.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "Empty airline form",
                    Message = "Fill out the airline form"
                });

                return;
            }

            ObservableCollection<Airline> airline = await IoC.DataStore.GetCollectionOfAirlinesAsync();

            bool isSaved = await IoC.DataStore.SaveAirlineCredentialsAsync(new Airline
            {
                Code = airline.Count + 1,
                Nomination = AirlineNomination,
                Сontacts = AirlineContacts,
                HeadOfficeAddress = AirlineHeadOfficeAddress,
            });

            if (isSaved == false)
            {
                await IoC.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "Airline exist",
                    Message = "Airline already exist"
                });

                return;
            }

            AirlineNomination = null;
            AirlineContacts = null;
            AirlineHeadOfficeAddress = null;

            await IoC.UI.ShowMessage(new MessageBoxDialogViewModel
            {
                Title = "Successful",
                Message = "Airline successful saved"
            });
        }

        /// <summary>
        /// Save new airplane
        /// </summary>
        public async void SaveAirplaneAsync()
        {
            if (AirplaneBoardNumber == null || AirplaneModel == null || AirplaneCapacity == null || AirplaneDateEntered == null
                || int.TryParse(AirplaneCapacity, out int capacity) == false)
            {
                await IoC.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "Empty airplane form",
                    Message = "Fill out the airplane form"
                });

                return;
            }

            ObservableCollection<Airplane> airplane = await IoC.DataStore.GetCollectionOfAirplanesAsync();

            bool isSaved = await IoC.DataStore.SaveAirplaneCredentialsAsync(new Airplane
            {
                Code = airplane.Count + 1,
                BoardNumber = AirplaneBoardNumber,
                Model = AirplaneModel,
                Capacity = capacity,
                DateEntered = AirplaneDateEntered.Value,
            });

            if (isSaved == false)
            {
                await IoC.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "Airplane exist",
                    Message = "Airplane already exist"
                });
            }

            AirplaneBoardNumber = null;
            AirplaneModel = null;
            AirplaneCapacity = null;
            AirplaneDateEntered = null;

            await IoC.UI.ShowMessage(new MessageBoxDialogViewModel
            {
                Title = "Successful",
                Message = "Airplane successful saved"
            });
        }

        /// <summary>
        /// Save new destination
        /// </summary>
        public async void SaveDestinationAsync()
        {
            if (DestinationNomination == null || DestinationAdress == null || DestinationCoordinates == null)
            {
                await IoC.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "Empty destination form",
                    Message = "Fill out the destination form"
                });

                return;
            }

            ObservableCollection<Destination> destination = await IoC.DataStore.GetCollectionOfDestinationsAsync();

            bool isSaved = await IoC.DataStore.SaveDestinationCredentialsAsync(new Destination
            {
                Code = destination.Count + 1,
                Nomination = DestinationNomination,
                Adress = DestinationAdress,
                Сoordinates = DestinationCoordinates,
            });

            if (isSaved == false)
            {
                await IoC.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "Destination exist",
                    Message = "Destination already exist"
                });
            }

            DestinationNomination = null;
            DestinationAdress = null;
            DestinationCoordinates = null;

            await IoC.UI.ShowMessage(new MessageBoxDialogViewModel
            {
                Title = "Successful",
                Message = "Destination successful saved"
            });
        }

        /// <summary>
        /// Save new discount
        /// </summary>
        public async void SaveDiscountAsync()
        {
            if (DiscountName == null || DiscountPercentage == null || int.TryParse(DiscountPercentage, out int percentage) == false)
            {
                await IoC.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "Empty discount form",
                    Message = "Fill out the discount form"
                });

                return;
            }

            bool isSaved = await IoC.DataStore.SaveDiscountCredentialsAsync(new Discount
            {
                DiscountName = DiscountName,
                DiscountPercentage = percentage
            });

            if (isSaved == false)
            {
                await IoC.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "Discount exist",
                    Message = "Discount already exist"
                });
            }

            DiscountName = null;
            DiscountPercentage = null;

            await IoC.UI.ShowMessage(new MessageBoxDialogViewModel
            {
                Title = "Successful",
                Message = "Discount successful saved"
            });
        }

        /// <summary>
        /// Save new flight
        /// </summary>
        public async void SaveFlightAsync()
        {
            if (FlightNumber == null || FlightStartDate == null || FlightStartTime == null || FlightTicketPrice == null || FlightSelectAirline == null 
                || FlightSelectDestination == null || FlightSelectAirplane == null || int.TryParse(FlightTicketPrice, out int ticketPrice)==false)
            {
                await IoC.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "Empty flight form",
                    Message = "Fill out the flight form"
                });

                return;
            }

            ObservableCollection<Flight> flight = await IoC.DataStore.GetCollectionOfFlightsAsync();

            bool isSaved = await IoC.DataStore.SaveFlightCredentialsAsync(new Flight
            {
                Code = flight.Count + 1,
                FlightNumber = FlightNumber,
                StartDate = FlightStartDate.Value,
                StartTime = FlightStartTime,
                TicketPrice = ticketPrice,
                Airline = FlightSelectAirline,
                Destination = FlightSelectDestination,
                Airplane = FlightSelectAirplane,
            });

            if (isSaved == false)
            {
                await IoC.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "Flight exist",
                    Message = "Flight already exist"
                });
            }

            FlightNumber = null;
            FlightStartDate = null;
            FlightStartTime = null;
            FlightTicketPrice = null;
            FlightSelectAirline = null;
            FlightSelectDestination = null;
            FlightSelectAirplane = null;

            await IoC.UI.ShowMessage(new MessageBoxDialogViewModel
            {
                Title = "Successful",
                Message = "Flight successful saved"
            });
        }

        /// <summary>
        /// Go back to FlightListPage
        /// </summary>
        public void Back()
        {
            IoC.Application.GoToPage(ApplicationPage.FlightList);
        }

        /// <summary>
        /// Refresh lists of Airline, Airplanes and Destination
        /// </summary>
        public async void RefreshAsync()
        {
            ObservableCollection<Airline> airlines = await IoC.DataStore.GetCollectionOfAirlinesAsync();
            Airlines = new ObservableCollection<string>(airlines.Select((item) => item.Nomination));

            ObservableCollection<Destination> destination = await IoC.DataStore.GetCollectionOfDestinationsAsync();
            Destinations = new ObservableCollection<string>(destination.Select((item) => item.Nomination));

            ObservableCollection<Airplane> airplane = await IoC.DataStore.GetCollectionOfAirplanesAsync();
            Airplanes = new ObservableCollection<string>(airplane.Select((item) => item.BoardNumber));
        }

        #endregion
    }
}