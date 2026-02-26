using SmartHouse.FaraoniMortani.Application.Devices.Abstractions.Mapper;
using SmartHouse.FaraoniMortani.Application.Devices.HeatDevice.Thermostats.DTO;
using SmartHouse.FaraoniMortani.Domain.Devices.HeatDevice.ThermostatDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Application.Devices.HeatDevice.Thermostats.Mapper
{
    public class ThermostatMapper
    {
        public static ThermostatDto ToDto(Thermostat thermostat)
        {
            return new ThermostatDto
            {
                Id = thermostat.Id,
                Name = thermostat.Name,
                Status = DeviceStatusMapper.ToDto(thermostat.Status),
                CreationTime = thermostat.CreationTime,
                LastUpdateTime = thermostat.LastChangeTime,
                Temperature = thermostat.Temperature.Value,
            };
        }

        public static Thermostat ToDomain(ThermostatDto dto)
        {
            return new Thermostat(
                dto.Id,
                dto.Name,
                DeviceStatusMapper.ToDomain(dto.Status),
                dto.Temperature,
                dto.CreationTime,
                dto.LastUpdateTime
                );
        }
    }
}
