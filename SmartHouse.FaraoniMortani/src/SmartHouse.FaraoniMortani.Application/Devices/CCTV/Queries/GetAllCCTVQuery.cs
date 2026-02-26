using SmartHouse.FaraoniMortani.Domain.Devices.CCTV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Application.Devices.CCTV.Queries
{
    public class GetAllCCTVQuery
    {
        public ICCTVRepository _cctvRepository;

        public GetAllCCTVQuery(ICCTVRepository cctvRepository)
        {
            _cctvRepository = cctvRepository;
        }

        public List<Domain.Devices.CCTV.CCTV> Execute()
        {
            return _cctvRepository.GetAll();
        }
    }
}
