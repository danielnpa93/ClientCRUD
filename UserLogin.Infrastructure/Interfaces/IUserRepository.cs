using System.Collections.Generic;
using System.Threading.Tasks;
using UserLogin.Domain.Entities;

namespace UserLogin.Infrastructure.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByEmail(string email);
        Task<IEnumerable<User>> SearchByName(string name);
        Task<IEnumerable<User>> SearchByEmail(string email);
    }
}
