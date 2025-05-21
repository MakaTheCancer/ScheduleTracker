using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ScheduleTracker.Domain.Models;
using ScheduleTracker.Domain.Services;
using ScheduleTracker.EntityFamework;

namespace ScheduleTracker.EntityFramework.Services
{
    public class GenericDataService<T> : IDataService<T> where T : DomainObject
    {
        private readonly ScheduleTrackerDbContextFactory _dbContextFactory;

        public GenericDataService(ScheduleTrackerDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<T> Create(T entity)
        {
            using(ScheduleTrackerDbContext context = _dbContextFactory.CreateDbContext()) 
            {
                EntityEntry<T> createdResult = await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();

                return createdResult.Entity;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (ScheduleTrackerDbContext context = _dbContextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id==id);
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();

                return true;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using (ScheduleTrackerDbContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<T> entities = await context.Set<T>().ToListAsync();

                return entities;
            }
        }

        public async Task<T> GetById(int id)
        {
            using (ScheduleTrackerDbContext context = _dbContextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);

                return entity;
            }
        }

        public async Task<T> Update(int id, T entity)
        {
            using (ScheduleTrackerDbContext context = _dbContextFactory.CreateDbContext())
            {
                entity.Id = id;
                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();

                return entity;
            }
        }

        public async Task<int?> GetUserIdByEmail(string email)
        {
            using (ScheduleTrackerDbContext context = _dbContextFactory.CreateDbContext())
            {
                var user = await context.Users.FirstOrDefaultAsync(u => u.Email == email);
                return user?.Id;
            }
        }




    }
}
