using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.modeles
{
    public enum Dispo { Dispo, Occupe, HS }
    public class Prestataire
    {

        

        [Key]
        public int Id { get; set; }
        
        public int IdCoordonnee { get; set; }

        [Display(Name = "Voiture : ")]
        public int IdVoiture { get; set; }

        [Display(Name = "Disponibilité : ")]        
        public Dispo Disponibilite { get; set; }

        [Display(Name = "Numéro du permis : ")]
        [Required(ErrorMessage = " obligatoire.")]
        public string NumPermis { get; set; }

        [Display(Name = "Numéro d'assurance : ")]
        [Required(ErrorMessage = " obligatoire.")]
        public string Assurance { get; set; }

        [Display(Name = "Image de profil : ")]
        [Required(ErrorMessage = " obligatoire.")]
        public string LienImage { get; set; }

        //[Display(Name = "Mot de passe : ")]
        //[Required(ErrorMessage = " obligatoire.")]
        //public string MdpCrypte { get; set; }

        [Display(Name = "Date d'inscription : ")]
        [DataType(DataType.DateTime)]
        public DateTime DateInscription { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime dateConnection { get; set; }

        [ForeignKey("IdCoordonnee")]
        public CoordonneeP Coordonnee { get; set; }

        [ForeignKey("IdVoiture")]
        public Voiture Voiture { get; set; }
        

        //public virtual ICollection<Prestation> Prestations { get; set; }

        public Prestataire()
        {
            this.Disponibilite = Dispo.HS;
            this.DateInscription = DateTime.Now;
        }
    }
}


