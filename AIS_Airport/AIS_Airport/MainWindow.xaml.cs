using System.Windows;

namespace AIS_Airport
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		/// <summary>
		/// Interaction logic for MainWindow.xaml
		/// </summary>
		public MainWindow()
		{
			InitializeComponent();

			DataContext = new WindowViewModel(this);
		}

		private void AppWindow_Deactivated(object sender, EventArgs e)
		{
			// TODO: Try to get this out from code-behind
			// Show overlay if we lose focus
			(DataContext as WindowViewModel).DimmableOverlayVisible = true;
		}

		private void AppWindow_Activated(object sender, EventArgs e)
		{
			// Hide overlay if we are focused
			(DataContext as WindowViewModel).DimmableOverlayVisible = false;
		}
	}
}