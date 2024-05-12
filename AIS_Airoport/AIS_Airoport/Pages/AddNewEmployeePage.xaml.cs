using AIS_Airport.Core;

namespace AIS_Airport
{
    /// <summary>
    /// Interaction logic for AddNewEmployeePage.xaml
    /// </summary>
    public partial class AddNewEmployeePage : BasePage<AddNewEmployeeViewModel>
    {
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public AddNewEmployeePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor with specific view model
        /// </summary>
        /// <param name="specificViewModel">The specific view model to use for this page</param>
        public AddNewEmployeePage(AddNewEmployeeViewModel specificViewModel = null) : base(specificViewModel)
        {
            InitializeComponent();
        }

        #endregion
    }
}