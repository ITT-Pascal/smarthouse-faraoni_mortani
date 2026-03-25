using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHouse.FaraoniMortani.Domain.Devices.LuminousDevices;
using SmartHouse.FaraoniMortani.Domain.Devices.LuminousDevices.Repositories;

namespace SmartHouse.FaraoniMortani.Application.Devices.LuminousDevice.Lamps.Commands
{
    public class SwitchLampOffCommand
    {
        public readonly ILampRepository _lampRepository;

        public SwitchLampOffCommand(ILampRepository lampRepository)
        {
            _lampRepository = lampRepository;
        }

        public void Execute(Guid lampId)
        {
            Lamp lamp = _lampRepository.GetById(lampId);

            if (lamp == null) throw new Exception("No lamp with specified id found");
            else
            {
                lamp.SwitchOff();
                _lampRepository.Update(lamp);
            }

        }
    }
}
