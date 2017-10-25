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
using System.Windows.Shapes;
using AdminInterface.ViewModel;
using AdminInterface.Class;

namespace AdminInterface
{
    /// <summary>
    /// Logique d'interaction pour ListingClient.xaml
    /// </summary>
    public partial class ListingClient : Window
    {
        public ListingClient()
        {
            InitializeComponent();
        }

        private void Btn_detail_Click(object sender, RoutedEventArgs e)
        {
            ClientViewModel cvm = new ClientViewModel();
            Client c = new Client();
            if (ListClient.SelectedIndex != -1)
            {


                //p = pvm.convert_id_to_presta(ListPresta.SelectedIndex);
                //InfoPresta InfoWindow = new InfoPresta(p);
                int id = cvm.convert_id_id(ListClient.SelectedIndex);
                InfoClient InfoWindow = new InfoClient(id);

                InfoWindow.Show();
            }
        }
    }
}
