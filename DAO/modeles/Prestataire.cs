using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.modeles
{
    public enum Dispo { Dispo,Occupe,HS}
    public class Prestataire
    {

        [Key]
        public int Id { get; set; }
        public int IdCoordonnee { get; set; }
        public int IdVoiture { get; set; }
        public Dispo Disponibilite { get; set; }
        public string NumPermis { get; set; }
        public string Assurance { get; set; }
        public string LienImage { get; set; }
        public string MdpCrypte { get; set; }
        public string dateConnection { get; set; }

        [ForeignKey("IdCoordonnee")]
        public virtual Coordonnee Coordonnee { get; set; }
        [ForeignKey("IdVoiture")]
        public virtual Voiture Voiture { get; set; }

        public virtual ICollection<Prestation> Prestations { get; set; }
    }
}


