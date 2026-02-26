using SmartHouse.FaraoniMortani.Domain.Devices.CCTV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Domain.Devices.CCTV.Repositories
{
    public interface ICCTVRepository
    {
        void Update(CCTV newCCTV);
        void ChangeMode(CCTVMode newMode);
        void ChangeInclination(int newTiltDegrees);
        void IncreaseInclination();
        void DecreaseInclination();
        void ChangeZoom(double newZoom);
        CCTV GetById(Guid id);
        List<CCTV> GetAll();
    }
}
