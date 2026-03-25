using SmartHouse.FaraoniMortani.Application.Devices.Abstractions.Mapper;
using SmartHouse.FaraoniMortani.Application.Devices.DoorDevice.DTO;
using SmartHouse.FaraoniMortani.Domain.Devices.CCTV;
using SmartHouse.FaraoniMortani.Domain.Devices.DoorDevice;
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
    }
}
