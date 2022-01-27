using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserLogin.Domain.Entities;
using UserLogin.Infrastructure.Context;
using UserLogin.Infrastructure.Interfaces;

namespace UserLogin.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly UserLoginContext _context;

        public UserRepository(UserLoginContext context) : base(context)
        {
            _context = context;
        }
        public async Task<User> GetByEmail(string email)
        {

            return await _context.Users.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());
        }

        public async Task<IEnumerable<User>> SearchByEmail(string email)
        {
            return await _context.Users.AsNoTracking()
                .Where(x => x.Email.ToLower().Contains(email.ToLower())).ToListAsync();
        }

        public async Task<IEnumerable<User>> SearchByName(string name)
        {
            return await _context.Users.AsNoTracking()
                .Where(x => x.FullName.ToLower().Contains(name.ToLower()))
                .ToListAsync();
        }
    }
}
