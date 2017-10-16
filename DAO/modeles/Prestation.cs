using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.modeles
{
    public enum Status { EnCours, EnAttente, Fini }
    public class Prestation
    {
        [Key]
        public int Id { get; set; }
        public int IdPrestataire { get; set; }
        public int IdClient { get; set; }
        public int IdAdresseDepart { get; set; }
        public int IdAdresseArrivee { get; set; }
        public DateTime HorairesDebut { get; set; }
        public DateTime HorairesFin { get; set; }
        public decimal Prix { get; set; }
        public decimal Salaire_presta { get; set; }
        public int Note { get; set; }
        public string Avis { get; set; }
        public Status Etat { get; set; }


        [ForeignKey("IdAdresseDepart")]
        public virtual Adresse Adresse { get; set; }
        [ForeignKey("IdAdresseArrivee")]
        public virtual Adresse Adresse1 { get; set; }
        [ForeignKey("IdClient")]
        public virtual Client Client { get; set; }
        [ForeignKey("IdPrestataire")]
        public virtual Prestataire Prestataire { get; set; }
        
    }
}
