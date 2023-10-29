using Projekt_Abschluss.Models;
using Projekt_Abschluss.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projekt_Abschluss.Views
{
    /// <summary>
    /// Lógica de interacción para CreateCompanyView.xaml
    /// </summary>
    public partial class CreateCompanyView : UserControl
    {
        public CreateCompanyView()
        {
            InitializeComponent();
        }

        private async void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {

            CompanyDataModel companyDataModel = new CompanyDataModel()
            {
                Name = CompanyName.Text,
                Adresse = CompanyAdresse.Text,
                ZipCode = CompanyZIP.Text,
                Telephone = CompanyTelephone.Text,
                Email = CompanyEmail.Text,
            };



            CompanyRepository companyRepository = new CompanyRepository();
            await companyRepository.CreateCompanyAsync(companyDataModel);

            CancelButton_Click(sender, e);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            parentWindow?.Close();
        }
    }
}
