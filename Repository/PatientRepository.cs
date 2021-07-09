using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clinica_Viva_Bem.Models;
using Web.Repository.Base;

namespace Web.Repository
{
    public class PatientRepository :  Repository<Patient>, IPatientService
    {
        public PatientRepository(DataBaseContext context) : base(context) {}
        public async Task<IEnumerable<object>> List()
        {
            var data =   await this.GetAll();

            return data.Select(o=> new object[]{
                o.Id,
                o.Name,
                o.Address,
                o.BirthDay,
                o.PhoneNumber,
                o.DateCreate,
                $"<a data-id='{o.Id}' class='btn'/>"
            });
        }
    }
}