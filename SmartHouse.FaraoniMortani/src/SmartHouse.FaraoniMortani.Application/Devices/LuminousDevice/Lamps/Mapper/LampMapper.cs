using SmartHouse.FaraoniMortani.Application.Devices.LuminousDevice.Lamps.DTO;
using SmartHouse.FaraoniMortani.Domain.Devices.LuminousDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Application.Devices.LuminousDevice.Lamps.Mapper
{
    public class LampMapper
    {
        public static LampDto ToDto(Lamp lamp)
        {
            return new LampDto
            {
                Id = lamp.Id,
                Name = lamp.Name,
                Brightness = lamp.Brightness.Value,
                CreatedAtUtc = lamp.CreatedAtUtc,
                LastModifiedAtUtc = lamp.LastModifiedAtUtc,
            };
        }
    }
}
