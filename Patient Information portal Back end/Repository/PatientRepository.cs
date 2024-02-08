using Microsoft.EntityFrameworkCore;
using Patient_Information_portal_Back_end.Data;
using Patient_Information_portal_Back_end.Models;
using Patient_Information_portal_Back_end.Repository.IRepository;
using System.Linq;
using System.Linq.Expressions;

namespace Patient_Information_portal_Back_end.Repository
{
    public class PatientRepository : Repo<PatientModel>, IPatientRepository
    {
        private readonly ApplicationDbContext _db;
        public PatientRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }
        public async Task<PatientModel> UpdateAsync(PatientModel model)
        {
            model.UpdatedDate = DateTime.Now;
            _db.PatientsInformation.Update(model);
            await _db.SaveChangesAsync();
            return model;
        }
    }
}
