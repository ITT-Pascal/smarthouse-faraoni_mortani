using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Application.Devices.LuminousDevice.Lamps.DTO
{
    public class LampDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public int Brightness { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastChangeTime { get; set; }

        public override string ToString()
        {
            return
                $"Id: {Id}\n" +
                $"Name: {Name}\n" +
                $"Status: {Status}\n" +
                $"Brightness: {Brightness}\n" +
                $"Created: {CreationTime}\n" +
                $"Last update: {LastChangeTime}\n";

        }
    }
}
