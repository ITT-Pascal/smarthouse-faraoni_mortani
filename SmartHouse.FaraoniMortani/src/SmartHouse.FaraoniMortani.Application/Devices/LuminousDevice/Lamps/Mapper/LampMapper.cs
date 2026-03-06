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
                Status = lamp.Status.ToString(),
                Brightness = lamp.BrightnessLevel.Value,
                CreationTime = lamp.CreationTime,
                LastChangeTime = lamp.LastChangeTime,
            };
        }

        public static Lamp ToDomain(LampDto dto)
        {
            return new Lamp(
                dto.Id,
                dto.Name,
                new Brightness(dto.Brightness),
                dto.CreationTime,
                dto.LastChangeTime
             );
        }
    }
}
