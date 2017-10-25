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
using System.Windows.Input;

namespace AdminInterface.ViewModel
{
    class ClientViewModel : ViewModelBase
    {
        private Client client;
        private CoordonneeC coordonneeC;
        public ICommand CommandInfoClients { get; }

        public Client Client { get => client; set { client = value; RaisePropertyChanged("Client"); } }

        public int Id { get => client.Id; set { client.Id = value; RaisePropertyChanged("Id"); } }


        public string LienImage { get => client.LienImage; set { client.LienImage = value; RaisePropertyChanged("LienImage"); } }



        public DateTime DateInscription { get => client.DateInscription; }


        public DateTime dateConnection { get => client.DateConnection; set { client.DateConnection = value; RaisePropertyChanged("dateConnection"); } }


        public CoordonneeC CoordonneeC { get => coordonneeC; set { coordonneeC = value; RaisePropertyChanged("CoordonneeC"); } }

        public string Mail { get => coordonneeC.Mail; set { coordonneeC.Mail = value; RaisePropertyChanged("MailC"); } }


        public string Nom { get => coordonneeC.Nom; set { coordonneeC.Nom = value; RaisePropertyChanged("NomC"); } }


        public string Prenom { get => coordonneeC.Prenom; set { coordonneeC.Prenom = value; RaisePropertyChanged("PrenomC"); } }


        public string TelephoneFixe { get => coordonneeC.TelephoneFixe; set { coordonneeC.TelephoneFixe = value; RaisePropertyChanged("TelephoneFixeC"); } }


        public string TelephonePortable { get => coordonneeC.TelephonePortable; set { coordonneeC.TelephonePortable = value; RaisePropertyChanged("TelephonePortableC"); } }

        public string Rue { get => coordonneeC.Rue; set { coordonneeC.Rue = value; RaisePropertyChanged("RueC"); } }


        public String CodePostal { get => coordonneeC.CodePostal; set { coordonneeC.CodePostal = value; RaisePropertyChanged("CodePostalC"); } }

        private ObservableCollection<Client> mesClients;
        public ObservableCollection<Client> MesClients { get => mesClients; set { mesClients = value; RaisePropertyChanged("MesClients"); } }



        public ClientViewModel()
        {
            client = new Client();
            coordonneeC = new CoordonneeC();
            mesClients = new ObservableCollection<Client>();
            



            Task t = Task.Run(() => PopulateListeClientFromAPI());

            t.Wait();


        }
        public int convert_id_id(int id)
        {
            int res = -1;

            res = mesClients[id].Id;

            return res;
        }



        public Client convert_id_to_client(int id)
        {


            client = mesClients[id];

            return client;
        }

        public async Task<ObservableCollection<Client>> PopulateListeClientFromAPI()
        {
            IEnumerable<Client> tempListClient;
            HttpClient Rqlistclient = new HttpClient();
            Rqlistclient.BaseAddress = new Uri("http://localhost:52467/");
            Rqlistclient.DefaultRequestHeaders.Accept.Clear();
            Rqlistclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage reponseAPI = await Rqlistclient.GetAsync("api/Clients1");
            if (reponseAPI.IsSuccessStatusCode)
            {
                tempListClient = await reponseAPI.Content.ReadAsAsync<IEnumerable<Client>>();
                mesClients = new ObservableCollection<Client>(tempListClient);
            }
            return mesClients;
        }




    }
}

