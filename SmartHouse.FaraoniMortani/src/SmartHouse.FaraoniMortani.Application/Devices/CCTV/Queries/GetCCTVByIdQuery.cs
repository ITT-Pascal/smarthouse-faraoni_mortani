using SmartHouse.FaraoniMortani.Domain.Devices.CCTV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Application.Devices.CCTV.Queries
{
    public class GetCCTVByIdQuery
    {
        public readonly ICCTVRepository _cctvRepository;

        public GetCCTVByIdQuery(ICCTVRepository cctvRepository)
        {
            _cctvRepository = cctvRepository;
        }

        public Domain.Devices.CCTV.CCTV Execute(Guid id)
        {
            return _cctvRepository.GetById(id);
        }
    }
}
