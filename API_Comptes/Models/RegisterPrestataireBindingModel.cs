using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DAO.modeles;

namespace API_Comptes.Models
{
    public class RegisterPrestataireBindingModel
    {
        public RegisterBindingModel Register { get; set; }
        public Prestataire Prestataire { get; set; }
    }
}
