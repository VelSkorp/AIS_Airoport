using System.Collections.ObjectModel;

namespace AIS_Airoport.Core
{
    /// <summary>
    /// The design-time data for a <see cref = "StatisticsViewModel"/>
    /// </summary>
    public class StatisticsDesignModel : StatisticsViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static StatisticsDesignModel Instance => new StatisticsDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public StatisticsDesignModel()
        {
            DestinationItems = new ObservableCollection<DataItem>()
            {
                new DataItem()
                {
                    Name = "Береза",
                    Value = 1234
                },
                new DataItem()
                {
                    Name = "Москва",
                    Value = 4321
                },
                new DataItem()
                {
                    Name = "Лондон",
                    Value = 5677
                },
                new DataItem()
                {
                    Name = "Воронеж",
                    Value = 8765
                },
                new DataItem()
                {
                    Name = "Менск",
                    Value = 3244
                },
                new DataItem()
                {
                    Name = "Гродно",
                    Value = 6432
                },
                new DataItem()
                {
                    Name = "Вороново",
                    Value = 3423
                },
                new DataItem()
                {
                    Name = "Кобрин",
                    Value = 6432
                },
                new DataItem()
                {
                    Name = "Новгород",
                    Value = 1234
                },
                new DataItem()
                {
                    Name = "Пермь",
                    Value = 4321
                },
                new DataItem()
                {
                    Name = "Сочи",
                    Value = 5677
                },
                new DataItem()
                {
                    Name = "Минск",
                    Value = 8765
                },
                new DataItem()
                {
                    Name = "Пинск",
                    Value = 4355
                },
                new DataItem()
                {
                    Name = "Брест",
                    Value = 6432
                },
                new DataItem()
                {
                    Name = "Витебск",
                    Value = 3423
                },
                new DataItem()
                {
                    Name = "Могилев",
                    Value = 6432
                },
            };
        }

        #endregion
    }
}