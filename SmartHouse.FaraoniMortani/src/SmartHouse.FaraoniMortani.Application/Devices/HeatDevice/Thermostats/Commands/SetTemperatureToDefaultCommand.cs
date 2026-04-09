using SmartHouse.FaraoniMortani.Domain.Devices.HeatDevice.ThermostatDevice;
using SmartHouse.FaraoniMortani.Domain.Devices.HeatDevice.ThermostatDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Application.Devices.HeatDevice.Thermostats.Commands
{
    public class SetTemperatureToDefaultCommand
    {
        private readonly IThermostatRepository _thermostarepository;

        public SetTemperatureToDefaultCommand(IThermostatRepository thermostatRepository)
        {
            _thermostarepository = thermostatRepository;
        }

        public void Execute(Guid id, double newtemp)
        {
            Thermostat thermostat = _thermostarepository.GetById(id);
            if (thermostat != null)
            {
                thermostat.SetTemperatureToDefault();
                _thermostarepository.Update(thermostat);
            }
        }
    }
}
