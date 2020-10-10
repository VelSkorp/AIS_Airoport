using System.Windows;
using System.Windows.Controls;

namespace AIS_Airoport
{
    /// <summary>
    /// Логика взаимодействия для Statistic.xaml
    /// </summary>
    public partial class Statistic : UserControl
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
         DependencyProperty.Register("Text", typeof(string), typeof(Statistic));

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public Statistic()
        {
            InitializeComponent();
        }

        #endregion
    }
}