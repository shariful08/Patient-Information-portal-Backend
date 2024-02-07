using Microsoft.EntityFrameworkCore;
using Patient_Information_portal_Back_end.Data;
using Patient_Information_portal_Back_end.Models;
using Patient_Information_portal_Back_end.Repository.IRepository;
using System.Linq;
using System.Linq.Expressions;

namespace Patient_Information_portal_Back_end.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext _db;
        //internal DbSet<T> dbSet;
        public PatientRepository(ApplicationDbContext db)
        {
            _db = db;
            //this.dbSet = _db.Set<T>();
        }
        public async Task<List<PatientModel>> GetAllAsync(Expression<Func<PatientModel, bool>>? filter = null)
        {
            IQueryable<PatientModel> query = _db.PatientsInformation;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync();
        }

        public async Task CreateAsync(PatientModel patientModel)
        {
            await _db.PatientsInformation.AddAsync(patientModel);
            await _db.SaveChangesAsync();
        }

        public async Task<PatientModel> GetAsync(Expression <Func<PatientModel, bool>> filter = null, bool tracked = true)
        {
            IQueryable<PatientModel> query = _db.PatientsInformation;
            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            if(filter != null)
            {
                query = query.Where(filter);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task RemoveAsync(PatientModel patientModel)
        {
            _db.PatientsInformation.Remove(patientModel);
            await SaveAsync();  
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
        public async Task UpdateAsync(PatientModel model)
        {
            _db.PatientsInformation.Update(model);
            await SaveAsync();
        }
    }
}
