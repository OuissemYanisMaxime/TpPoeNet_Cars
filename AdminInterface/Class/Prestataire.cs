using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminInterface.Class
{
    public enum Dispo { Dispo, Occupe, HS }
    public class Prestataire
    {

        
        public int Id { get; set; }
        
        public int IdCoordonnee { get; set; }

       
        public int IdVoiture { get; set; }

       
        public Dispo Disponibilite { get; set; }

        
        public string NumPermis { get; set; }

        
        public string Assurance { get; set; }

        
        public string LienImage { get; set; }

       
        public string MdpCrypte { get; set; }

        
        public DateTime DateInscription { get; set; }
                
        
        public DateTime dateConnection { get; set; }

        
        public CoordonneeP Coordonnee { get; set; }

        
        public Voiture Voiture { get; set; }

        public virtual ICollection<Prestation> Prestations { get; set; }

        public Prestataire()
        {
            this.Disponibilite = Dispo.HS;
            //this.DateInscription = DateTime.Now;
        }
    }
}


