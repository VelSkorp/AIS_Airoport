using AIS_Airoport.Core;

namespace AIS_Airoport
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
        public MainMenuPage(MainMenuViewModel specificViewModel = null) : base(specificViewModel)
        {
            InitializeComponent();
        }

        #endregion
    }
}