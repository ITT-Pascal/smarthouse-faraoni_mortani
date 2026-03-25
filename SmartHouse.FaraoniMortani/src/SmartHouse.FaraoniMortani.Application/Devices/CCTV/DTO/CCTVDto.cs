using SmartHouse.FaraoniMortani.Domain.Devices.Abstractions;
using SmartHouse.FaraoniMortani.Domain.Devices.CCTV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Application.Devices.CCTV.DTO
{
    public class CCTVDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public CCTVMode Mode { get; set; }
        public Inclination Inclination { get; set; }
        public double Zoom { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public DateTime LastModifiedAtUtc { get; set; }

        public override string ToString()
        {
            return
                $"Id: {Id}\n" +
                $"Name: {Name}\n" +
                $"Status: {Status}\n" +
                $"Mode: {Mode}\n" +
                $"Inclination: {Inclination}\n" +
                $"Zoom: {Zoom}\n" +
                $"Created: {CreatedAtUtc}\n" +
                $"Last update: {LastModifiedAtUtc}\n";

        }
    }
}
