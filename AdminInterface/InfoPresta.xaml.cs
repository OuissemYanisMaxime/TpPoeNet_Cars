﻿using System;
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
    /// Logique d'interaction pour InfoPresta.xaml
    /// </summary>
    public partial class InfoPresta : Window
    {
        public InfoPresta()
        {
            InitializeComponent();
        }
        public InfoPresta(int id) : this()
        {
            
            (DataContext as InfoPrestaViewModel).Id = id;

            InfoPrestaViewModel ipvm = new InfoPrestaViewModel();
            ipvm.initPrestaViewModel(id);
            
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
