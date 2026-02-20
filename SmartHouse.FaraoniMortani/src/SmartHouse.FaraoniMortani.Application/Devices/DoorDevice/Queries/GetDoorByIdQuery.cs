using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHouse.FaraoniMortani.Domain.Devices.DoorDevice;
using SmartHouse.FaraoniMortani.Domain.Devices.DoorDevice.Repositories;

namespace SmartHouse.FaraoniMortani.Application.Devices.Door.Queries
{
    public class GetDoorByIdQuery
    {
        public readonly IDoorRepository _doorRepository;

        public GetDoorByIdQuery(IDoorRepository doorRepository)
        {
            _doorRepository = doorRepository;
        }

        public Domain.Devices.DoorDevice.Door Execute(Guid id)
        {
            return _doorRepository.GetById(id);
        }
    }
}
