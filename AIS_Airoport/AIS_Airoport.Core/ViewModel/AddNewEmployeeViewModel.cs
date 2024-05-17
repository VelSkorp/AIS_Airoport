using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AIS_Airport.Core
{
	/// <summary>
	/// The View Model for a add new employee screen
	/// </summary>
	public class AddNewEmployeeViewModel : BaseViewModel
	{
        #region Public Properties

        /// <summary>
        /// The position title
        /// </summary>
        public string PositionTitle { get; set; }

		/// <summary>
		/// The right to sell tickets
		/// </summary>
		public bool RightToSellTickets { get; set; } = false;

		/// <summary>
		/// The right to add new flights
		/// </summary>
		public bool RightToAddNewFlights { get; set; } = false;

		/// <summary>
		/// The right to add new employees
		/// </summary>
		public bool RightToAddNewEmployees { get; set; } = false;

		/// <summary>
		/// The employee surname
		/// </summary>
		public string Surname { get; set; }

		/// <summary>
		/// The employee first name
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// The employee middle name
		/// </summary>
		public string MiddleName { get; set; }

		/// <summary>
		/// The employee phone
		/// </summary>
		public string Phone { get; set; }

		/// <summary>
		/// The employee address
		/// </summary>
		public string Address { get; set; }

		/// <summary>
		/// The employee password
		/// </summary>
		public string Password { get; set; }

		/// <summary>
		/// The employee position
		/// </summary>
		public string Position { get; set; }

		/// <summary>
		/// A list of positions
		/// </summary>
		public ObservableCollection<string> Positions { get; set; }

		/// <summary>
		/// A flag indicating if the refresh command is running
		/// </summary>
		public bool RefreshIsRunning { get; set; }

		/// <summary>
		/// A flag indicating if the save position command is running
		/// </summary>
		public bool SavePositionIsRunning { get; set; }

		/// <summary>
		/// A flag indicating if the save employee command is running
		/// </summary>
		public bool SaveEmployeeIsRunning { get; set; }

		#endregion

		#region Commands

		/// <summary>
		/// The command save new position
		/// </summary>
		public ICommand SavePositionCommand { get; set; }

		/// <summary>
		/// The command save new employee
		/// </summary>
		public ICommand SaveEmployeeCommand { get; set; }

		/// <summary>
		/// The command go back to MainMenuPage
		/// </summary>
		public ICommand BackCommand { get; set; }

		/// <summary>
		/// Refresh lists of Positions
		/// </summary>
		public ICommand RefreshCommand { get; set; }

		#endregion

		#region Constructor

		/// <summary>
		/// Default constructor
		/// </summary>
		public AddNewEmployeeViewModel()
		{
			// Create commands
			SavePositionCommand = new RelayAsyncCommand(SavePositionAsync);
			SaveEmployeeCommand = new RelayAsyncCommand(SaveEmployeeAsync);
			BackCommand = new RelayCommand(Back);
			RefreshCommand = new RelayAsyncCommand(RefreshAsync);
		}

		#endregion

		#region Command Methods

		/// <summary>
		/// Save new position
		/// </summary>
		public async Task SavePositionAsync()
		{
			await RunCommandAsync(() => SavePositionIsRunning, async () =>
			{
				var position = await IoC.DataStore.GetCollectionOfPositionsAsync();

				var isSaved = await IoC.DataStore.SavePositionCredentialsAsync(new Position
				{
					Code = position.Count + 1,
					Title = PositionTitle,
					RightToSellTickets = RightToSellTickets ? 1 : 0,
					RightToAddNewFlights = RightToAddNewFlights ? 1 : 0,
					RightToAddNewEmployees = RightToAddNewEmployees ? 1 : 0,
				});

				if (isSaved)
				{
					PositionTitle = null;
					RightToSellTickets = false;
					RightToAddNewFlights = false;
					RightToAddNewEmployees = false;

					await IoC.UI.ShowMessage(new MessageBoxDialogViewModel
					{
						Title = "Successful",
						Message = "Position successful saved"
					});
					return;
				}

				await IoC.UI.ShowMessage(new MessageBoxDialogViewModel
				{
					Title = "Position exist",
					Message = "Position already exist"
				});
			});
		}

		/// <summary>
		/// Save new employee
		/// </summary>
		public async Task SaveEmployeeAsync()
		{
			await RunCommandAsync(() => SaveEmployeeIsRunning, async () =>
			{
				var employee = await IoC.DataStore.GetCollectionOfEmployeesAsync();

				var isSaved = await IoC.DataStore.SaveLoginCredentialsAsync(new EmployeeCredentials
				{
					ID = employee.Count + 1,
					Surname = Surname,
					FirstName = FirstName,
					MiddleName = MiddleName,
					Phone = Phone,
					Address = Address,
					Password = Password,
					Position = Position,
				});

				if (isSaved)
				{
					Surname = null;
					FirstName = null;
					MiddleName = null;
					Phone = null;
					Address = null;
					Password = null;
					Position = null;

					await IoC.UI.ShowMessage(new MessageBoxDialogViewModel
					{
						Title = "Successful",
						Message = "Employee successful saved"
					});
					return;
				}

				await IoC.UI.ShowMessage(new MessageBoxDialogViewModel
				{
					Title = "Employee exist",
					Message = "Employee already exist"
				});
			});
		}

		/// <summary>
		/// Go back to MainMenuPage
		/// </summary>
		public void Back()
		{
			IoC.Application.GoToPage(ApplicationPage.MainMenu);
		}

		/// <summary>
		/// Refresh lists of Positions
		/// </summary>
		public async Task RefreshAsync()
		{
			await RunCommandAsync(() => RefreshIsRunning, async () =>
			{
				var positions = await IoC.DataStore.GetCollectionOfPositionsAsync();
				Positions = new ObservableCollection<string>(positions.Select((item) => item.Title));
			});
		}

		#endregion
	}
}