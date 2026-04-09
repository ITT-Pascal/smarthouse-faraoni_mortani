using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHouse.FaraoniMortani.Domain.Devices.HeatDevice.AirConditioner;
using SmartHouse.FaraoniMortani.Domain.Devices.HeatDevice.AirConditioner.Repositories;
using SmartHouse.FaraoniMortani.Domain.Devices.HeatDevice.ThermostatDevice;
using SmartHouse.FaraoniMortani.Domain.Devices.HeatDevice.ThermostatDevice.Repositories;

namespace SmartHouse.FaraoniMortani.Application.Devices.HeatDevice.AirConditioners.Commands
{
    public class DecreaseTemperatureCommand
    {
        private readonly IAirConditionerRepository _airConditionerRepository;

        public DecreaseTemperatureCommand(IAirConditionerRepository airConditionerRepository)
        {
            _airConditionerRepository = airConditionerRepository;
        }

        public void Execute(Guid id)
        {
            AirConditioner airConditioner = _airConditionerRepository.GetById(id);
            if (airConditioner != null)
            {
                airConditioner.DecreaseTemperature();
                _airConditionerRepository.Update(airConditioner);
            }
        }
    }
}
