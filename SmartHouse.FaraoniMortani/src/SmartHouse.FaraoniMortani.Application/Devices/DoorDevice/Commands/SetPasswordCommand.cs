using SmartHouse.FaraoniMortani.Domain.Devices.DoorDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Application.Devices.Door.Commands
{
    public class SetPasswordCommand
    {
        public readonly IDoorRepository _doorRepository;

        public SetPasswordCommand(IDoorRepository doorRepository)
        {
            _doorRepository = doorRepository;
        }

        public void Execute(Guid doorId, string currentPassword, string newPassword)
        {
            Domain.Devices.DoorDevice.Door door = _doorRepository.GetById(doorId);

            if (door == null) throw new Exception("No door with specified id found");
            else
            {
                door.SetNewPassword(currentPassword, newPassword);
                _doorRepository.Update(door);
            }
        }
    }
}
