using System.Collections.ObjectModel;

namespace AIS_Airoport.Core
{
    /// <summary>
    /// The design-time data for a <see cref="PassengersListViewModel"/>
    /// </summary>
    public class PassengersListDesignModel : PassengersListViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static PassengersListDesignModel Instance => new PassengersListDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public PassengersListDesignModel()
        {
            Items = new ObservableCollection<Passenger>()
            {
                new Passenger
                {
                    Surname = "Иванов",
                    FirstName = "Иван",
                    Patronymic = "Иванович",
                    Phone = "123-456-789",
                    Address = "улица Центральная 1",
                    Passport = "3425425",
                    Discount = "Начальная"
                },
                new Passenger
                {
                    Surname = "Петров",
                    FirstName = "Петр",
                    Patronymic = "Петрович",
                    Phone = "3231-434-2134",
                    Address = "проспект Космонавтов 213-12",
                    Passport = "632252342",
                    Discount = "Партнер"
                },
                new Passenger
                {
                    Surname = "Сидоров",
                    FirstName = "Елена",
                    Patronymic = "Сергеевна",
                    Phone = "34-43-432",
                    Address = "улица Мира 45-4",
                    Passport = "23421312",
                    Discount = ""
                },
                new Passenger
                {
                    Surname = "Иванов",
                    FirstName = "Иван",
                    Patronymic = "Иванович",
                    Phone = "123-456-789",
                    Address = "улица Центральная 1",
                    Passport = "3425425",
                    Discount = "Начальная"
                },
                new Passenger
                {
                    Surname = "Петров",
                    FirstName = "Петр",
                    Patronymic = "Петрович",
                    Phone = "3231-434-2134",
                    Address = "проспект Космонавтов 213-12",
                    Passport = "632252342",
                    Discount = "Партнер"
                },
                new Passenger
                {
                    Surname = "Сидоров",
                    FirstName = "Елена",
                    Patronymic = "Сергеевна",
                    Phone = "34-43-432",
                    Address = "улица Мира 45-4",
                    Passport = "23421312",
                    Discount = ""
                },
                new Passenger
                {
                    Surname = "Иванов",
                    FirstName = "Иван",
                    Patronymic = "Иванович",
                    Phone = "123-456-789",
                    Address = "улица Центральная 1",
                    Passport = "3425425",
                    Discount = "Начальная"
                },
                new Passenger
                {
                    Surname = "Петров",
                    FirstName = "Петр",
                    Patronymic = "Петрович",
                    Phone = "3231-434-2134",
                    Address = "проспект Космонавтов 213-12",
                    Passport = "632252342",
                    Discount = "Партнер"
                },
                new Passenger
                {
                    Surname = "Сидоров",
                    FirstName = "Елена",
                    Patronymic = "Сергеевна",
                    Phone = "34-43-432",
                    Address = "улица Мира 45-4",
                    Passport = "23421312",
                    Discount = ""
                },
            };
        }

        #endregion
    }
}