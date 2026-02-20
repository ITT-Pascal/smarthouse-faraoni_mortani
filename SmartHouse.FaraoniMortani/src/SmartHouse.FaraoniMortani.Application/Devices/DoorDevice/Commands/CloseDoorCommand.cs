using SmartHouse.FaraoniMortani.Domain.Devices.DoorDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Application.Devices.Door.Commands
{
    public class CloseDoorCommand
    {
        public readonly IDoorRepository _doorRepository;

        public CloseDoorCommand(IDoorRepository doorRepository)
        {
            _doorRepository = doorRepository;
        }

        public void Execute(Guid doorId)
        {
            Domain.Devices.DoorDevice.Door door = _doorRepository.GetById(doorId);

            if (door == null) throw new Exception("There is no lamp at this id");
            else
            {
                door.Close();
                _doorRepository.Update(door);
            }
        }
    }
}
