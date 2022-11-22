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
        public void Delete(int id)
        {
            T entity = entities.SingleOrDefault(x => x.Id == id);
            entities.Remove(entity);
            context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public T GetById(int id)
        {
            return entities.SingleOrDefault(x => x.Id == id);
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(paramName:"entity");
            }
            entities.Add(entity);
            context.SaveChanges();

        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(paramName: "entity");
            }
            context.SaveChanges();
        }
    }
}
