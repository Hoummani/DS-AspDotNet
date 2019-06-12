using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AspDotNetCoreApp.Models
{
    public class Filiere
    {
        [Key]        
        public int FiliereId { get; set; }

        [Required]
        
           
        [StringLength(15, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string nom {get; set;}

        public virtual ICollection<Etudiant> Etudiants {get; set;}
    }
}