using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Clinica_Viva_Bem.Models
{
    public class Consulta : BaseModel
    {
        [Display(Name = "Hórario da Consulta")]
        [Required(ErrorMessage = "Selecione uma data e hora válida!")]
        public DateTime Date { get; set; }

        [Display(Name = "Nome do Paciente")]
        [Required(ErrorMessage = "Selecione o Paciente!")]
        public int PatientId { get; set; }


        [ForeignKey("PatientId")]
        public virtual Patient Patient { get; set; }


        [Display(Name = "Nome do Médico")]
        [Required(ErrorMessage = "Selecione o Médico!")]
        public int DoctorId { get; set; }


        [ForeignKey("DoctorId")]
        public virtual Doctor Doctor { get; set; }


    }
}