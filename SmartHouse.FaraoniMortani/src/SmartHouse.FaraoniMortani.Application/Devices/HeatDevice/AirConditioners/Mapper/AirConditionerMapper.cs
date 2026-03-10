using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHouse.FaraoniMortani.Application.Devices.Abstractions.Mapper;
using SmartHouse.FaraoniMortani.Application.Devices.HeatDevice.AirConditioners.DTO;
using SmartHouse.FaraoniMortani.Application.Devices.HeatDevice.Thermostats.DTO;
using SmartHouse.FaraoniMortani.Domain.Devices.HeatDevice.AirConditioner;
using SmartHouse.FaraoniMortani.Domain.Devices.HeatDevice.ThermostatDevice;

namespace SmartHouse.FaraoniMortani.Application.Devices.HeatDevice.AirConditioners.Mapper
{
    public class AirConditionerMapper
    {
        public static AirConditionerDto ToDto(AirConditioner airConditioner)
        {
            return new AirConditionerDto
            {
                Id = airConditioner.Id,
                Name = airConditioner.Name,
                Status = DeviceStatusMapper.ToDto(airConditioner.Status),
                CreationTime = airConditioner.CreationTime,
                LastUpdateTime = airConditioner.LastChangeTime,
                TargetTemperature = airConditioner.TargetTemperature.Value,
            };
        }

        public static AirConditioner ToDomain(AirConditionerDto dto)
        {
            return new AirConditioner(
                dto.Id,
                dto.Name,
                DeviceStatusMapper.ToDomain(dto.Status),
                dto.TargetTemperature,
                dto.CreationTime,
                dto.LastUpdateTime
            );
        }
    }
}
