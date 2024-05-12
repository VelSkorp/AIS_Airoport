using System.Linq;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Threading.Tasks;

namespace AIS_Airport.Core
{
	/// <summary>
	/// The View Model for a add new passenger screen
	/// </summary>
	public class AddNewPassengerViewModel : BaseViewModel
	{
		#region Public Properties

		/// <summary>
		/// The passenger surname
		/// </summary>
		public string Surname { get; set; }

		/// <summary>
		/// The passenger first name
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// The passenger middle name
		/// </summary>
		public string Patronymic { get; set; }

		/// <summary>
		/// The passenger phone
		/// </summary>
		public string Phone { get; set; }

		/// <summary>
		/// The passenger address
		/// </summary>
		public string Address { get; set; }

		/// <summary>
		/// The passenger passport
		/// </summary>
		public int? Passport { get; set; }

		/// <summary>
		/// The discount for this passenger
		/// </summary>
		public string SelectedDiscount { get; set; }

		/// <summary>
		/// A departure date
		/// </summary>
		public ObservableCollection<string> Discounts { get; set; }

		/// <summary>
		/// A flag indicating if the refresh command is running
		/// </summary>
		public bool RefreshIsRunning { get; set; }

		/// <summary>
		/// A flag indicating if the save passenger command is running
		/// </summary>
		public bool SaveIsRunning { get; set; }

		#endregion

		#region Commands

		/// <summary>
		/// The command save new ticket
		/// </summary>
		public ICommand SaveCommand { get; set; }

		/// <summary>
		/// The command go back to TicketSellingPage
		/// </summary>
		public ICommand BackCommand { get; set; }

		/// <summary>
		/// The command to refresh lists of Flights and Passengers
		/// </summary>
		public ICommand RefreshCommand { get; set; }

		#endregion

		#region Constructor

		/// <summary>
		/// Default constructor
		/// </summary>
		public AddNewPassengerViewModel()
		{
			// Create commands
			SaveCommand = new RelayCommand(async () => await SaveAsync());
			BackCommand = new RelayCommand(Back);
			RefreshCommand = new RelayCommand(async () => await RefreshAsync());
		}

		#endregion

		#region Command Methods

		/// <summary>
		/// Save new ticket
		/// </summary>
		public async Task SaveAsync()
		{
			await RunCommandAsync(() => SaveIsRunning, async () =>
			{
				if (Surname == null || FirstName == null || Patronymic == null || Phone == null
				    || Address == null || Passport == null || SelectedDiscount == null)
				{
					await IoC.UI.ShowMessage(new MessageBoxDialogViewModel
					{
						Title = "Empty passenger form",
						Message = "Fill out the passenger form"
					});

					return;
				}

				ObservableCollection<Passenger> passengers = await IoC.DataStore.GetCollectionOfPassengersAsync();

				bool isSaved = await IoC.DataStore.SavePassengerCredentialsAsync(new Passenger
				{
					ID = passengers.Count + 1,
					Surname = Surname,
					FirstName = FirstName,
					Patronymic = Patronymic,
					Phone = Phone,
					Address = Address,
					Passport = Passport.Value,
					Discount = SelectedDiscount,
				});

				if (isSaved)
				{
					IoC.Application.GoToPage(ApplicationPage.Passengers);
					return;
				}

				await IoC.UI.ShowMessage(new MessageBoxDialogViewModel
				{
					Title = "Passenger exist",
					Message = "Passenger already exist"
				});
			});
		}

		/// <summary>
		/// Go back to TicketSellingPage
		/// </summary>
		public void Back()
		{
			IoC.Application.GoToPage(ApplicationPage.Passengers);
		}

		/// <summary>
		/// Save new ticket
		/// </summary>
		public async Task RefreshAsync()
		{
			await RunCommandAsync(() => RefreshIsRunning, async () =>
			{
				ObservableCollection<Discount> discount = await IoC.DataStore.GetCollectionOfDiscountsAsync();
				Discounts = new ObservableCollection<string>(discount.Select((item) => item.DiscountName));
			});
		}

		#endregion
	}
}