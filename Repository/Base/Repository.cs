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
        public IEnumerable<T> GetByFilter(Func<T, bool> filter) =>
        this._context.Set<T>().AsNoTracking().Where(filter);

        public async Task<T> GetById(int Id) => await
        this._context.Set<T>()
        .FirstOrDefaultAsync(o => o.Id == Id);

        public async Task<IEnumerable<T>> GetAll() => await
        this._context.Set<T>()
        .AsNoTracking().ToListAsync();

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
            catch (System.Exception e)
            {
                return false;
            }
        }
    }
}