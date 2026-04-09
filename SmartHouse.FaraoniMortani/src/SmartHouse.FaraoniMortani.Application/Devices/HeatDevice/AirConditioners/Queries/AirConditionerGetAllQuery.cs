using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHouse.FaraoniMortani.Application.Devices.HeatDevice.AirConditioners.DTO;
using SmartHouse.FaraoniMortani.Application.Devices.HeatDevice.AirConditioners.Mapper;
using SmartHouse.FaraoniMortani.Application.Devices.HeatDevice.Thermostats.DTO;
using SmartHouse.FaraoniMortani.Application.Devices.HeatDevice.Thermostats.Mapper;
using SmartHouse.FaraoniMortani.Domain.Devices.HeatDevice.AirConditioner;
using SmartHouse.FaraoniMortani.Domain.Devices.HeatDevice.AirConditioner.Repositories;
using SmartHouse.FaraoniMortani.Domain.Devices.HeatDevice.ThermostatDevice;
using SmartHouse.FaraoniMortani.Domain.Devices.HeatDevice.ThermostatDevice.Repositories;

namespace SmartHouse.FaraoniMortani.Application.Devices.HeatDevice.AirConditioners.Queries
{
    public class GetAllQuery
    {
        public class AirConditionerGetAllQuery
        {
            private readonly IAirConditionerRepository _repository;

            public AirConditionerGetAllQuery(IAirConditionerRepository repos)
            {
                _repository = repos;
            }

            public List<AirConditionerDto> Execute()
            {
                List<AirConditionerDto> result = new List<AirConditionerDto>();

                foreach (AirConditioner a in _repository.GetAll())
                {
                    if (a != null)
                        result.Add(AirConditionerMapper.ToDto(a));
                }
                return result;
            }
        }
    }
}
