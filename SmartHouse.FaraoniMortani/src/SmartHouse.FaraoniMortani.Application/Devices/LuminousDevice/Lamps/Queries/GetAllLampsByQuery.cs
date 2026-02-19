using SmartHouse.FaraoniMortani.Domain;
using SmartHouse.FaraoniMortani.Domain.LuminousDevices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Application.Devices.LuminousDevice.Lamps.Queries
{
    public class GetAllLampsByQuery
    {
        public ILampRepository _lampRepository;

        public GetAllLampsByQuery(ILampRepository lampRepository)
        {
            _lampRepository = lampRepository;
        }

        public List<Lamp> Execute()
        {
            return _lampRepository.GetAll();
        }
    }
}
