using System.Data.Entity;
using HealthSmartCity.Model;

namespace HealthSmartCity.Infrastructure.Interfaces
{  
    public interface IDataContext
    {
        DbSet<DataRecord> DataRecords { get; set; }

        DbSet<User> Users { get; set; }

        void Save();
    }
}
