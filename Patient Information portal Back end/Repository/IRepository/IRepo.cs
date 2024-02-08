using Patient_Information_portal_Back_end.Models;
using System.Linq.Expressions;

namespace Patient_Information_portal_Back_end.Repository.IRepository
{
    public interface IRepo<T> where T : class
    {
        //Task Create(PatientsModel entity);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null);
        Task<T> GetAsync(Expression<Func<T, bool>>? filter = null, bool tracked = true);
        Task CreateAsync(T model);

        Task RemoveAsync(T model);
        Task SaveAsync();
    }
}
