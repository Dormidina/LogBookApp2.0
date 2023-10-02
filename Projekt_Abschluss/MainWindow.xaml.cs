using Projekt_Abschluss.Views;
using System.Windows;

namespace Projekt_Abschluss
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainGrid.Children.Add(new LoggingView(this));                      
        }

        public void LoggingSuccess()
        {

            MainGrid.Children.Clear();
            MainGrid.Children.Add(new GeneralView());
            this.WindowState = WindowState.Maximized;
        }
    }
}
