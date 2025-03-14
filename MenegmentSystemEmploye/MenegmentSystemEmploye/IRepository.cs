using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenegmentSystemEmploye
{
    interface IRepository<T> 
    {
        void Add(T t);
        void Update(T t);

        void Remove(int id);

        T GetBy(int id);
        IEnumerable<T> GetAll();
    }
}
