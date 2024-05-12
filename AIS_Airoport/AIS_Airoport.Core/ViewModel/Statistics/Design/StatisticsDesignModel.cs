using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace AIS_Airport.Core
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
		}

		#endregion

		#region Overrided Command Methods

		/// <summary>
		/// Setting data in table and chart in the profit tab by directions
		/// </summary>
		public override Task RefreshProfitByDestinationAsync()
		{
			return Task.FromResult(Data = new ObservableCollection<DataItem>()
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
			});
		}

		/// <summary>
		/// Setting data in the table and on the diagram 
		/// in the profit by transportation tab
		/// </summary>
		public override Task RefreshProfitOnTransportationAsync()
		{
			return Task.FromResult(Data = new ObservableCollection<DataItem>()
			{
				new DataItem()
				{
					Name = "2AF",
					Value = 144000
				},
				new DataItem()
				{
					Name = "3DD",
					Value = 60000
				},
				new DataItem()
				{
					Name = "4CD",
					Value = 70000
				},
				new DataItem()
				{
					Name = "1AF",
					Value = 120000
				},
				new DataItem()
				{
					Name = "12DS",
					Value = 144000
				},
				new DataItem()
				{
					Name = "2AD",
					Value = 20000
				},
			});
		}

		/// <summary>
		/// Setting data in the table 
		/// and on the diagram in the profit by transportation tab
		/// </summary>
		public override Task RefreshNumberOfDiscountedTicketsByDiscountAsync()
		{
			return Task.FromResult(Data = new ObservableCollection<DataItem>()
			{
				new DataItem()
				{
					Name = "Накопительная",
					Value = 6
				},
				new DataItem()
				{
					Name = "Начальная",
					Value = 6
				},
				new DataItem()
				{
					Name = "Акция \"Аэровесна\"",
					Value = 4
				},
				new DataItem()
				{
					Name = "Партнер",
					Value = 8
				},
			});
		}

		/// <summary>
		/// Setting data in the table and on the diagram 
		/// in the tab for finding the average cost of tickets
		/// </summary>
		public override Task RefreshAverageTicketPricesAsync()
		{
			return Task.FromResult(Data = new ObservableCollection<DataItem>()
			{
				new DataItem()
				{
					Name = "EuroAir",
					Value = 10085
				},
				new DataItem()
				{
					Name = "Аэрофлот",
					Value = 7917
				},
				new DataItem()
				{
					Name = "Домодедовские авиалинии",
					Value = 8733
				},
				new DataItem()
				{
					Name = "Сибирь",
					Value = 7893
				},
			});
		}

		/// <summary>
		/// Setting data in the table and on the diagram in the destinations tab
		/// </summary>
		public override Task RefreshNumberOfticketsByDestinationsAsync()
		{
			return Task.FromResult(Data = new ObservableCollection<DataItem>()
			{
				new DataItem()
				{
					Name = "Владивосток",
					Value = 2
				},
				new DataItem()
				{
					Name = "Мурманск",
					Value = 1
				},
				new DataItem()
				{
					Name = "Новгород",
					Value = 15
				},
				new DataItem()
				{
					Name = "Пермь",
					Value = 13
				},
				new DataItem()
				{
					Name = "Сочи",
					Value = 12
				},
			});
		}

		/// <summary>
		/// Setting data in the airline tab
		/// </summary>
		public override Task RefreshNumberOfticketsByAirlinesAsync()
		{
			return Task.FromResult(Data = new ObservableCollection<DataItem>()
			{
				new DataItem()
				{
					Name = "EuroAir",
					Value = 4
				},
				new DataItem()
				{
					Name = "Аэрофлот",
					Value = 10
				},
				new DataItem()
				{
					Name = "Домодедовские авиалинии",
					Value = 7
				},
				new DataItem()
				{
					Name = "Сибирь",
					Value = 13
				},
			});
		}

		/// <summary>
		/// Setting data in the table and on the graph 
		/// in the tab of ticket sales by passengers
		/// </summary>
		public override Task RefreshProfitFromTicketSalesByPassengerAsync()
		{
			return Task.FromResult(Data = new ObservableCollection<DataItem>()
			{
				new DataItem()
				{
					Name = "Иванов",
					Value = 10085
				},
				new DataItem()
				{
					Name = "Петров",
					Value = 7917
				},
				new DataItem()
				{
					Name = "Сидоров",
					Value = 8733
				},
				new DataItem()
				{
					Name = "Сухов",
					Value = 7893
				},
				new DataItem()
				{
					Name = "Николашин",
					Value = 10085
				},
				new DataItem()
				{
					Name = "Тимофеева",
					Value = 7917
				},
				new DataItem()
				{
					Name = "Гостева",
					Value = 8733
				},
				new DataItem()
				{
					Name = "Цыбочкин",
					Value = 7893
				},
				new DataItem()
				{
					Name = "Легошина",
					Value = 10085
				},
				new DataItem()
				{
					Name = "Пигалёва",
					Value = 7917
				},
				new DataItem()
				{
					Name = "Арбузова",
					Value = 8733
				},
				new DataItem()
				{
					Name = "Свистунова",
					Value = 7893
				},
				new DataItem()
				{
					Name = "Тараскина",
					Value = 10085
				},
				new DataItem()
				{
					Name = "Гусева",
					Value = 7917
				},
				new DataItem()
				{
					Name = "Каменева",
					Value = 8733
				},
				new DataItem()
				{
					Name = "Филатов",
					Value = 7893
				},
				new DataItem()
				{
					Name = "Калмыкова",
					Value = 10085
				},
				new DataItem()
				{
					Name = "Кособоков",
					Value = 7917
				},
				new DataItem()
				{
					Name = "Шафеева",
					Value = 8733
				},
				new DataItem()
				{
					Name = "Мусаков",
					Value = 7893
				},
				new DataItem()
				{
					Name = "Акишина",
					Value = 10085
				},
				new DataItem()
				{
					Name = "Гурова",
					Value = 7917
				},
				new DataItem()
				{
					Name = "Зайкова",
					Value = 8733
				},
				new DataItem()
				{
					Name = "Тележкин",
					Value = 7893
				},
			});
		}

		#endregion
	}
}