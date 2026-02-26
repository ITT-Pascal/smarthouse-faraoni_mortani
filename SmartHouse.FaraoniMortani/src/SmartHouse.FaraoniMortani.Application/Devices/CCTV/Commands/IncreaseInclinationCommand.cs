using SmartHouse.FaraoniMortani.Domain.Devices.CCTV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Application.Devices.CCTV.Commands
{
    public class IncreaseInclinationCommand
    {
        public readonly ICCTVRepository _cctvRepository;

        public IncreaseInclinationCommand(ICCTVRepository cctvRepository)
        {
            _cctvRepository = cctvRepository;
        }

        public void Execute(Guid cctvId)
        {
            Domain.Devices.CCTV.CCTV cctv = _cctvRepository.GetById(cctvId);

            if (cctv == null) throw new Exception("There is no lamp at this id");
            else
            {
                cctv.IncreaseInclination();
                _cctvRepository.Update(cctv);
            }
        }
    }
}
