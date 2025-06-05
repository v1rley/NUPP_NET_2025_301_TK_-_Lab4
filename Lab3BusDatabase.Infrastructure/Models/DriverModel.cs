using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab3BusDatabase.Infrastructure.Models
{
    public class DriverModel
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<BusModel> Buses { get; set; }
    }
}
