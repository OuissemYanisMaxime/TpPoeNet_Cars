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
    /// Logique d'interaction pour InfoClient.xaml
    /// </summary>
    public partial class InfoClient : Window
    {
        static InfoClientViewModel icvm;
        public InfoClient()
        {
            InitializeComponent();
        }
        public InfoClient(int id) : this()
        {
            
            (DataContext as InfoClientViewModel).Id = id;
            icvm = new InfoClientViewModel();
            icvm.initClientViewModel(id);
            icvm.debug_test();
            DataContext = icvm;


        }
    }
}
