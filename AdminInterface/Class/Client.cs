using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminInterface.Class

{
    public class Client
    {
        
        public int Id { get; set; }

       
        public int IdCoordonnee { get; set; }

        
        public DateTime DateInscription { get; }

        
        public string LienImage { get; set; }

        
        public string MdpCrypte { get; set; }

        
        public DateTime DateConnection { get; set; }

       
        public virtual CoordonneeC Coordonnee { get; set; }

        public virtual ICollection<Prestation> Prestations { get; set; }

        public Client()
        {
            this.DateInscription = DateTime.Now;
        }
}
}
