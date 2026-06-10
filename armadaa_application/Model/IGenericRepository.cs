using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace armadaa_application.Model
{
    public interface IGenericRepository<T> where T : new()
    {
        List<T> GetAll();

        void insert(T item);
        void update(T item);
        void delete(T item);
    }
}
