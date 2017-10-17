using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.modeles
{
    public enum Status { EnAttente , EnCours, Fini }
    public class Prestation
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Prestataire : ")]
    
        public int IdPrestataire { get; set; }

        [Display(Name = "Numéro client : ")]
       
        public int IdClient { get; set; }

        
        [Display(Name = "Rue de départ : ")]
        [Required(ErrorMessage = " obligatoire.")]
        public string RueDep { get; set; }

        [Display(Name = "Code postal ville de départ : ")]
        [Required(ErrorMessage = " obligatoire.")]
        public int CodePostalDep { get; set; }

        [Display(Name = "Ville de depart: ")]
        [Required(ErrorMessage = " obligatoire.")]
        public string VilleDep { get; set; }

        [Display(Name = "Rue d'arrivée : ")]
        [Required(ErrorMessage = " obligatoire.")]
        public string RueArr { get; set; }

        [Display(Name = "Code postal de la ville d'arrivée : ")]
        [Required(ErrorMessage = " obligatoire.")]
        public int CodePostalArr { get; set; }

        [Display(Name = "Ville d'arrivée : ")]
        [Required(ErrorMessage = " obligatoire.")]
        public string VilleArr { get; set; }

        [Display(Name = "Heure de départ : ")]
        [DataType(DataType.DateTime)]
        public DateTime HorairesDebut { get; set; }

        [Display(Name = "Heure d'arrivée : ")]
        [DataType(DataType.DateTime)]
        public DateTime HorairesFin { get; set; }

        [Display(Name = "Prix : ")]
        public decimal Prix { get; set; }

        [Display(Name = "Salaire prestataire : ")]
        public decimal Salaire_presta { get; set; }

        [Display(Name = "Note : ")]
        public int Note { get; set; }

        [Display(Name = "Avis : ")]
        public string Avis { get; set; }

        [Display(Name = "Etat : ")]
        public Status Etat { get; set; }
        
        
        [ForeignKey("IdClient")]
        public virtual Client Client { get; set; }

        [ForeignKey("IdPrestataire")]
        public virtual Prestataire Prestataire { get; set; }

        public Prestation()
        {
            this.Etat = Status.EnAttente;
        }
    }
}
