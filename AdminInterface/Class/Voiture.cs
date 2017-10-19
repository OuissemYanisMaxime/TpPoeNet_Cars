using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminInterface.Class
{
    public class Voiture
    {
        
        public int id { get; set; }

        
        public string Marque { get; set; }

        
        public string modele { get; set; }

        
        public string Immatriculation { get; set; }

        
        public int Nb_Place { get; set; }

        public Voiture()
        {
        }
    }
}
