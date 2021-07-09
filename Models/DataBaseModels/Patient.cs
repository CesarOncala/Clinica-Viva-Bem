using System;
using System.ComponentModel.DataAnnotations;

namespace Clinica_Viva_Bem.Models
{
    public class Patient : BaseModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public DateTime BirthDay { get; set; }

    }
}