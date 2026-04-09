using SmartHouse.FaraoniMortani.Application.Devices.DoorDevice.DTO;
using SmartHouse.FaraoniMortani.Application.Devices.DoorDevice.Mapper;
using SmartHouse.FaraoniMortani.Domain.Devices.DoorDevice.Repositories;
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

        public List<DoorDto> Execute()
        {
            var list = new List<DoorDto>();

            foreach (var door in _doorRepository.GetAll())
            {
                list.Add(DoorMapper.ToDto(door));
            }

            return list;
        }
    }
}
