using SmartHouse.FaraoniMortani.Domain.Devices.LuminousDevices;
using SmartHouse.FaraoniMortani.Domain.Devices.LuminousDevices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Application.Devices.LuminousDevice.Lamps.Commands
{
    public class SetCustomBrightnessCommand
    {
        public readonly ILampRepository _lampRepository;

        public SetCustomBrightnessCommand(ILampRepository lampRepository)
        {
            _lampRepository = lampRepository;
        }

        public void Execute(Guid id, int amount)
        {
            Lamp lamp = _lampRepository.GetById(id);

            if (lamp == null) throw new Exception("No lamp with specified id found");
            else
            {
                lamp.SetBrightness(new Brightness(amount));
                _lampRepository.Update(lamp);
            }
        }
    }
}
