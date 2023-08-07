using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Repositories {
    public interface IGenericRepository<T> where T : class {
        Task<T?> GetByIdAsync(int Id);
        IQueryable<T> GetAll();
        //direkt veri tabanına gitmez döndükten sonra işlem yapılabilir
        IQueryable<T> where(Expression<Func<T,bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T,bool>> expression);
        Task AddAsync(T entity);
        void Remove(T entity);
        void Update(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        void RemoveRange(IEnumerable<T> entities);
    }
}
