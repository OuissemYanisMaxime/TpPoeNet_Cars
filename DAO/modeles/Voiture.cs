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
        public string Marque { get; set; }
        public string modele { get; set; }
        public string Immatriculation { get; set; }
        public int Nb_Place { get; set; }

        
    }
}
