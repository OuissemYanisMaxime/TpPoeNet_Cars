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
    /// Logique d'interaction pour ListingPrestataire.xaml
    /// </summary>
    public partial class ListingPrestataire : Window
    {
        public ListingPrestataire()
        {
            InitializeComponent();
        }

        private void Btn_detail_Click(object sender, RoutedEventArgs e)
        {
            PrestataireViewModel pvm = new PrestataireViewModel();
            Prestataire p = new Prestataire();
            if (ListPresta.SelectedIndex != -1)
            {


                //p = pvm.convert_id_to_presta(ListPresta.SelectedIndex);
                //InfoPresta InfoWindow = new InfoPresta(p);
                int id = pvm.convert_id_id(ListPresta.SelectedIndex);
                InfoPresta InfoWindow = new InfoPresta(id);

                InfoWindow.Show();
            }
        }
    }
}
