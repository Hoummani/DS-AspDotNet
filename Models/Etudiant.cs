using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AspDotNetCoreApp.Models
{
    public class Etudiant
    {
        [Key]        
        public int EtudiantId { get; set; }

        [Required]    
        public long cne {get; set;}

        [Required]
        [StringLength(7, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string nom {get; set;}

        [Required]
        [StringLength(7, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string prenom {get; set;}

        public int FiliereId {get; set;}

        [Required]    
        public Filiere Filiere {get; set;}
    }
}