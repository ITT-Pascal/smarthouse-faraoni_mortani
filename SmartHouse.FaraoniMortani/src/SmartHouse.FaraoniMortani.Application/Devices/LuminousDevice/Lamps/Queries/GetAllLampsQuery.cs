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

        public List<Lamp> Execute()
        {
            return _lampRepository.GetAll();
        }
    }
}
