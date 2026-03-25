using SmartHouse.FaraoniMortani.Domain.Devices.LuminousDevices;
using SmartHouse.FaraoniMortani.Domain.Devices.LuminousDevices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Infrastructure.Repositories.Devices.LuminousDevice.Lamps.InMemory
{
    public class InMemoryLampRepository : ILampRepository
    {
        private readonly List<Lamp> _lamps;

        public InMemoryLampRepository()
        {
            _lamps = new List<Lamp>();
        }

        public List<Lamp> GetAll()
        {
            return _lamps;
        }

        public Lamp? GetById(Guid id)
        {
            Lamp? result = null;

            foreach (Lamp l in _lamps)
                if (l.Id == id)
                    result = l;

            return result;
        }

        public void Add(Lamp lamp)
        {
            if (lamp != null)
                _lamps.Add(lamp);
            else
                throw new ArgumentException("Lamp cannot be null");
        }

        public void Delete(Lamp lamp)
        {
            if (lamp != null)
                _lamps.Remove(lamp);
        }

        public void Update(Lamp newLamp)
        {
            // Not to do                           
        }
    }
}
