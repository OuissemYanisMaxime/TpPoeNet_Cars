using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.modeles
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Id Coordonnées : ")]
        [Required(ErrorMessage = " obligatoire.")]
        public int IdCoordonnee { get; set; }

        [Display(Name = "Date d'inscription : ")]
        [DataType(DataType.DateTime)]
        public DateTime DateInscription { get; }

        [Display(Name = "Image de profil : ")]
        [Required(ErrorMessage = " obligatoire.")]
        public string LienImage { get; set; }

        [Display(Name = "Mot de passe : ")]
        [Required(ErrorMessage = " obligatoire.")]
        public string MdpCrypte { get; set; }

        [Display(Name = "Date de connection : ")]
        [DataType(DataType.DateTime)]
        public DateTime DateConnection { get; set; }

        [ForeignKey("IdCoordonnee")]
        public virtual Coordonnee Coordonnee { get; set; }

        public virtual ICollection<Prestation> Prestations { get; set; }

        public Client()
        {
            this.DateInscription = DateTime.Now;
        }
}
}
