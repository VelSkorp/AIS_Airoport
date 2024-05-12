using System;
using System.Security;
using System.Threading.Tasks;
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
			LoginCommand = new RelayParameterizedCommand(async (parameter) => await LoginAsync(parameter));
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
					Password = (parameter as IHavePassword).SecurePassword.Unsecure()
				};

				if (string.IsNullOrEmpty(loginCredentials.Surname))
				{
					await IoC.UI.ShowMessage(new MessageBoxDialogViewModel
					{
						Title = "Empty usernmae",
						Message = "The current username is invalid or empty"
					});

					return;
				}

				if (await IoC.DataStore.LoginAsync(loginCredentials) == false)
				{
					await IoC.UI.ShowMessage(new MessageBoxDialogViewModel
					{
						Title = "Empty password",
						Message = "The current password is invalid or empty"
					});

					return;
				}

				IoC.Application.GoToPage(ApplicationPage.MainMenu);
			});
		}
	}
}