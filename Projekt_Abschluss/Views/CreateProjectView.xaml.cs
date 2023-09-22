using Projekt_Abschluss.Models;
using Projekt_Abschluss.Repositories;
using System.Configuration;
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
            GetAllCompanies();
        }

        private async void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ProjectModel model = new ProjectModel
                {
                    Name = NameProject.Text,
                    Description = DescriptionProject.Text,
                    Company_ID = int.Parse(CompanyProject.SelectedValue.ToString())
                };

                ProjectRepository projectRepository = new ProjectRepository();
                var created = await projectRepository.CreateAsync(model);
                if (created)
                {
                    MessageBox.Show("Project created sucessfully");
                    CancelButton_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Error creating Project");
                }
            }
            catch
            {
                MessageBox.Show("Please select a company");
            }
            

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);

            parentWindow?.Close();
        }
        private async void GetAllCompanies()
        {
            CompanyRepository companyRepository = new CompanyRepository();
            var companies = await companyRepository.GetAllCompaniesAsync();
            CompanyProject.ItemsSource = companies;
        }
    }
}
