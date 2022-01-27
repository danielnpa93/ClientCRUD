
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserLogin.Domain.Entities;
using UserLogin.Infrastructure.Context;
using UserLogin.Infrastructure.Interfaces;

namespace UserLogin.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Base
    {
        private readonly UserLoginContext _context;

        public BaseRepository(UserLoginContext context)
        {
            _context = context;
        }

        public virtual async Task<T> Create(T obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        public virtual async Task<T> Update(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return obj;
        }
        public virtual async Task Remove(long id)
        {
            var obj = await GetById(id);
            if (obj != null)
            {
                _context.Remove(obj);
                await _context.SaveChangesAsync();
            }

        }

        public virtual async Task<T> GetById(long id)
        {
            return await _context.Set<T>()
                                .AsNoTracking()
                                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>()
                               .AsNoTracking()
                               .ToListAsync();
        }

    }
}
