using System.Collections.Generic;
using System.Threading.Tasks;
using Clinica_Viva_Bem.Models;
using Web.Repository.Base;

namespace Web.Repository
{
    public interface IDoctorService : IRepository<Doctor>
    {
        Task<IEnumerable<object>> List();
    }
}