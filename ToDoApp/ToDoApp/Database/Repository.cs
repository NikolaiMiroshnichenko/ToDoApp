using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Models;

namespace ToDoApp.Database
{
    public class Repository<T> 
        where T : Entity
    {
        private readonly DbContext _context;
               
        public Repository(DbContext context)
        {
            _context = context;
        }
        public Task<T> Get (int id)
        {
            return _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }
        public Task<List<T>> GetAllAsync()
        {
            return _context.Set<T>().ToListAsync();
        }

        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task<T> UpdateAsync (int id)
        {
            T entity = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            if (entity != null)
            {
                Update(entity);
            }
            return entity;
        }

        public void Update(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }       

        public async Task<T> DeleteAsync(int id)
        {
            T entity = await _context.Set<T>().FirstOrDefaultAsync(x=>x.Id==id);
            if (entity != null)
            {
                Delete(entity);
            }
            return entity;
        }

        public void Delete(T entity)
        {
            var dbSet = _context.Set<T>();
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }

        public Task SaveAsync()
        {
            return _context.SaveChangesAsync();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
