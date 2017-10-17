﻿using System;
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

        [Display(Name = "Rue : ")]
        [Required(ErrorMessage = " obligatoire.")]
        public string Rue { get; set; }

        [Display(Name = "CodePostal : ")]
        [Required(ErrorMessage = " obligatoire.")]
        [StringLength(12)]
        public string CodePostal { get; set; }

        [Display(Name = "Ville : ")]
        [Required(ErrorMessage = " obligatoire.")]
        [StringLength(100)]
        public string Ville { get; set; }

        public Adresse()
        {
        }
    }
}
