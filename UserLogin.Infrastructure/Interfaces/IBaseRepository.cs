using System.Collections.Generic;
using System.Threading.Tasks;
using UserLogin.Domain.Entities;

namespace UserLogin.Infrastructure.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Create(TEntity obj);

        Task<TEntity> Update(TEntity obj);

        Task Remove(long id);

        Task<TEntity> GetById(long id);

        Task<IEnumerable<TEntity>> GetAll();

    }
}
