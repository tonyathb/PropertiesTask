using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesTask
{
    interface IRepository<T>
    {
        public T Add(T entity);

        public List<T> GetAll();

        public T Get(long id);

        public T Update(long id, T entityToUpdate);

        public void Delete(long id);
    }
}
