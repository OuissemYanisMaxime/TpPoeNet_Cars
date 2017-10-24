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

        

        private void Btn_ListPresta_Click(object sender, RoutedEventArgs e)
        {
            ListingPrestataire w = new ListingPrestataire();
            w.Show();
        }

        private void Btn_ListClient_Click(object sender, RoutedEventArgs e)
        {
            ListingClient w = new ListingClient();
            w.Show();
        }

        private void Btn_ListPrestation_Click(object sender, RoutedEventArgs e)
        {

        }


    }
}

