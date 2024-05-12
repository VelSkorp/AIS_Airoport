using AIS_Airport.Core;

namespace AIS_Airport
{
    /// <summary>
    /// Interaction logic for FlightListPage.xaml
    /// </summary>
    public partial class FlightListPage : BasePage<FlightListViewModel>
    {
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public FlightListPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor with specific view model
        /// </summary>
        /// <param name="specificViewModel">The specific view model to use for this page</param>
        public FlightListPage(FlightListViewModel specificViewModel = null) : base(specificViewModel)
        {
            InitializeComponent();
        }

        #endregion
    }
}