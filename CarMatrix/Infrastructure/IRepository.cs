using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMatrix.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        T Find(int id);
        void Create(T t);
        void Update(T t);
        void Delete(T t);
        IQueryable<T> GetEntities { get; }
    }
}
