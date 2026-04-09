using SmartHouse.FaraoniMortani.Application.Devices.Abstractions.Mapper;
using SmartHouse.FaraoniMortani.Application.Devices.DoorDevice.DTO;
using SmartHouse.FaraoniMortani.Application.Devices.LuminousDevice.Lamps.DTO;
using SmartHouse.FaraoniMortani.Domain.Devices.CCTV;
using SmartHouse.FaraoniMortani.Domain.Devices.DoorDevice;
using SmartHouse.FaraoniMortani.Domain.Devices.LuminousDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Application.Devices.DoorDevice.Mapper
{
    public class DoorMapper
    {
        public static DoorDto ToDto(Domain.Devices.DoorDevice.Door door)
        {
            return new DoorDto
            {
                Id = door.Id,
                Name = door.Name,
                Status = DeviceStatusMapper.ToDto(door.Status),
                Password = door.Password,
                IsLocked = door.IsLocked,
                CreatedAtUtc = door.CreationTime,
                LastModifiedAtUtc = door.LastChangeTime,
            };
        }

        public static Domain.Devices.DoorDevice.Door ToDomain(DoorDto dto)
        {
            return new Domain.Devices.DoorDevice.Door(
                dto.Name,
                dto.Password
             );
        }
    }
}
