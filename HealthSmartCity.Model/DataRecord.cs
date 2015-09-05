using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthSmartCity.Model
{
    public class DataRecord
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public User Patient { get; set; }

        public DateTime Date { get; set; }

        public float Temperature { get; set; }

        public float Pulse { get; set; }

        public float Glucose{ get; set; }

        public string GPSCoordinates { get; set; }
    }
}
