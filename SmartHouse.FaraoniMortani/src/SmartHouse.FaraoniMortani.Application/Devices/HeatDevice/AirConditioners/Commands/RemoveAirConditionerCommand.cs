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
    public class RemoveAirConditionerCommand
    {
        private readonly IAirConditionerRepository _airConditionerRepository;

        public RemoveAirConditionerCommand(IAirConditionerRepository airConditionerRepository)
        {
            _airConditionerRepository = airConditionerRepository;
        }

        public void Execute(Guid airConditionerId)
        {
            AirConditioner airConditioner = _airConditionerRepository.GetById(airConditionerId);
            if (airConditioner != null)
            {
                _airConditionerRepository.Delete(airConditioner);
                _airConditionerRepository.Update(airConditioner);
            }
        }
    }
}
