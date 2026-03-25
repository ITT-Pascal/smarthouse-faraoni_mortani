using SmartHouse.FaraoniMortani.Domain.Devices.LuminousDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Domain.Devices.DoorDevice.Repositories
{
    public interface IDoorRepository
    {
        void Add(Door newDoor);
        void Delete(Door newDoor);
        void Update(Door newDoor);
        Door GetById(Guid id);
        List<Door> GetAll();
    }
}
