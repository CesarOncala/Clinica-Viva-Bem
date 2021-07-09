

using Clinica_Viva_Bem;
using Clinica_Viva_Bem.Enums;

namespace  Clinica_Viva_Bem.Models
{
    public class Doctor : BaseModel
    {
        public string Phone { get; set; }
        public string Name { get; set; }
        public Especialidade Especialidade { get; set; }
    }
}