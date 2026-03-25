using SmartHouse.FaraoniMortani.Domain.Devices.LuminousDevices;
using SmartHouse.FaraoniMortani.Domain.Devices.LuminousDevices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Application.Devices.LuminousDevice.Lamps.Commands
{
    public class DimmerLampCommand
    {
        private readonly ILampRepository _lampRepository;

        public DimmerLampCommand(ILampRepository lampRepository)
        {
            _lampRepository = lampRepository;
        }

        public void Execute(Guid id, int amount)
        {
            Lamp lamp = _lampRepository.GetById(id);

            if (lamp == null) throw new Exception("There is no lamp at this id");
            else
            {
                lamp.Dimmer(amount);
                _lampRepository.Update(lamp);
            }
        }
    }
}
