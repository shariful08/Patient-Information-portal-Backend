using Patient_Information_portal_Back_end.Models;
using Patient_Information_portal_Back_end.Models.Dto;
using System.Linq.Expressions;

namespace Patient_Information_portal_Back_end.Repository.IRepository
{
    public interface IPatientRepository : IRepo<PatientModel>
    {
        Task<PatientModel> UpdateAsync(PatientModel model);
    }
}
