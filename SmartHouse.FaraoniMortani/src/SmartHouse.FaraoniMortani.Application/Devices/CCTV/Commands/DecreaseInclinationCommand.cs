using SmartHouse.FaraoniMortani.Domain.Devices.CCTV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Application.Devices.CCTV.Commands
{
    public class DecreaseInclinationCommand
    {
        public readonly ICCTVRepository _cctvRepository;

        public DecreaseInclinationCommand(ICCTVRepository cctvRepository)
        {
            _cctvRepository = cctvRepository;
        }

        public void Execute(Guid cctvId)
        {
            Domain.Devices.CCTV.CCTV cctv = _cctvRepository.GetById(cctvId);

            if (cctv == null) throw new Exception("There is no lamp at this id");
            else
            {
                cctv.DecreaseInclination();
                _cctvRepository.Update(cctv);
            }
        }
    }
}
