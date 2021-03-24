using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoryRepository.Interfaces
{
    public interface IRepository<T>
    {
        void Add(T entity);

        void Delete(string id);

        void Update(string oldid, T entity);

        IQueryable<T> GetAll();

        T GetOne(string id);

        void SaveDatabase();
    }
}
