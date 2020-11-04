using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using AIS_Airoport.Core;

namespace AIS_Airoport.Relational
{
    /// <summary>
    /// Stores and retrieves information about the client application 
    /// such as login credentials and so on
    /// in an SQLite database
    /// </summary>
    public class DataStore : IDataStore
    {
        #region Protected Members

        /// <summary>
        /// The database context for the client data store
        /// </summary>
        protected DataStoreDbContext mDbContext;

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="dbContext">The database to use</param>
        public DataStore(DataStoreDbContext dbContext)
        {
            // Set local member
            mDbContext = dbContext;
        }

        #endregion

        #region Interface Implementation

        /// <summary>
        /// Logs into the application
        /// </summary>
        /// <param name="loginCredentialsApiModel">The credentials for an client to log into the application</param>
        public async Task<bool> LoginAsync(LoginCredentialsApiModel loginCredentialsApiModel)
        {
            return await Task.FromResult(mDbContext.Staff.FirstOrDefault((item) => item.Surname == loginCredentialsApiModel.Surname
            && item.Password == loginCredentialsApiModel.Password) != null);
        }

        /// <summary>
        /// Makes sure the data store is correctly set up
        /// </summary>
        /// <returns>Returns a task that will finish once setup is complete</returns>
        public async Task EnsureDataStoreAsync()
        {
            // Make sure the database exists and is created
            await mDbContext.Database.EnsureCreatedAsync();
        }

        /// <summary>
        /// Gets the stored login credentials for this client
        /// </summary>
        /// <returns>Returns the login credentials if they exist, or null if none exist</returns>
        public Task<EmployeeCredentials> GetEmployeeCredentialsAsync(string surname)
        {
            // Get the first column in the login credentials table, or null if none exist
            return Task.FromResult(mDbContext.Staff.FirstOrDefault((item) => item.Surname == surname));
        }

        /// <summary>
        /// Stores the given login credentials to the backing data store
        /// </summary>
        /// <param name="loginCredentials">The login credentials to save</param>
        /// <returns>Returns a task that will finish once the save is complete</returns>
        public async Task SaveLoginCredentialsAsync(EmployeeCredentials loginCredentials)
        {
            // Clear all entries
            mDbContext.Staff.RemoveRange(mDbContext.Staff);

            // Add new one
            mDbContext.Staff.Add(loginCredentials);

            // Save changes
            await mDbContext.SaveChangesAsync();
        }

        #endregion
    }
}