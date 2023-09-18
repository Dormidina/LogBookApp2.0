using Projekt_Abschluss.Models;
using System.Windows;
using System.Windows.Controls;

namespace Projekt_Abschluss.Views
{
    /// <summary>
    /// Lógica de interacción para CreateProjectView.xaml
    /// </summary>
    public partial class CreateProjectView : UserControl
    {
        public CreateProjectView()
        {
            InitializeComponent();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            ProjectModel model = new ProjectModel
            {
                Name = NameProject.Text,
                Description = DescriptionProject.Text,
                Company = CompanyProject.Text
            };

        }
    }
}
