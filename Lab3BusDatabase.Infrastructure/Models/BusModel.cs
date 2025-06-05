using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab3BusDatabase.Infrastructure.Models
{
    public class BusModel
    {
        [Key]
        public Guid Id { get; set; }

        public string NumberPlate { get; set; }

        public int Capacity { get; set; }

        public int Year { get; set; }

        public int DriverId { get; set; }

        public DriverModel Driver { get; set; }
    }
}
