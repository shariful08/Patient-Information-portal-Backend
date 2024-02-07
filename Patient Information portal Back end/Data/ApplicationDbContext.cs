using Microsoft.EntityFrameworkCore;
using Patient_Information_portal_Back_end.Models;

namespace Patient_Information_portal_Back_end.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<PatientModel> PatientsInformation { get; set; }
    }
}
