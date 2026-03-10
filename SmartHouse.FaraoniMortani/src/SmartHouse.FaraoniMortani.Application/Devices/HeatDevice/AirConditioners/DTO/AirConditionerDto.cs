using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Application.Devices.HeatDevice.AirConditioners.DTO
{
    public class AirConditionerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public double TargetTemperature { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastUpdateTime { get; set; }

        public override string ToString()
        {
            return
                $"Id: {Id}\n" +
                $"Name: {Name}\n" +
                $"Status: {Status}\n" +
                $"Temperature: {TargetTemperature}\n" +
                $"Created: {CreationTime}\n" +
                $"Last update: {LastUpdateTime}\n";
        }
    }
}
