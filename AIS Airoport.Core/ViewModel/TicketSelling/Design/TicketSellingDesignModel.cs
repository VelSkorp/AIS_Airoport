using System.Collections.ObjectModel;
using System;


namespace AIS_Airoport.Core
{
    /// <summary>
    /// The design-time data for a <see cref="TicketSellingViewModel"/>
    /// </summary>
    public class TicketSellingDesignModel : TicketSellingViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static TicketSellingDesignModel Instance => new TicketSellingDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public TicketSellingDesignModel()
        {
            Items = new ObservableCollection<TicketSellingItemViewModel>
            {
                new TicketSellingItemViewModel
                {
                    TicketNumber="1a11",
                    DepartureDate=DateTime.Parse("25.07.2020"),
                    FlightNumber="1AF",
                    Passenger="Иванов",
                    Employee="Мухин",
                },
                new TicketSellingItemViewModel
                {
                    TicketNumber="2a11",
                    DepartureDate=DateTime.Parse("08.03.2020"),
                    FlightNumber="3DD",
                    Passenger="Тимофеева",
                    Employee="Савельев",
                },
                new TicketSellingItemViewModel
                {
                    TicketNumber="3a11",
                    DepartureDate=DateTime.Parse("6.10.2020"),
                    FlightNumber="12DS",
                    Passenger="Гостева",
                    Employee="Чернов",
                },
                new TicketSellingItemViewModel
                {
                    TicketNumber="1a11",
                    DepartureDate=DateTime.Parse("25.07.2020"),
                    FlightNumber="1AF",
                    Passenger="Иванов",
                    Employee="Мухин",
                },
                new TicketSellingItemViewModel
                {
                    TicketNumber="2a11",
                    DepartureDate=DateTime.Parse("08.03.2020"),
                    FlightNumber="3DD",
                    Passenger="Тимофеева",
                    Employee="Савельев",
                },
                new TicketSellingItemViewModel
                {
                    TicketNumber="3a11",
                    DepartureDate=DateTime.Parse("6.10.2020"),
                    FlightNumber="12DS",
                    Passenger="Гостева",
                    Employee="Чернов",
                },
                new TicketSellingItemViewModel
                {
                    TicketNumber="1a11",
                    DepartureDate=DateTime.Parse("25.07.2020"),
                    FlightNumber="1AF",
                    Passenger="Иванов",
                    Employee="Мухин",
                },
                new TicketSellingItemViewModel
                {
                    TicketNumber="2a11",
                    DepartureDate=DateTime.Parse("08.03.2020"),
                    FlightNumber="3DD",
                    Passenger="Тимофеева",
                    Employee="Савельев",
                },
                new TicketSellingItemViewModel
                {
                    TicketNumber="3a11",
                    DepartureDate=DateTime.Parse("6.10.2020"),
                    FlightNumber="12DS",
                    Passenger="Гостева",
                    Employee="Чернов",
                },
                new TicketSellingItemViewModel
                {
                    TicketNumber="1a11",
                    DepartureDate=DateTime.Parse("25.07.2020"),
                    FlightNumber="1AF",
                    Passenger="Иванов",
                    Employee="Мухин",
                },
                new TicketSellingItemViewModel
                {
                    TicketNumber="2a11",
                    DepartureDate=DateTime.Parse("08.03.2020"),
                    FlightNumber="3DD",
                    Passenger="Тимофеева",
                    Employee="Савельев",
                },
                new TicketSellingItemViewModel
                {
                    TicketNumber="3a11",
                    DepartureDate=DateTime.Parse("6.10.2020"),
                    FlightNumber="12DS",
                    Passenger="Гостева",
                    Employee="Чернов",
                },
                new TicketSellingItemViewModel
                {
                    TicketNumber="1a11",
                    DepartureDate=DateTime.Parse("25.07.2020"),
                    FlightNumber="1AF",
                    Passenger="Иванов",
                    Employee="Мухин",
                },
                new TicketSellingItemViewModel
                {
                    TicketNumber="2a11",
                    DepartureDate=DateTime.Parse("08.03.2020"),
                    FlightNumber="3DD",
                    Passenger="Тимофеева",
                    Employee="Савельев",
                },
                new TicketSellingItemViewModel
                {
                    TicketNumber="3a11",
                    DepartureDate=DateTime.Parse("6.10.2020"),
                    FlightNumber="12DS",
                    Passenger="Гостева",
                    Employee="Чернов",
                },
            };
        }

        #endregion
    }
}