using SmartHouse.FaraoniMortani.Domain.Devices.DoorDevice;
using SmartHouse.FaraoniMortani.Domain.Devices.DoorDevice.Repositories;
using SmartHouse.FaraoniMortani.Domain.Devices.LuminousDevices;
using SmartHouse.FaraoniMortani.Domain.Devices.LuminousDevices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Application.Devices.Door.Commands
{
    public class OpenDoorCommand
    {
        public readonly IDoorRepository _doorRepository;

        public OpenDoorCommand(IDoorRepository doorRepository)
        {
            _doorRepository = doorRepository;
        }

        public void Execute(Guid doorId)
        {
            Domain.Devices.DoorDevice.Door door = _doorRepository.GetById(doorId);

            if (door == null) throw new Exception("No door with specified id found");
            else
            {
                door.Open();
                _doorRepository.Update(door);
            }
        }
    }
}
