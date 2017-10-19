using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using GalaSoft.MvvmLight;
using AdminInterface.Class;

namespace AdminInterface.ViewModel
{
    class ClientViewModel : ViewModelBase
    {
        private ObservableCollection<Client> listeClient;

        public ObservableCollection<Client> ListeClient
        {
            get => listeClient;
            set { listeClient = value; RaisePropertyChanged("ListeClient"); }
        }

        public ClientViewModel()
        {
            if (!DesignerProperties.GetIsInDesignMode(Application.Current.MainWindow)) //pour éviter les plantages du designer...
            {
                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(PopulateListeClientFromAPI));
            }
        }

        public async void PopulateListeClientFromAPI()
        {
            IEnumerable<Client> tempListClient;
            HttpClient clientForClientIndex = new HttpClient();
            clientForClientIndex.BaseAddress = new Uri("http://localhost:52467/");
            clientForClientIndex.DefaultRequestHeaders.Accept.Clear();
            clientForClientIndex.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //clientForClientIndex.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["token"].ToString());
            HttpResponseMessage reponseAPI = await clientForClientIndex.GetAsync("api/Clients");
            if (reponseAPI.IsSuccessStatusCode)
            {
                tempListClient = await reponseAPI.Content.ReadAsAsync<IEnumerable<Client>>();
                ListeClient = new ObservableCollection<Client>(tempListClient);
            }
        }

    }
}

