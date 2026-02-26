using SmartHouse.FaraoniMortani.Domain.Devices.HeatDevice.ThermostatDevice;
using SmartHouse.FaraoniMortani.Domain.Devices.HeatDevice.ThermostatDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Application.Devices.HeatDevice.Thermostats.Commands
{
    public class SetTemperatureToMaxCommand
    {
        private readonly IThermostatRepository _thermostarepository;

        public SetTemperatureToMaxCommand(IThermostatRepository thermostatRepository)
        {
            _thermostarepository = thermostatRepository;
        }

        public void Execute(Guid id, double newtemp)
        {
            Thermostat thermostat = _thermostarepository.GetById(id);
            if (thermostat != null)
            {
                thermostat.SetTemperatureToMax();
                _thermostarepository.Update(thermostat);
            }
        }
    }
}
