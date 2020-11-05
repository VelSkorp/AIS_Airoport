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
            Items = new ObservableCollection<Ticket>
            {
                new Ticket
                {
                    TicketNumber = "1a11",
                    DepartureDate = DateTime.Parse("25.07.2020"),
                    FlightNumber = "1AF",
                    Passenger = "Иванов",
                    Employee = "Савельев",
                },
                new Ticket
                {
                    TicketNumber = "2a11",
                    DepartureDate = DateTime.Parse("08.03.2020"),
                    FlightNumber = "2AF",
                    Passenger = "Петров",
                    Employee = "Мухин",
                },
                new Ticket
                {
                    TicketNumber = "3a11",
                    DepartureDate = DateTime.Parse("6.10.2020"),
                    FlightNumber = "3AF",
                    Passenger = "Сидоров",
                    Employee = "Чернов",
                },
                new Ticket
                {
                    TicketNumber = "1a11",
                    DepartureDate = DateTime.Parse("25.07.2020"),
                    FlightNumber = "1AF",
                    Passenger = "Иванов",
                    Employee = "Савельев",
                },
                new Ticket
                {
                    TicketNumber = "2a11",
                    DepartureDate = DateTime.Parse("08.03.2020"),
                    FlightNumber = "2AF",
                    Passenger = "Петров",
                    Employee = "Мухин",
                },
                new Ticket
                {
                    TicketNumber = "3a11",
                    DepartureDate = DateTime.Parse("6.10.2020"),
                    FlightNumber = "3AF",
                    Passenger = "Сидоров",
                    Employee = "Чернов",
                },
                new Ticket
                {
                    TicketNumber = "1a11",
                    DepartureDate = DateTime.Parse("25.07.2020"),
                    FlightNumber = "1AF",
                    Passenger = "Иванов",
                    Employee = "Савельев",
                },
                new Ticket
                {
                    TicketNumber = "2a11",
                    DepartureDate = DateTime.Parse("08.03.2020"),
                    FlightNumber = "2AF",
                    Passenger = "Петров",
                    Employee = "Мухин",
                },
                new Ticket
                {
                    TicketNumber = "3a11",
                    DepartureDate = DateTime.Parse("6.10.2020"),
                    FlightNumber = "3AF",
                    Passenger = "Сидоров",
                    Employee = "Чернов",
                },
                new Ticket
                {
                    TicketNumber = "1a11",
                    DepartureDate = DateTime.Parse("25.07.2020"),
                    FlightNumber = "1AF",
                    Passenger = "Иванов",
                    Employee = "Савельев",
                },
                new Ticket
                {
                    TicketNumber = "2a11",
                    DepartureDate = DateTime.Parse("08.03.2020"),
                    FlightNumber = "2AF",
                    Passenger = "Петров",
                    Employee = "Мухин",
                },
                new Ticket
                {
                    TicketNumber = "3a11",
                    DepartureDate = DateTime.Parse("6.10.2020"),
                    FlightNumber = "3AF",
                    Passenger = "Сидоров",
                    Employee = "Чернов",
                },
                new Ticket
                {
                    TicketNumber = "1a11",
                    DepartureDate = DateTime.Parse("25.07.2020"),
                    FlightNumber = "1AF",
                    Passenger = "Иванов",
                    Employee = "Савельев",
                },
                new Ticket
                {
                    TicketNumber = "2a11",
                    DepartureDate = DateTime.Parse("08.03.2020"),
                    FlightNumber = "2AF",
                    Passenger = "Петров",
                    Employee = "Мухин",
                },
                new Ticket
                {
                    TicketNumber = "3a11",
                    DepartureDate = DateTime.Parse("6.10.2020"),
                    FlightNumber = "3AF",
                    Passenger = "Сидоров",
                    Employee = "Чернов",
                },
            };
        }

        #endregion
    }
}