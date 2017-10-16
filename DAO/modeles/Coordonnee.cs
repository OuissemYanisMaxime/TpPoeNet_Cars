using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.modeles
{
    public class Coordonnee
    {
        [Key]
        public int Id { get; set; }
        [EmailAddress(ErrorMessage = "Vous devez saisir un mail valide")]
        [Display(Name ="EMail : ")]
        [Required(ErrorMessage = " obligatoire.")]
        public string Mail { get; set; }
        [Display(Name = "Nom : ")]
        [Required(ErrorMessage = " obligatoire.")]
        public string Nom { get; set; }
        [Display(Name = "Prenom : ")]
        [Required(ErrorMessage = " obligatoire.")]
        public string Prenom { get; set; }
        public int IdAdresse { get; set; }
        [Display(Name = "Telephone Fixe : ")]
        [Required(ErrorMessage = " obligatoire.")]
        public string TelephoneFixe { get; set; }
        [Display(Name = "Telephone Portable : ")]
        [Required(ErrorMessage = " obligatoire.")]
        public string TelephonePortable { get; set; }

        [ForeignKey("IdAdresse")]
        public virtual Adresse Adresse { get; set; }

        public Coordonnee()
        {
        }
    }
}
