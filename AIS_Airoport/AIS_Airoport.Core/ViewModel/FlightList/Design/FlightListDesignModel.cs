using System.Collections.ObjectModel;
using System;


namespace AIS_Airport.Core
{
    /// <summary>
    /// The design-time data for a <see cref="FlightListViewModel"/>
    /// </summary>
    public class FlightListDesignModel : FlightListViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static FlightListDesignModel Instance => new FlightListDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public FlightListDesignModel()
        {
            Items = new ObservableCollection<Flight>
            {
                new Flight
                {
                    Code = 11,
                    FlightNumber = "230C",
                    StartDate = new DateTime(2020,8,9),
                    StartTime = "18:00",
                    Airline = "Сибирь",
                    TicketPrice = 14502,
                    Destination = "Новгород"
                },
                new Flight
                {
                    Code = 22,
                    FlightNumber = "23С8",
                    StartDate = new DateTime(2020,10,5),
                    StartTime = "17:00",
                    Airline = "Сибирь",
                    TicketPrice = 5446,
                    Destination = "Сочи"
                },
                new Flight
                {
                    Code = 39,
                    FlightNumber = "21BA",
                    StartDate = new DateTime(2020,3,10),
                    StartTime = "19:00",
                    Airline = "Аэрофлот",
                    TicketPrice = 11344,
                    Destination = "Сочи"
                },
                new Flight
                {
                    Code = 42,
                    FlightNumber = "17E0",
                    StartDate = new DateTime(2020,10,25),
                    StartTime = "16:00",
                    Airline = "Сибирь",
                    TicketPrice = 7753,
                    Destination = "Пермь"
                },
                new Flight
                {
                    Code = 11,
                    FlightNumber = "230C",
                    StartDate = new DateTime(2020,10,5),
                    StartTime = "18:00",
                    Airline = "Сибирь",
                    TicketPrice = 14502,
                    Destination = "Новгород"
                },
                new Flight
                {
                    Code = 22,
                    FlightNumber = "23С8",
                    StartDate = new DateTime(2018,10,5),
                    StartTime = "17:00",
                    Airline = "Сибирь",
                    TicketPrice = 5446,
                    Destination = "Сочи"
                },
                new Flight
                {
                    Code = 39,
                    FlightNumber = "21BA",
                    StartDate = new DateTime(2020,1,10),
                    StartTime = "19:00",
                    Airline = "Аэрофлот",
                    TicketPrice = 11344,
                    Destination = "Сочи"
                },
                new Flight
                {
                    Code = 42,
                    FlightNumber = "17E0",
                    StartDate = new DateTime(2020,10,5),
                    StartTime = "16:00",
                    Airline = "Сибирь",
                    TicketPrice = 7753,
                    Destination = "Пермь"
                },
                new Flight
                {
                    Code = 11,
                    FlightNumber = "230C",
                    StartDate = new DateTime(2019,5,1),
                    StartTime = "18:00",
                    Airline = "Сибирь",
                    TicketPrice = 14502,
                    Destination = "Новгород"
                },
                new Flight
                {
                    Code = 22,
                    FlightNumber = "23С8",
                    StartDate = new DateTime(2020,12,5),
                    StartTime = "17:00",
                    Airline = "Сибирь",
                    TicketPrice = 5446,
                    Destination = "Сочи"
                },
                new Flight
                {
                    Code = 39,
                    FlightNumber = "21BA",
                    StartDate = new DateTime(2020,10,10),
                    StartTime = "19:00",
                    Airline = "Аэрофлот",
                    TicketPrice = 11344,
                    Destination = "Сочи"
                },
                new Flight
                {
                    Code = 42,
                    FlightNumber = "17E0",
                    StartDate = new DateTime(2020,10,5),
                    StartTime = "16:00",
                    Airline = "Сибирь",
                    TicketPrice = 7753,
                    Destination = "Пермь"
                },
            };
        }

        #endregion
    }
}