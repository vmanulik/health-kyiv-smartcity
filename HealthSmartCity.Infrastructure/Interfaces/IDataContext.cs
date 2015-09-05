using System.Data.Entity;
using HealthSmartCity.Model;

namespace HealthSmartCity.Infrastructure.Interfaces
{  
    public interface IDataContext
    {
        DbSet<DataRecord> Patients { get; set; }

        void Save();
    }
}
