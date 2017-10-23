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
    class PrestataireViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public Window MainWindow;
        private Prestataire prestataire;
        private CoordonneeP coordonneeP;
        public ICommand CommandInfoPrestataire { get; }

        public Prestataire Prestataire { get => prestataire; set { prestataire = value; RaisePropertyChanged("Prestataire"); } }

        public int Id { get => prestataire.Id; set { prestataire.Id = value; RaisePropertyChanged("Id"); } }



        public Dispo Disponibilite {
            get => prestataire.Disponibilite;
            set { prestataire.Disponibilite = value; RaisePropertyChanged("Disponibilite"); } }


        public string NumPermis { get => prestataire.NumPermis; set { prestataire.NumPermis = value; RaisePropertyChanged("NumPermis"); } }


        public string Assurance { get => prestataire.Assurance; set { prestataire.Assurance = value; RaisePropertyChanged("Assurance"); } }


        public string LienImage { get => prestataire.LienImage; set { prestataire.LienImage = value; RaisePropertyChanged("LienImage"); } }


        public string MdpCrypte { get => prestataire.MdpCrypte; set { prestataire.MdpCrypte = value; RaisePropertyChanged("MDPCrypte"); } }


        public DateTime DateInscription { get => prestataire.DateInscription;  }


        public DateTime dateConnection { get => prestataire.dateConnection; set { prestataire.dateConnection = value; RaisePropertyChanged("dateConnection"); } }


        public CoordonneeP CoordonneeP { get => coordonneeP; set { coordonneeP = value; RaisePropertyChanged("CoordonneeP"); } }

        public string Mail { get => coordonneeP.Mail; set { coordonneeP.Mail = value; RaisePropertyChanged("MailP"); } }


        public string Nom { get => coordonneeP.Nom; set { coordonneeP.Nom = value; RaisePropertyChanged("NomP"); } }


        public string Prenom { get => coordonneeP.Prenom; set { coordonneeP.Prenom = value; RaisePropertyChanged("PrenomP"); } }


        public string TelephoneFixe { get => coordonneeP.TelephoneFixe; set { coordonneeP.TelephoneFixe = value; RaisePropertyChanged("TelephoneFixeP"); } }


        public string TelephonePortable { get => coordonneeP.TelephonePortable; set { coordonneeP.TelephonePortable = value; RaisePropertyChanged("TelephonePortableP"); } }

        public string Rue { get => coordonneeP.Rue; set { coordonneeP.Rue = value; RaisePropertyChanged("RueP"); } }


        public String CodePostal { get => coordonneeP.CodePostal; set { coordonneeP.CodePostal = value; RaisePropertyChanged("CodePostalP"); } }


        public Voiture Voiture { get => Voiture; set { Voiture = value; RaisePropertyChanged("Voiture"); } }

        public string Marque { get => Voiture.Marque; set { Voiture.Marque = value; RaisePropertyChanged("Marque"); } }


        public string modele { get => Voiture.modele; set { Voiture.modele = value; RaisePropertyChanged("modele"); } }


        public string Immatriculation { get => Voiture.Immatriculation; set { Voiture.Immatriculation = value; RaisePropertyChanged("Immatriculation"); } }


        public int Nb_Place { get => Voiture.Nb_Place; set { Voiture.Nb_Place = value; RaisePropertyChanged("Nb_Place"); } }


        private ObservableCollection<Prestataire> mesPrestataire; 
        public ObservableCollection<Prestataire> MesPrestataire { get => mesPrestataire; set { mesPrestataire = value; RaisePropertyChanged("MesPrestataire"); } }

        

        public PrestataireViewModel()
        {
            prestataire = new Prestataire();
            coordonneeP = new CoordonneeP();
            mesPrestataire = new ObservableCollection<Prestataire>();
            CommandInfoPrestataire = new RelayCommand(InfoduPrestataire);
           


            Task t = Task.Run(() => PopulateListePrestataireFromAPI());

            t.Wait();

 
        }

        public async Task<ObservableCollection<Prestataire>> PopulateListePrestataireFromAPI()
        {
            IEnumerable<Prestataire> tempListPrestataire;
            HttpClient Rqlistpresta = new HttpClient();
            Rqlistpresta.BaseAddress = new Uri("http://localhost:52467/");
            Rqlistpresta.DefaultRequestHeaders.Accept.Clear();
            Rqlistpresta.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage reponseAPI = await Rqlistpresta.GetAsync("api/Prestataires1");
            if (reponseAPI.IsSuccessStatusCode)
            {
                tempListPrestataire = await reponseAPI.Content.ReadAsAsync<IEnumerable<Prestataire>>();
                mesPrestataire = new ObservableCollection<Prestataire>(tempListPrestataire);
            }
            return mesPrestataire;
        }
         
        


     public int convert_id_id(int id)
        {
            int res = -1;

            res = mesPrestataire[id].Id;

            return res;
        }

        public void InfoduPrestataire()
        {
            
            //InfoPresta InfoWindow = new InfoPresta(id);
            ////InfoPresta InfoWindow = new InfoPresta();
            //InfoWindow.Show();
        }


    }
}
