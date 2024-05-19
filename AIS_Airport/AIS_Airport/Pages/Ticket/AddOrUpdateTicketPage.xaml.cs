using AIS_Airport.Core;

namespace AIS_Airport
{
	/// <summary>
	/// Interaction logic for CreateNewTicketPage.xaml
	/// </summary>
	public partial class AddOrUpdateTicketPage : BasePage<AddOrUpdateTicketViewModel>
	{
		#region Constructors

		/// <summary>
		/// Default constructor
		/// </summary>
		public AddOrUpdateTicketPage()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Constructor with specific view model
		/// </summary>
		/// <param name="specificViewModel">The specific view model to use for this page</param>
		public AddOrUpdateTicketPage(AddOrUpdateTicketViewModel specificViewModel = null) : base(specificViewModel)
		{
			InitializeComponent();
		}

		#endregion
	}
}