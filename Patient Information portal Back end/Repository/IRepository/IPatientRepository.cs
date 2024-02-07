using Patient_Information_portal_Back_end.Models;
using Patient_Information_portal_Back_end.Models.Dto;
using System.Linq.Expressions;

namespace Patient_Information_portal_Back_end.Repository.IRepository
{
    public interface IPatientRepository
    {
        //Task Create(PatientsModel entity);
        Task<List<PatientModel>> GetAllAsync(Expression<Func<PatientModel, bool>> filter = null);
        Task<PatientModel> GetAsync(Expression<Func<PatientModel, bool>> filter = null, bool tracked=true);
        Task CreateAsync (PatientModel model);
        Task UpdateAsync (PatientModel model);
        Task RemoveAsync (PatientModel model);
        Task SaveAsync ();
    }
}
