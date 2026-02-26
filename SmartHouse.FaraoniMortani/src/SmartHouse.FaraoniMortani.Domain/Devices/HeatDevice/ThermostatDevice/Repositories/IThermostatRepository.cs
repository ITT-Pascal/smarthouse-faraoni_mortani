using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Domain.Devices.HeatDevice.ThermostatDevice.Repositories
{
    public interface IThermostatRepository
    {
        void Add(Thermostat thermostat);
        void Update(Thermostat thermostat);
        void Delete(Thermostat thermostat);
        Thermostat GetById(Guid id);
        List<Thermostat> GetAll();
    }
}
