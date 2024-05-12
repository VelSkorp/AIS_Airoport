using System.Windows;

namespace AIS_Airport
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
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

		private void AppWindow_Deactivated(object sender, System.EventArgs e)
		{
			// TODO: попытаться вынести из кода позади
			// Show overlay if we lose focus
			(DataContext as WindowViewModel).DimmableOverlayVisible = true;
		}

		private void AppWindow_Activated(object sender, System.EventArgs e)
		{
			// Hide overlay if we are focused
			(DataContext as WindowViewModel).DimmableOverlayVisible = false;
		}
	}
}
