using System;
using System.ComponentModel.DataAnnotations;

namespace Clinica_Viva_Bem.Models{
    public abstract class BaseModel {
        
        [Key]
        public int Id { get; set; }

        public DateTime DateCreate { get; set; }

        public DateTime LastUpdate { get; set; }


    }
}