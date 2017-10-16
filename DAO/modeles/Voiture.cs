using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.modeles
{
    public class Voiture
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "Marque : ")]
        [Required(ErrorMessage = " obligatoire.")]
        public string Marque { get; set; }

        [Display(Name = "Modèle : ")]
        [Required(ErrorMessage = " obligatoire.")]
        public string modele { get; set; }

        [Display(Name = "Immatriculation : ")]
        [Required(ErrorMessage = " obligatoire.")]
        public string Immatriculation { get; set; }

        [Display(Name = "Nombre de places : ")]
        [Required(ErrorMessage = " obligatoire.")]
        public int Nb_Place { get; set; }

        public Voiture()
        {
        }
    }
}
