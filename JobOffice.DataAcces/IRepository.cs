using JobOffice.DataAcces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOffice.DataAcces
{
    public interface IRepository<T> where T : EntityBase
    {
        IEnumerable<T> GetAll();

        T GetById(int id);
        
        void Insert(T entity);
        
        void Update(T entity);
        
        void Delete(int id);


    }
}
