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
                    TicketNumber="1a11",
                    DepartureDate=DateTime.Parse("25.07.2020"),
                    FlightNumber="1AF",
                    Passenger="Иванов",
                    Employee="Мухин",
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
                    TicketNumber="1a11",
                    DepartureDate=DateTime.Parse("25.07.2020"),
                    FlightNumber="1AF",
                    Passenger="Иванов",
                    Employee="Мухин",
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
                    TicketNumber="1a11",
                    DepartureDate=DateTime.Parse("25.07.2020"),
                    FlightNumber="1AF",
                    Passenger="Иванов",
                    Employee="Мухин",
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
                    TicketNumber="1a11",
                    DepartureDate=DateTime.Parse("25.07.2020"),
                    FlightNumber="1AF",
                    Passenger="Иванов",
                    Employee="Мухин",
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
                    TicketNumber="1a11",
                    DepartureDate=DateTime.Parse("25.07.2020"),
                    FlightNumber="1AF",
                    Passenger="Иванов",
                    Employee="Мухин",
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
                    TicketNumber="1a11",
                    DepartureDate=DateTime.Parse("25.07.2020"),
                    FlightNumber="1AF",
                    Passenger="Иванов",
                    Employee="Мухин",
                },
            };
        }

        #endregion
    }
}