using SmartHouse.FaraoniMortani.Application.Devices.HeatDevice.Thermostats.DTO;
using SmartHouse.FaraoniMortani.Application.Devices.HeatDevice.Thermostats.Mapper;
using SmartHouse.FaraoniMortani.Domain.Devices.HeatDevice.ThermostatDevice;
using SmartHouse.FaraoniMortani.Domain.Devices.HeatDevice.ThermostatDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Application.Devices.HeatDevice.Thermostats.Queries
{
    public class GetAllQuery
    {
        public class ThermostatGetAllQuery
        {
            private readonly IThermostatRepository _repository;

            public ThermostatGetAllQuery(IThermostatRepository repos)
            {
                _repository = repos;
            }

            public List<ThermostatDto> Execute()
            {
                List<ThermostatDto> result = new List<ThermostatDto>();

                foreach (Thermostat t in _repository.GetAll())
                {
                    if (t != null)
                        result.Add(ThermostatMapper.ToDto(t));
                }
                return result;
            }
        }

    }
}
