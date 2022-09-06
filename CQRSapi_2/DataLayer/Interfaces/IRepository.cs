using CQRSapi_2.EntityLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CQRSapi_2.DataLayer.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> CreateAsync(T t);
        Task<T> UpdateAsync(T t);
        Task DeleteAsync(int id);
    }
}
