using JobOffice.DataAcces.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOffice.DataAcces
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        protected readonly JobOfficeContext context;
        private DbSet<T> entities;

        public Repository(JobOfficeContext context)
        {
            this.context = context;
            entities = context.Set<T>();

        }
        public async Task Delete(int id)
        {
            T entity = await entities.SingleOrDefaultAsync(x => x.Id == id);
            entities.Remove(entity);
            await context.SaveChangesAsync();
        }

        public Task<List<T>> GetAll()
        {
            return entities.ToListAsync();
        }

        public Task <T> GetById(int id)
        {
            return entities.SingleOrDefaultAsync(x => x.Id == id);
        }

        public Task Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(paramName:"entity");
            }
            entities.Add(entity);
            return context.SaveChangesAsync();

        }

        public Task Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(paramName: "entity");
            }
            return context.SaveChangesAsync();
        }
    }
}
