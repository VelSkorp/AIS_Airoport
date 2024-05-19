using AIS_Airport.Core;

namespace AIS_Airport
{
	/// <summary>
	/// Interaction logic for AddNewFlightPage.xaml
	/// </summary>
	public partial class AddNewFlightPage : BasePage<AddNewFlightViewModel>
	{
		#region Constructors

		/// <summary>
		/// Default constructor
		/// </summary>
		public AddNewFlightPage()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Constructor with specific view model
		/// </summary>
		/// <param name="specificViewModel">The specific view model to use for this page</param>
		public AddNewFlightPage(AddNewFlightViewModel specificViewModel = null) : base(specificViewModel)
		{
			InitializeComponent();
		}

		#endregion
	}
}