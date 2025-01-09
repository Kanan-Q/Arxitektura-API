using BlogApp.Core.Entites.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity, new()
    {
        IQueryable<T> GetAll();
        Task<T?> GetByIdAsync(int id);
        IQueryable<T> GetWhere(Func<T, bool> expression);
        Task<bool> IsExistAsync(int id);
        Task Addasync(T entity);
        void Remove(T entity);
        Task<bool> RemoveAsync(int id);
        Task<int> SaveAsync();

    }
}
