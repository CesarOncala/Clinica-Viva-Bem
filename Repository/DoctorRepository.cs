using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clinica_Viva_Bem.Models;
using Web.Repository.Base;

namespace Web.Repository
{
    public class DoctorRepository : Repository<Doctor>, IDoctorService
    {
            public DoctorRepository(DataBaseContext context) : base(context) { }

            
        public async Task<IEnumerable<object>> List()
        {
            var data =   await this.GetAll();

            return data.Select(o=> new object[]{
                o.Id,
                o.Name,
                o.Phone,
                o.Especialidade.ToString(),
                o.DateCreate.ToString("dd/MM/yyyy HH:mm:ss"),
                string.Format("<button data-id='{0}' class='btn btn-primary btnEdit'> Edit </button>" +
                 "<button data-id='{0}' class='btn btn-danger btnDelete'> Delete </button>",o.Id)
            });
        }
       
    }
}