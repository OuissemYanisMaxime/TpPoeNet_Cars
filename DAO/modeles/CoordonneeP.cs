using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.modeles
{
    public class CoordonneeP
    {
        [Key]
        public int Id { get; set; }

        [EmailAddress(ErrorMessage = "Vous devez saisir un mail valide")]
        [Display(Name = "EMail : ")]
        [Required(ErrorMessage = " obligatoire.")]
        public string Mail { get; set; }

        [Display(Name = "Nom : ")]
        [Required(ErrorMessage = " obligatoire.")]
        [StringLength(50)]
        public string Nom { get; set; }

        [Display(Name = "Prenom : ")]
        [Required(ErrorMessage = " obligatoire.")]
        [StringLength(50)]
        public string Prenom { get; set; }

        [Display(Name = "Telephone Fixe : ")]
        [StringLength(15)]
        public string TelephoneFixe { get; set; }

        [Display(Name = "Telephone Portable : ")]
        [StringLength(15)]
        [Required(ErrorMessage = " obligatoire.")]
        public string TelephonePortable { get; set; }

        [Display(Name = "Rue : ")]
        [Required(ErrorMessage = " obligatoire.")]
        public string Rue { get; set; }

        [Display(Name = "CodePostal : ")]
        [Required(ErrorMessage = " obligatoire.")]
        public int CodePostal { get; set; }

        [Display(Name = "Ville : ")]
        [Required(ErrorMessage = " obligatoire.")]
        public string Ville { get; set; }


        public CoordonneeP()
        {
        }
    }
}
