using SmartHouse.FaraoniMortani.Domain.Devices.DoorDevice.Repositories;
using SmartHouse.FaraoniMortani.Domain.Devices.LuminousDevices;
using SmartHouse.FaraoniMortani.Domain.Devices.LuminousDevices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Application.Devices.Door.Queries
{
    public class GetAllDoorsQuery
    {
        public IDoorRepository _doorRepository;

        public GetAllDoorsQuery(IDoorRepository doorRepository)
        {
            _doorRepository = doorRepository;
        }

        public List<Domain.Devices.DoorDevice.Door> Execute()
        {
            return _doorRepository.GetAll();
        }
    }
}
