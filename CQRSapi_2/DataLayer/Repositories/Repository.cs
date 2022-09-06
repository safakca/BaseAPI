using CQRSapi_2.DataLayer.Context;
using CQRSapi_2.DataLayer.Interfaces;
using CQRSapi_2.EntityLayer;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CQRSapi_2.DataLayer.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DatabaseContext _context;

        public Repository(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public async Task<T> CreateAsync(T t)
        {
            await _context.Set<T>().AddAsync(t);
            await _context.SaveChangesAsync();
            return t;
        }
        public async Task<T> UpdateAsync(T t)
        {
            _context.Set<T>().Update(t);
            await _context.SaveChangesAsync();
            return t;
        }
        public async Task DeleteAsync(int id)
        {
            var deleted = await GetByIdAsync(id);
            _context.Set<T>().Remove(deleted);
            await _context.SaveChangesAsync();

        }
    }
}
