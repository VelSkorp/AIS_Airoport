using AIS_Airport.Core;

namespace AIS_Airport
{
	/// <summary>
	/// Interaction logic for AddNewPassengerPage.xaml
	/// </summary>
	public partial class AddOrUpdatePassengerPage : BasePage<AddOrUpdatePassengerViewModel>
	{
		#region Constructors

		/// <summary>
		/// Default constructor
		/// </summary>
		public AddOrUpdatePassengerPage()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Constructor with specific view model
		/// </summary>
		/// <param name="specificViewModel">The specific view model to use for this page</param>
		public AddOrUpdatePassengerPage(AddOrUpdatePassengerViewModel specificViewModel = null) : base(specificViewModel)
		{
			InitializeComponent();
		}

		#endregion
	}
}