using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AIS_Airport.Core
{
	/// <summary>
	/// The View Model for a add new passenger screen
	/// </summary>
	public class AddOrUpdatePassengerViewModel : BaseViewModel
	{
		#region Public Properties

		/// <summary>
		/// The discount name
		/// </summary>
		public string DiscountName { get; set; }

		/// <summary>
		/// The discount percentage
		/// </summary>
		public string DiscountPercentage { get; set; }

		/// <summary>
		/// The passenger first name
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// The passenger middle name
		/// </summary>
		public string MiddleName { get; set; }

		/// <summary>
		/// The passenger surname
		/// </summary>
		public string Surname { get; set; }

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
		public string Passport { get; set; }

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
		/// A flag indicating if the save discount command is running
		/// </summary>
		public bool SaveDiscountIsRunning { get; set; }

		/// <summary>
		/// A flag indicating if the save passenger command is running
		/// </summary>
		public bool SaveIsRunning { get; set; }

		#endregion

		#region Private Members

		/// <summary>
		/// The passenger ID
		/// </summary>
		private int ID;

		/// <summary>
		/// A flag indicating if the passenger is updating
		/// </summary>
		private bool PassengerIsUpdating { get; set; }

		#endregion

		#region Commands

		/// <summary>
		/// The command save new discount
		/// </summary>
		public ICommand SaveDiscountCommand { get; set; }

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
		public AddOrUpdatePassengerViewModel()
		{
			// Create commands
			SaveDiscountCommand = new RelayAsyncCommand(SaveDiscountAsync);
			SaveCommand = new RelayAsyncCommand(SaveAsync);
			BackCommand = new RelayCommand(Back);
			RefreshCommand = new RelayAsyncCommand(RefreshAsync);

			// Update info
			RefreshAsync();
		}

		/// <summary>
		/// Update passenger constructor
		/// </summary>
		public AddOrUpdatePassengerViewModel(Passenger passenger)
			: this()
		{
			ID = passenger.ID;
			FirstName = passenger.FirstName;
			MiddleName = passenger.MiddleName;
			Surname = passenger.Surname;
			Phone = passenger.Phone;
			Address = passenger.Address;
			Passport = passenger.Passport;
			SelectedDiscount = passenger.Discount;
			PassengerIsUpdating = true;
		}

		#endregion

		#region Command Methods

		/// <summary>
		/// Save new discount
		/// </summary>
		public async Task SaveDiscountAsync()
		{
			await RunCommandAsync(() => SaveDiscountIsRunning, async () =>
			{
				var isSaved = await IoC.DataStore.SaveDiscountCredentialsAsync(new Discount
				{
					DiscountName = DiscountName,
					DiscountPercentage = int.Parse(DiscountPercentage)
				});

				if (isSaved)
				{
					DiscountName = null;
					DiscountPercentage = null;

					await IoC.UI.ShowMessage(new MessageBoxDialogViewModel
					{
						Title = "Successful",
						Message = "Discount successful saved"
					});
					return;
				}

				await IoC.UI.ShowMessage(new MessageBoxDialogViewModel
				{
					Title = "Discount exist",
					Message = "Discount already exist"
				});
			});
		}

		/// <summary>
		/// Save new ticket
		/// </summary>
		public async Task SaveAsync()
		{
			await RunCommandAsync(() => SaveIsRunning, async () =>
			{
				var passengers = await IoC.DataStore.GetCollectionOfPassengersAsync();

				var isSaved = await IoC.DataStore.SavePassengerCredentialsAsync(new Passenger
				{
					ID = PassengerIsUpdating ? ID : passengers.Count + 1,
					Surname = Surname,
					FirstName = FirstName,
					MiddleName = MiddleName,
					Phone = Phone,
					Address = Address,
					Passport = Passport,
					Discount = SelectedDiscount,
				});

				if (isSaved)
				{
					await IoC.UI.ShowMessage(new MessageBoxDialogViewModel
					{
						Title = "Successful",
						Message = "Passenger successful saved"
					});
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
				var discount = await IoC.DataStore.GetCollectionOfDiscountsAsync();
				Discounts = new ObservableCollection<string>(discount.Select((item) => item.DiscountName));
			});
		}

		#endregion
	}
}