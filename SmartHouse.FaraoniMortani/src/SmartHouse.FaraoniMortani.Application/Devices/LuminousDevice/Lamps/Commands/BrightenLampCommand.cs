using SmartHouse.FaraoniMortani.Domain;
using SmartHouse.FaraoniMortani.Domain.LuminousDevices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Application.Devices.LuminousDevice.Lamps.Commands
{
    public class BrightenLampCommand
    {
        public readonly ILampRepository _lampRepository;

        public BrightenLampCommand(ILampRepository lampRepository)
        {
            _lampRepository = lampRepository;
        }

        public void Execute(Guid id, int amount)
        {
            Lamp lamp = _lampRepository.GetById(id);

            if (lamp == null) throw new Exception("There is no lamp at this id");
            else
            {
                lamp.Brighten(amount);
                _lampRepository.Update(lamp);
            }
        }
    }
}
