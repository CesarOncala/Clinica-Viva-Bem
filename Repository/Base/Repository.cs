using System.Collections.Generic;
using Clinica_Viva_Bem.Models;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Web.Repository.Base
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        private readonly DataBaseContext _context;
        public Repository(DataBaseContext context)
        {
            this._context = context;
        }

        public Repository()
        {

        }
        public IEnumerable<T> GetByFilter(Func<T, bool> filter, string [] Includes = null) {
            
            var result = this.getIncludes(Includes);
              return  result.Where(filter); 
        }

        public async Task<T> GetById(int Id, string[] Includes = null)
        {
            var result = this.getIncludes(Includes);
            return await result.FirstOrDefaultAsync(o => o.Id == Id);

        }

        private IQueryable<T> getIncludes(string[] Includes)
        {
            var _resetSet = this._context.Set<T>().AsNoTracking().AsQueryable();

            if (Includes != null)
                Includes.ToList().ForEach(include => _resetSet = _resetSet.Include(include));

            return _resetSet;
        }
        public async Task<IEnumerable<T>> GetAll(string[] Includes = null)
        {
            var result = this.getIncludes(Includes);

            return await result.ToListAsync();
        }

        public async Task<bool> Save(T entity)
        {
            if (entity.Id == 0)
            {
                entity.DateCreate = DateTime.Now;
                entity.LastUpdate = DateTime.Now;
                await this._context.Set<T>().AddAsync(entity);
            }
            else
            {
                entity.LastUpdate = DateTime.Now;
                this._context.Set<T>().Update(entity);
            }




            return await this._context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                this._context.Remove(await this.GetById(id));
                await this._context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}