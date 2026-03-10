using SmartHouse.FaraoniMortani.Application.Devices.HeatDevice.Thermostats.DTO;
using SmartHouse.FaraoniMortani.Application.Devices.HeatDevice.Thermostats.Mapper;
using SmartHouse.FaraoniMortani.Domain.Devices.HeatDevice.ThermostatDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Application.Devices.HeatDevice.Thermostats.Queries
{
    public class ThermostatGetBIdQuery
    {
        private readonly IThermostatRepository _thermostatRepository;

        public ThermostatGetBIdQuery(IThermostatRepository thermostatRepository)
        {
            _thermostatRepository = thermostatRepository;
        }

        public ThermostatDto Execute(Guid id)
        {
            return ThermostatMapper.ToDto(_thermostatRepository.GetById(id));
        }
    }
}
