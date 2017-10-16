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
        public int IdCoordonnee { get; set; }
        public DateTime DateInscription { get; set; }
        public string LienImage { get; set; }
        public string MdpCrypte { get; set; }
        public DateTime DateConnection { get; set; }

        [ForeignKey("IdCoordonnee")]
        public virtual Coordonnee Coordonnee { get; set; }
    }
}
