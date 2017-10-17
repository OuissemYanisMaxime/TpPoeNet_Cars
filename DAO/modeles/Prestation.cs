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
        [Required(ErrorMessage = " obligatoire.")]
        public int IdPrestataire { get; set; }

        [Display(Name = "Numéro client : ")]
        [Required(ErrorMessage = " obligatoire.")]
        public int IdClient { get; set; }

        // Adresse depart
        [Display(Name = "Rue départ : ")]
        [Required(ErrorMessage = " obligatoire.")]
        public string RueDep { get; set; }

        [Display(Name = "CodePostal départ : ")]
        [Required(ErrorMessage = " obligatoire.")]
        public int CodePostalDep { get; set; }

        [Display(Name = "Ville départ : ")]
        [Required(ErrorMessage = " obligatoire.")]
        public string VilleDep { get; set; }

        // Adresse Arrivée
        [Display(Name = "Rue arrivée : ")]
        [Required(ErrorMessage = " obligatoire.")]
        public string RueArr { get; set; }

        [Display(Name = "CodePostal arrivée : ")]
        [Required(ErrorMessage = " obligatoire.")]
        public int CodePostalArr { get; set; }

        [Display(Name = "Ville arrivée : ")]
        [Required(ErrorMessage = " obligatoire.")]
        public string VilleArr { get; set; }

        //

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
