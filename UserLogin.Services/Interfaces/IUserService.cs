using System.Collections.Generic;
using System.Threading.Tasks;
using UserLogin.Services.DTO;

namespace UserLogin.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> Create(UserDTO user);
        Task<UserDTO> Update(UserDTO user);
        Task Remove(long id);
        Task<UserDTO> GetById(long id);
        Task<IEnumerable<UserDTO>> GetAll();
        Task<UserDTO> GetByEmail(string email);
        Task<IEnumerable<UserDTO>> SearchByName(string name);
        Task<IEnumerable<UserDTO>> SearchByEmail(string email);
    }
}
