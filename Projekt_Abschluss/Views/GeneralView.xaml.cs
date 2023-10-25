using Projekt_Abschluss.Helpers;
using Projekt_Abschluss.Models;
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
    public partial class GeneralView : UserControl
    {
        public GeneralView()
        {
            InitializeComponent();

            if (LogInHelper.Session.IsAdmin == false)
            {
                UsersTab.Visibility = Visibility.Collapsed;

            }
            
            
            
        }       
    }
}
