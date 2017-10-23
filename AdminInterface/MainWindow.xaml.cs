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
using AdminInterface.Class;
using AdminInterface.ViewModel;

namespace AdminInterface
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            
            
        }

        private void Btn_detail_Click(object sender, RoutedEventArgs e)
        {
            PrestataireViewModel pvm = new PrestataireViewModel();

            int id = pvm.convert_id_id(ListPresta.SelectedIndex);
            
            InfoPresta InfoWindow = new InfoPresta(id);
            //InfoPresta InfoWindow = new InfoPresta();
            InfoWindow.Show();
        }

        
    }
}

