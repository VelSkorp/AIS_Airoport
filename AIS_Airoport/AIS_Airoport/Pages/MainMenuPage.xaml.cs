using AIS_Airport.Core;

namespace AIS_Airport
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class MainMenuPage : BasePage<MainMenuViewModel>
    {
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public MainMenuPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor with specific view model
        /// </summary>
        /// <param name="specificViewModel">The specific view model to use for this page</param>
        public MainMenuPage(MainMenuViewModel specificViewModel)
            : base(specificViewModel)
        {
            InitializeComponent();
        }

        #endregion
    }
}