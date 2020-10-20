using AIS_Airoport.Core;

namespace AIS_Airoport
{
    /// <summary>
    /// Interaction logic for TicketSellingPage.xaml
    /// </summary>
    public partial class TicketSellingPage : BasePage<TicketSellingViewModel>
    {
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public TicketSellingPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor with specific view model
        /// </summary>
        /// <param name="specificViewModel">The specific view model to use for this page</param>
        public TicketSellingPage(TicketSellingViewModel specificViewModel = null) : base(specificViewModel)
        {
            InitializeComponent();
        }

        #endregion
    }
}