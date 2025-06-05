using System;

namespace BusManagement.REST.Models
{
    public class BusDto
    {
        public Guid Id { get; set; }
        public string NumberPlate { get; set; }
        public int Capacity { get; set; }
        public int Year { get; set; }
        public int DriverId { get; set; }
    }
}
