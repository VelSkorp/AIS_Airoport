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
		/// The position nomination
		/// </summary>
		public string PositionNomination { get; set; }

		/// <summary>
		/// The right to sell tickets
		/// </summary>
		public bool? RightToSellTickets { get; set; }

		/// <summary>
		/// The right to add new flights
		/// </summary>
		public bool? RightToAddNewFlights { get; set; }

		/// <summary>
		/// The right to add new employees
		/// </summary>
		public bool? RightToAddNewEmployees { get; set; }

		/// <summary>
		/// The employee surname
		/// </summary>
		public string Surname { get; set; }

		/// <summary>
		/// The employee first name
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// The employee patronymic
		/// </summary>
		public string Patronymic { get; set; }

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
				if (PositionNomination == null || RightToSellTickets == null || RightToAddNewFlights == null
					|| RightToAddNewEmployees == null)
				{
					await IoC.UI.ShowMessage(new MessageBoxDialogViewModel
					{
						Title = "Empty position form",
						Message = "Fill out the position form"
					});

					return;
				}

				ObservableCollection<Position> position = await IoC.DataStore.GetCollectionOfPositionsAsync();

				bool isSaved = await IoC.DataStore.SavePositionCredentialsAsync(new Position
				{
					Code = position.Count + 1,
					Nomination = PositionNomination,
					RightToSellTickets = RightToSellTickets.Value ? 1 : 0,
					RightToAddNewFlights = RightToAddNewFlights.Value ? 1 : 0,
					RightToAddNewEmployees = RightToAddNewEmployees.Value ? 1 : 0,
				});

				if (isSaved == false)
				{
					await IoC.UI.ShowMessage(new MessageBoxDialogViewModel
					{
						Title = "Position exist",
						Message = "Position already exist"
					});

					return;
				}

				PositionNomination = null;
				RightToSellTickets = null;
				RightToAddNewFlights = null;
				RightToAddNewEmployees = null;

				await IoC.UI.ShowMessage(new MessageBoxDialogViewModel
				{
					Title = "Successful",
					Message = "Position successful saved"
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
				if (Surname == null || FirstName == null || Patronymic == null || Phone == null || Address == null
					|| Password == null || Positions == null)
				{
					await IoC.UI.ShowMessage(new MessageBoxDialogViewModel
					{
						Title = "Empty employee form",
						Message = "Fill out the employee form"
					});

					return;
				}

				ObservableCollection<EmployeeCredentials> employee = await IoC.DataStore.GetCollectionOfEmployeesAsync();

				bool isSaved = await IoC.DataStore.SaveLoginCredentialsAsync(new EmployeeCredentials
				{
					ID = employee.Count + 1,
					Surname = Surname,
					FirstName = FirstName,
					Patronymic = Patronymic,
					Phone = Phone,
					Address = Address,
					Password = Password,
					Position = Position,
				});

				if (isSaved == false)
				{
					await IoC.UI.ShowMessage(new MessageBoxDialogViewModel
					{
						Title = "Employee exist",
						Message = "Employee already exist"
					});
				}

				Surname = null;
				FirstName = null;
				Patronymic = null;
				Phone = null;
				Address = null;
				Password = null;
				Position = null;

				await IoC.UI.ShowMessage(new MessageBoxDialogViewModel
				{
					Title = "Successful",
					Message = "Employee successful saved"
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
				ObservableCollection<Position> positions = await IoC.DataStore.GetCollectionOfPositionsAsync();
				Positions = new ObservableCollection<string>(positions.Select((item) => item.Nomination));
			});
		}

		#endregion
	}
}