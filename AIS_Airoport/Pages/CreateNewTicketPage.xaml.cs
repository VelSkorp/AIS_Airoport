using AIS_Airoport.Core;

namespace AIS_Airoport
{
    /// <summary>
    /// Interaction logic for CreateNewTicketPage.xaml
    /// </summary>
    public partial class CreateNewTicketPage : BasePage<CreateNewTicketViewModel>
    {
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public CreateNewTicketPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor with specific view model
        /// </summary>
        /// <param name="specificViewModel">The specific view model to use for this page</param>
        public CreateNewTicketPage(CreateNewTicketViewModel specificViewModel = null) : base(specificViewModel)
        {
            InitializeComponent();
        }

        #endregion
    }
}