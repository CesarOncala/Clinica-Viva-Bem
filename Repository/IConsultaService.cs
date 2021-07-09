using System.Collections.Generic;
using System.Threading.Tasks;
using Clinica_Viva_Bem.Models;
using Web.Repository.Base;

namespace Web.Repository
{
    public interface IConsultaService : IRepository<Consulta>
    {
       Task<IEnumerable<object>> List();
    }
}