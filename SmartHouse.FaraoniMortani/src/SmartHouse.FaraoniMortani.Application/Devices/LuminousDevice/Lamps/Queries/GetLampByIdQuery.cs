using SmartHouse.FaraoniMortani.Domain;
using SmartHouse.FaraoniMortani.Domain.LuminousDevices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Lamp Execute(Guid id)
        {
            return _lampRepository.GetById(id);
        }
    }
}
