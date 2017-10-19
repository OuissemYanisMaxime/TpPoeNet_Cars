using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminInterface.Class
{
    public enum Status { EnAttente , EnCours, Fini }
    public class Prestation
    {
        
        public int Id { get; set; }

        
    
        public int IdPrestataire { get; set; }

        
       
        public int IdClient { get; set; }

        //Adresse départ
        
        public string RueDep { get; set; }

        
        public string CodePostalDep { get; set; }

        
        public string VilleDep { get; set; }

        //Adresse arrivée
       
        public string RueArr { get; set; }

        
        public string CodePostalArr { get; set; }

        
        public string VilleArr { get; set; }

        
        public DateTime HorairesDebut { get; set; }

        
        public DateTime HorairesFin { get; set; }

        
        public decimal Prix { get; set; }

        
        public decimal Salaire_presta { get; set; }

       
        public int Note { get; set; }

        
        public string Avis { get; set; }

        
        public Status Etat { get; set; }
        
        
        
        public virtual Client Client { get; set; }

        
        public virtual Prestataire Prestataire { get; set; }

        public Prestation()
        {
            this.Etat = Status.EnAttente;
        }
    }
}
