using SmartHouse.FaraoniMortani.Domain.Devices.HeatDevice.ThermostatDevice;
using SmartHouse.FaraoniMortani.Domain.Devices.HeatDevice.ThermostatDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Application.Devices.HeatDevice.Thermostats.Commands
{
    public class RemoveThermostatCommand
    {
        private readonly IThermostatRepository _thermostatRepository;

        public RemoveThermostatCommand(IThermostatRepository thermostatRepository)
        {
            _thermostatRepository = thermostatRepository;
        }

        public void Execute(Guid thermostatId)
        {
            Thermostat thermostat = _thermostatRepository.GetById(thermostatId);
            if (thermostat != null)
            {
                _thermostatRepository.Delete(thermostat);
                _thermostatRepository.Update(thermostat);
            }
        }
    }
}
