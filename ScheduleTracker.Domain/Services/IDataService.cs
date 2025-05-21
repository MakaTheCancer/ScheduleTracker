using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleTracker.Domain.Services
{
    public interface IDataService<T>
    {
        public Task<IEnumerable<T>> GetAll();
        public Task<T> GetById(int id);
        public Task<T> Create(T entity);
        public Task<T> Update(int id, T entity);
        public Task<bool> Delete(int id);
    }
}
