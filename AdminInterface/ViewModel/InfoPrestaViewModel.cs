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
    class InfoPrestaViewModel : ViewModelBase, INotifyPropertyChanged
    {
        //public Window MainWindow;
        private Prestataire prestataire;
        private CoordonneeP coordonneeP;

        private Voiture voiture;
        //public int id { get; set; }
        public Prestataire Prestataire { get => prestataire; set { prestataire = value; RaisePropertyChanged("Prestataire"); } }

        public int Id { get => prestataire.Id; set { prestataire.Id = value; RaisePropertyChanged("Id"); } }



        public Dispo Disponibilite
        {
            get => prestataire.Disponibilite;
            set { prestataire.Disponibilite = value; RaisePropertyChanged("Disponibilite"); }
        }


        public string NumPermis { get => prestataire.NumPermis; set { prestataire.NumPermis = value; RaisePropertyChanged("NumPermis"); } }


        public string Assurance { get => prestataire.Assurance; set { prestataire.Assurance = value; RaisePropertyChanged("Assurance"); } }


        public string LienImage { get => prestataire.LienImage; set { prestataire.LienImage = value; RaisePropertyChanged("LienImage"); } }


        public string MdpCrypte { get => prestataire.MdpCrypte; set { prestataire.MdpCrypte = value; RaisePropertyChanged("MDPCrypte"); } }


        public DateTime DateInscription { get => prestataire.DateInscription; }


        public DateTime dateConnection { get => prestataire.dateConnection; set { prestataire.dateConnection = value; RaisePropertyChanged("dateConnection"); } }


        public CoordonneeP CoordonneeP { get => coordonneeP; set { coordonneeP = value; RaisePropertyChanged("CoordonneeP"); } }

        public string Mail { get => coordonneeP.Mail; set { coordonneeP.Mail = value; RaisePropertyChanged("Mail"); } }


        public string Nom { get => coordonneeP.Nom; set { coordonneeP.Nom = value; RaisePropertyChanged("Nom"); } }


        public string Prenom { get => coordonneeP.Prenom; set { coordonneeP.Prenom = value; RaisePropertyChanged("Prenom"); } }


        public string TelephoneFixe { get => coordonneeP.TelephoneFixe; set { coordonneeP.TelephoneFixe = value; RaisePropertyChanged("TelephoneFixe"); } }


        public string TelephonePortable { get => coordonneeP.TelephonePortable; set { coordonneeP.TelephonePortable = value; RaisePropertyChanged("TelephonePortable"); } }

        public string Rue { get => coordonneeP.Rue; set { coordonneeP.Rue = value; RaisePropertyChanged("Rue"); } }


        public String CodePostal { get => coordonneeP.CodePostal; set { coordonneeP.CodePostal = value; RaisePropertyChanged("CodePostal"); } }


        public Voiture Voiture { get => voiture; set { voiture = value; RaisePropertyChanged("Voiture"); } }

        public string Marque { get => voiture.Marque; set { voiture.Marque = value; RaisePropertyChanged("Marque"); } }


        public string modele { get => voiture.modele; set { voiture.modele = value; RaisePropertyChanged("modele"); } }


        public string Immatriculation { get => voiture.Immatriculation; set { voiture.Immatriculation = value; RaisePropertyChanged("Immatriculation"); } }


        public int Nb_Place { get => voiture.Nb_Place; set { voiture.Nb_Place = value; RaisePropertyChanged("Nb_Place"); } }

        

        public InfoPrestaViewModel()
        {
            prestataire = new Prestataire();
            coordonneeP = new CoordonneeP();
            voiture  = new Voiture();

            

        }
        public void debug_test()
        {

        }
        public void initPrestaViewModel(int id)
        {
            
            if (id != 0)
            {

                Task t = Task.Run(() => PrestataireFromAPI(id));
                
                t.Wait();
                coordonneeP = prestataire.Coordonnee;
                voiture = prestataire.Voiture;
          
                
            }

        }

        public async Task<Prestataire> PrestataireFromAPI(int id)
        {
            
            Prestataire prestataire = new Prestataire();
            HttpClient Rqlistpresta = new HttpClient();
            Rqlistpresta.BaseAddress = new Uri("http://localhost:52467/");
            Rqlistpresta.DefaultRequestHeaders.Accept.Clear();
            Rqlistpresta.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage reponseAPI = await Rqlistpresta.GetAsync("api/Prestataires1/" + id);
            if (reponseAPI.IsSuccessStatusCode)
            {
                Prestataire = await reponseAPI.Content.ReadAsAsync<Prestataire>();
                prestataire = Prestataire;
            }
            return prestataire;
        }

    }
}
