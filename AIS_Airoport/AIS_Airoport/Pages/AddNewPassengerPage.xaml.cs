using AIS_Airport.Core;

namespace AIS_Airport
{
	/// <summary>
	/// Interaction logic for AddNewPassengerPage.xaml
	/// </summary>
	public partial class AddNewPassengerPage : BasePage<AddNewPassengerViewModel>
	{
		#region Constructors

		/// <summary>
		/// Default constructor
		/// </summary>
		public AddNewPassengerPage()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Constructor with specific view model
		/// </summary>
		/// <param name="specificViewModel">The specific view model to use for this page</param>
		public AddNewPassengerPage(AddNewPassengerViewModel specificViewModel = null) : base(specificViewModel)
		{
			InitializeComponent();
		}

		#endregion
	}
}