using System;

namespace  Clinica_Viva_Bem.Models{
    public class Patient : BaseModel{
       public string Name { get; set; }
       public string Address { get; set; }     

       public string PhoneNumber { get; set; }

       public DateTime BirthDay { get; set; }  

    }
}