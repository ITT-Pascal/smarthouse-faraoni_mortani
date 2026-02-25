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
        public readonly List<Lamp> _lamps;

        public InMemoryLampRepository()
        {
            _lamps = new List<Lamp>
            {
                new Lamp("Stefano"),
                new Lamp("Fede"),
                new Lamp("Piazza")
            };
        }


        public void Add(Lamp newLamp)
        {
            throw new NotImplementedException();
        }

        public void Create(Lamp newLamp)
        {
            throw new NotImplementedException();
        }

        public void Delete(Lamp newLamp)
        {
            throw new NotImplementedException();
        }

        public List<Lamp> GetAll()
        {
            throw new NotImplementedException();
        }

        public Lamp GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(Lamp newLamp)
        {
            throw new NotImplementedException();
        }
    }
}
