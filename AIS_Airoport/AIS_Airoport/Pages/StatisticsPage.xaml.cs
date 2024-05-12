using AIS_Airport.Core;

namespace AIS_Airport
{
    /// <summary>
    /// Interaction logic for StatisticsPage.xaml
    /// </summary>
    public partial class StatisticsPage : BasePage<StatisticsViewModel>
    {
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public StatisticsPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor with specific view model
        /// </summary>
        /// <param name="specificViewModel">The specific view model to use for this page</param>
        public StatisticsPage(StatisticsViewModel specificViewModel = null) : base(specificViewModel)
        {
            InitializeComponent();
        }

        #endregion
    }
}
