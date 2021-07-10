using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clinica_Viva_Bem.Models;
using Web.Repository.Base;

namespace Web.Repository
{
    public class ConsultaRepository : Repository<Consulta>, IConsultaService
    {
        public ConsultaRepository(DataBaseContext context) : base(context)  {}

        public async Task<IEnumerable<object>> List()
        {
            var data = await this.GetAll(new []{"Doctor","Patient"});
        
            return data.Select(o=> new object[]{
                o.Id,
                o.Patient.Name,
                o.Doctor.Name,
                o.Date.ToString("dd/MM/yyyy HH:mm:ss"),
                o.DateCreate.ToString("dd/MM/yyyy HH:mm:ss"),
                 string.Format("<button data-id='{0}' class='btn btn-primary btnEdit'> Edit </button>" +
                 "<button data-id='{0}' class='btn btn-danger btnDelete'> Delete </button>",o.Id)

            });
            // Other Way to create datatable json
            // return data.Select(f => new {
            //     DoctorName = f.Doctor.Name,
            //     DoctorSpeciality = f.Doctor.Especialidade.ToString(),
            //     DoctorPhone = f.Doctor.Phone,
            //     PatientName = f.Patient.Name,
            //     PatientPhone = f.Patient.PhoneNumber,
            //     PatientAddress = f.Patient.Address,
            //     ConsultDate = f.Date,
            //     ConsultRegisterData = f.DateCreate
            // });
        }
    }
}