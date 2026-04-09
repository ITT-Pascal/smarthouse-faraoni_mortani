using SmartHouse.FaraoniMortani.Application.Devices.DoorDevice.DTO;
using SmartHouse.FaraoniMortani.Application.Devices.DoorDevice.Mapper;
using SmartHouse.FaraoniMortani.Application.Devices.LuminousDevice.Lamps.Mapper;
using SmartHouse.FaraoniMortani.Domain.Devices.DoorDevice;
using SmartHouse.FaraoniMortani.Domain.Devices.DoorDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Application.Devices.Door.Queries
{
    public class GetDoorByIdQuery
    {
        public readonly IDoorRepository _doorRepository;

        public GetDoorByIdQuery(IDoorRepository doorRepository)
        {
            _doorRepository = doorRepository;
        }

        public DoorDto Execute(Guid id)
        {
            Domain.Devices.DoorDevice.Door door = _doorRepository.GetById(id);

            if (door == null) throw new Exception("No door with specified id found");

            return DoorMapper.ToDto(door);
        }
    }
}
