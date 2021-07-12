using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clinica_Viva_Bem.Models;
using Web.Models.DataBaseModels;
using Web.Repository.Base;

namespace Web.Repository
{
    public class ConsultaRepository : Repository<Consulta>, IConsultaService
    {
        public ConsultaRepository(DataBaseContext context) : base(context) { }

        public IEnumerable<object> List(ConsultationTableFiltes o)
        {
            Func<Consulta, bool> filterData = (c) =>
            {
                return (

                (
                   !string.IsNullOrWhiteSpace(o.Doctor) && !string.IsNullOrWhiteSpace(o.Patient) ?
                   c.Doctor.Name.ToUpper().Trim().Contains(o.Doctor.ToUpper().Trim()) &&  c.Patient.Name.ToUpper().Trim().Contains(o.Patient.ToUpper().Trim()) :
                   !string.IsNullOrWhiteSpace(o.Doctor) ? c.Doctor.Name.ToUpper().Trim().Contains(o.Doctor.ToUpper().Trim()) : true &&
                   !string.IsNullOrWhiteSpace(o.Patient) ? c.Patient.Name.ToUpper().Trim().Contains(o.Patient.ToUpper().Trim()) : true
                ) &&

                   (o.DateEnd == null && o.DateStart == null ? true :
                    o.DateStart != null && o.DateEnd == null ?
                     c.Date.Date >= o.DateStart : o.DateEnd != null && o.DateStart == null ? c.Date.Date <= o.DateEnd :
                   o.DateStart == o.DateEnd ? o.DateEnd == c.Date.Date :
                    c.Date.Date >= o.DateStart && c.Date.Date <= o.DateEnd)


                );

            };

            var data = this.GetByFilter(filterData, new[] { "Doctor", "Patient" });

            return  data.Select(o => new object[]{
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