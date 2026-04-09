using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHouse.FaraoniMortani.Application.Devices.HeatDevice.AirConditioners.DTO;
using SmartHouse.FaraoniMortani.Application.Devices.HeatDevice.AirConditioners.Mapper;
using SmartHouse.FaraoniMortani.Application.Devices.HeatDevice.Thermostats.DTO;
using SmartHouse.FaraoniMortani.Application.Devices.HeatDevice.Thermostats.Mapper;
using SmartHouse.FaraoniMortani.Domain.Devices.HeatDevice.AirConditioner.Repositories;
using SmartHouse.FaraoniMortani.Domain.Devices.HeatDevice.ThermostatDevice.Repositories;

namespace SmartHouse.FaraoniMortani.Application.Devices.HeatDevice.AirConditioners.Queries
{
    public class AirConditionerGetByIdQuery
    {
        private readonly IAirConditionerRepository _airConditionerRepository;

        public AirConditionerGetByIdQuery(IAirConditionerRepository airConditionerRepository)
        {
            _airConditionerRepository = airConditionerRepository;
        }

        public AirConditionerDto Execute(Guid id)
        {
            return AirConditionerMapper.ToDto(_airConditionerRepository.GetById(id));
        }
    }
}
