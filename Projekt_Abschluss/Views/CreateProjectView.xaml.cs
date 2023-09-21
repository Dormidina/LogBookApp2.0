using Projekt_Abschluss.Models;
using Projekt_Abschluss.Repositories;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Projekt_Abschluss.Views
{
    
    public partial class CreateProjectView : UserControl
    {
        public CreateProjectView()
        {
            InitializeComponent();
        }

        private async void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            
            ProjectModel model = new ProjectModel
            {
                Name = NameProject.Text,
                Description = DescriptionProject.Text,
                Company = CompanyProject.Text
            };

            ProjectRepository projectRepository = new ProjectRepository();
            await projectRepository.CreateAsync(model);
            CancelButton_Click(sender, e);


        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);

            parentWindow?.Close();
        }
    }
}
