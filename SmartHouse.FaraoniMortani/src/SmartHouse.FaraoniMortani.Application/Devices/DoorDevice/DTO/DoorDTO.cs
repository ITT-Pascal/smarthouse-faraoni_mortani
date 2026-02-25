using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Application.Devices.DoorDevice.DTO
{
    public class DoorDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Password { get; set; }
        public bool IsLocked { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public DateTime LastModifiedAtUtc { get; set; }

        public override string ToString()
        {
            return
                $"Id: {Id}\n" +
                $"Name: {Name}\n" +
                $"Status: {Status}\n" +
                $"Password: {Password}\n" +
                $"Lock Status: {IsLocked}\n" +
                $"Created: {CreatedAtUtc}\n" +
                $"Last update: {LastModifiedAtUtc}\n";

        }
    }
}
