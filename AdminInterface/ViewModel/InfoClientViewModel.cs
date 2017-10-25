using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminInterface.Class;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows;
using System.Windows.Threading;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows.Input;



namespace AdminInterface.ViewModel
{
    class InfoClientViewModel : ViewModelBase
    {
        private Client client;
        private CoordonneeC coordonneeC;
       
        public RelayCommand<Client> CommandSaveInfoClients { get; }

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

        public string Ville { get => coordonneeC.Ville;set { coordonneeC.Ville = value; RaisePropertyChanged("VilleC"); }  }

        public String CodePostal { get => coordonneeC.CodePostal; set { coordonneeC.CodePostal = value; RaisePropertyChanged("CodePostalC"); } }

        


       
        public InfoClientViewModel()
        {
            client = new Client();
            coordonneeC = new CoordonneeC();
            CommandSaveInfoClients = new RelayCommand<Client>(commandeAExectuer);
        }
        public void commandeAExectuer(Client c)
        {
            c = Client;
            Task t = Task.Run(() => ClientUpdateAPI(Id, c));

            t.Wait();

        }

        public void debug_test()
        {

        }
        public void initClientViewModel(int id)
        {

            if (id != 0)
            {

                Task t = Task.Run(() => ClientFromAPI(id));

                t.Wait();
                coordonneeC = client.Coordonnee;
                


            }

        }


        public async Task<Client> ClientFromAPI(int id)
        {

            Client client = new Client();
            HttpClient Rqlistclient = new HttpClient();
            Rqlistclient.BaseAddress = new Uri("http://localhost:52467/");
            Rqlistclient.DefaultRequestHeaders.Accept.Clear();
            Rqlistclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage reponseAPI = await Rqlistclient.GetAsync("api/Clients1/" + id);
            if (reponseAPI.IsSuccessStatusCode)
            {
                Client = await reponseAPI.Content.ReadAsAsync<Client>();
                client = Client;
            }
            return client;
        }
        
        public async Task<Client> ClientUpdateAPI(int id,Client c)
        {

            Client client = c;
            HttpClient Rqlistclient = new HttpClient();
            Rqlistclient.BaseAddress = new Uri("http://localhost:52467/");
            Rqlistclient.DefaultRequestHeaders.Accept.Clear();
            Rqlistclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


            HttpResponseMessage reponseAPI = await Rqlistclient.PutAsJsonAsync(Rqlistclient.BaseAddress + "api/Clients1/"+id, client);

            //HttpResponseMessage reponseAPI = await Rqlistclient.PutAsync("api/Clients1/" + client);
            if (reponseAPI.IsSuccessStatusCode)
            {
                MessageBox.Show("Tranfert ok");
            }
            else
            {
                MessageBox.Show("Tranfert pas ok");
            }
            return client;
        }



    }
    
}
