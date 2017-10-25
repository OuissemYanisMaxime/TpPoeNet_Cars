using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Comptes.ViewModels
{
    public class Voiture
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "Marque : ")]
        [Required(ErrorMessage = " obligatoire.")]
        [StringLength(50)]
        public string Marque { get; set; }

        [Display(Name = "Modèle : ")]
        [Required(ErrorMessage = " obligatoire.")]
        [StringLength(50)]
        public string modele { get; set; }

        [Display(Name = "Immatriculation : ")]
        [Required(ErrorMessage = " obligatoire.")]
        [StringLength(20)]
        public string Immatriculation { get; set; }

        [Display(Name = "Nombre de places : ")]
        [Required(ErrorMessage = " obligatoire.")]
        public int Nb_Place { get; set; }

        public Voiture()
        {
        }
    }
}
