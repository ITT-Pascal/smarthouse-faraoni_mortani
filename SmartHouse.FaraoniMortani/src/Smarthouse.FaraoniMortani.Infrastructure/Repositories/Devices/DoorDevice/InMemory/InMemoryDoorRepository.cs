using SmartHouse.FaraoniMortani.Domain.Devices.DoorDevice;
using SmartHouse.FaraoniMortani.Domain.Devices.DoorDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smarthouse.FaraoniMortani.Infrastructure.Repositories.Devices.DoorDevice.InMemory
{
    public class InMemoryDoorRepository: IDoorRepository
    {
        private readonly List<Door> _doors;

        public InMemoryDoorRepository()
        {
            _doors = new List<Door>();
        }

        public List<Door> GetAll()
        {
            return _doors;
        }

        public Door? GetById(Guid id)
        {
            Door? result = null;

            foreach (Door d in _doors)
                if (d.Id == id)
                    result = d;

            return result;
        }

        public void Add(Door door)
        {
            if (door != null)
                _doors.Add(door);
            else
                throw new ArgumentException("Door cannot be null");
        }

        public void Delete(Door door)
        {
            if (door != null)
                _doors.Remove(door);
        }

        public void Update(Door newDoor)
        {
            // not to do
        }
    }
}
