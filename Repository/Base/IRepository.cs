using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Clinica_Viva_Bem.Models;

namespace Web.Repository.Base
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetByFilter(Func<T, bool> filter, string [] Includes =null);
        Task<T> GetById(int Id, string[] Includes=null);
        Task<IEnumerable<T>> GetAll(string[] Includes=null);

        Task<bool> Save(T entity);

        Task<bool> Delete(int id);
    }
}