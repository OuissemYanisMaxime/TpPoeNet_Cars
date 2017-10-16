using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.modeles
{
    public class Adresse
    {

        [Key]
        public int Id { get; set; }
        public string Rue { get; set; }
        public int CodePostal { get; set; }
        public string Ville { get; set; }

        
    }
}
