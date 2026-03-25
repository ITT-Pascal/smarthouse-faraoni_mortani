using SmartHouse.FaraoniMortani.Domain.Devices.DoorDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Application.Devices.DoorDevice.Commands
{
    public class AddDoorCommand
    {
        public readonly IDoorRepository _doorRepository;

        public AddDoorCommand(IDoorRepository doorRepository)
        {
            _doorRepository = doorRepository;
        }

        public void Execute(string doorName, string password)
        {
            _doorRepository.Add(new Domain.Devices.DoorDevice.Door(doorName, password));
        }
    }
}
