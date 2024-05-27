using System.Security;
using System.Windows.Input;

namespace AIS_Airport.Core
{
	/// <summary>
	/// The View Model for a login screen
	/// </summary>
	public class LoginViewModel : BaseViewModel
	{
		#region Public Properties

		/// <summary>
		/// The email of the user
		/// </summary>
		public string Username { get; set; }

		/// <summary>
		/// A flag indicating if the login command is running
		/// </summary>
		public bool LoginIsRunning { get; set; }

		#endregion

		#region Commands

		/// <summary>
		/// The command to login
		/// </summary>
		public ICommand LoginCommand { get; set; }

		#endregion

		#region Constructor

		/// <summary>
		/// Default constructor
		/// </summary>
		public LoginViewModel()
		{
			// Create commands
			LoginCommand = new RelayParameterizedAsyncCommand(LoginAsync);
		}

		#endregion

		/// <summary>
		/// Attempts to log the user in
		/// </summary>
		/// <param name="parameter">The <see cref="SecureString"/> passed in from the view for the users password</param>
		/// <returns></returns>
		public async Task LoginAsync(object parameter)
		{
			await RunCommandAsync(() => LoginIsRunning, async () =>
			{
				await Task.Delay(1000);

				var loginCredentials = new LoginCredentialsApiModel
				{
					Surname = Username,
					Password = MD5.Encrypt((parameter as IHavePassword).Password.Unsecure())
				};

				if (await IoC.DataStore.LoginAsync(loginCredentials) == false)
				{
					await IoC.UI.ShowMessage(new MessageBoxDialogViewModel
					{
						Title = "Wrong Credentials",
						Message = "The current password or username is invalid or empty"
					});

					return;
				}

				IoC.Application.GoToPage(ApplicationPage.MainMenu);
			});
		}
	}
}