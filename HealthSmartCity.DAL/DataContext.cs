using System.Data.Entity;
using HealthSmartCity.Infrastructure.Interfaces;
using HealthSmartCity.Model;

namespace HealthSmartCity.DAL
{
    namespace Clinic.Data
    {
        public class DataContext : DbContext, IDataContext
        {
            public DataContext() : base("name=DataContext") { }

            public DbSet<DataRecord> DataRecords { get; set; }

            public DbSet<User> Users { get; set; }

            public void Save()
            {
                SaveChanges();
            }
        }
    }
}
