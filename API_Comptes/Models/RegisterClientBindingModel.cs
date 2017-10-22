using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DAO.modeles;

namespace API_Comptes.Models
{
    public class RegisterClientBindingModel
    {
            public RegisterBindingModel Register { get; set; }
            public Client Client { get; set; }   
    }   
}
