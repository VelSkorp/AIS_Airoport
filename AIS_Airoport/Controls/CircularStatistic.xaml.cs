using System.Windows;
using System.Windows.Controls;

namespace AIS_Airoport
{
    /// <summary>
    /// Логика взаимодействия для CircularStatistic.xaml
    /// </summary>
    public partial class CircularStatistic : UserControl
    {
        #region Dependency Properties

        /// <summary>
        /// The text to show in table header
        /// </summary>
        public string Text
        {
            get => GetValue(TextProperty).ToString();
            set => SetValue(TextProperty, value.ToString());
        }

        /// <summary>
        /// Registers text dependency property
        /// </summary>
        public static readonly DependencyProperty TextProperty =
         DependencyProperty.Register("Text", typeof(string), typeof(CircularStatistic));

        /// <summary>
        /// The command to refresh data in table and in chart
        /// </summary>
        public object RefreshCommand
        {
            get => GetValue(RefreshCommandProperty);
            set => SetValue(RefreshCommandProperty, value);
        }

        /// <summary>
        /// Registers refresh command dependency property
        /// </summary>
        public static readonly DependencyProperty RefreshCommandProperty =
         DependencyProperty.Register("RefreshCommand", typeof(object), typeof(CircularStatistic));

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public CircularStatistic()
        {
            InitializeComponent();
        }

        #endregion
    }
}