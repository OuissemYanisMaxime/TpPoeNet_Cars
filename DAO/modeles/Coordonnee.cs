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
        public string Mail { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int IdAdresse { get; set; }
        public string TelephoneFixe { get; set; }
        public string TelephonePortable { get; set; }


        [ForeignKey("IdAdresse")]
        public virtual Adresse Adresse { get; set; }
    }
}
