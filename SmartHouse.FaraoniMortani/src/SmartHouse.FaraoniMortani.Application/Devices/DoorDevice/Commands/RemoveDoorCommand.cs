using SmartHouse.FaraoniMortani.Domain.Devices.DoorDevice;
using SmartHouse.FaraoniMortani.Domain.Devices.DoorDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Application.Devices.DoorDevice.Commands
{
    public class RemoveDoorCommand
    {
        private readonly IDoorRepository _doorRepository;

        public RemoveDoorCommand(IDoorRepository doorRepository)
        {
            _doorRepository = doorRepository;
        }

        public void Execute(Guid lampId)
        {
            Domain.Devices.DoorDevice.Door door = _doorRepository.GetById(lampId);

            if (door == null) throw new Exception("No door with specified id found");
            else
            {
                _doorRepository.Delete(door);
                _doorRepository.Update(door);
            }

        }
    }
}
