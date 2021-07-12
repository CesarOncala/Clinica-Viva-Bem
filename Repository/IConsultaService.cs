using System.Collections.Generic;
using System.Threading.Tasks;
using Clinica_Viva_Bem.Models;
using Web.Models.DataBaseModels;
using Web.Repository.Base;

namespace Web.Repository
{
    public interface IConsultaService : IRepository<Consulta>
    {
       IEnumerable<object> List(ConsultationTableFiltes filters);
    }
}