using Microsoft.EntityFrameworkCore;

namespace Clinica_Viva_Bem.Models
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Consulta> Consultas { get; set; }

    }
}