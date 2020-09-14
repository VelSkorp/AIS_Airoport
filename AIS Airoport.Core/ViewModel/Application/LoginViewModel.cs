using System;
using System.Security;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AIS_Airoport.Core
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
                // TODO: Fake a loginll...
                await Task.Delay(1000);

                // Ok successfully loggedin... Now det users data
                // TODO: Ask server for users info

                // TODO: Remove this with real information pulled from our database in future
                //IoC.Settings.Name = new TextEntryViewModel { Label = "Name", OriginalText = $"Vlad Kontsevich {DateTime.Now}" };
                //IoC.Settings.UserName = new TextEntryViewModel { Label = "UserName", OriginalText = "Vald" };
                //IoC.Settings.Password = new PasswordEntryViewModel { Label = "Password", FakePassword = "*********" };
                //IoC.Settings.Email = new TextEntryViewModel { Label = "Email", OriginalText = "kontsevichv@mail.ru" };

                // Go to chat page
                //IoC.Application.GoToPage(ApplicationPage.Chat);

                //var email = Email;

                //// IMPORTANT: Never store unsecure password in variable like this
                //var pass = (parameter as IHavePassword).SecurePassword.Unsecure();
            });
        }
    }
}