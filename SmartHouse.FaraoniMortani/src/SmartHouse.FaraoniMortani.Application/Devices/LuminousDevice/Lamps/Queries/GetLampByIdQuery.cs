using SmartHouse.FaraoniMortani.Application.Devices.LuminousDevice.Lamps.DTO;
using SmartHouse.FaraoniMortani.Application.Devices.LuminousDevice.Lamps.Mapper;
using SmartHouse.FaraoniMortani.Domain.Devices.LuminousDevices;
using SmartHouse.FaraoniMortani.Domain.Devices.LuminousDevices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Application.Devices.LuminousDevice.Lamps.Queries
{
    public class GetLampByIdQuery
    {
        public readonly ILampRepository _lampRepository;

        public GetLampByIdQuery(ILampRepository lampRepository)
        {
            _lampRepository = lampRepository;
        }

        public LampDto Execute(Guid id)
        {
            Lamp lamp = _lampRepository.GetById(id);

            if (lamp == null) throw new Exception("No lamp with specified id found");

            return LampMapper.ToDto(lamp);
        }
    }
}
