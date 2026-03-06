using SmartHouse.FaraoniMortani.Application.Devices.LuminousDevice.Lamps.DTO;
using SmartHouse.FaraoniMortani.Application.Devices.LuminousDevice.Lamps.Mapper;
using SmartHouse.FaraoniMortani.Domain.Devices.LuminousDevices;
using SmartHouse.FaraoniMortani.Domain.Devices.LuminousDevices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Application.Devices.LuminousDevice.Lamps.Queries
{
    public class GetAllLampsQuery
    {
        public ILampRepository _lampRepository;

        public GetAllLampsQuery(ILampRepository lampRepository)
        {
            _lampRepository = lampRepository;
        }

        public List<LampDto> Execute()
        {
            var result = new List<LampDto>();

            foreach(var l in _lampRepository.GetAll())
            {
                result.Add(LampMapper.ToDto(l));
            }

            return result;
        }
    }
}
