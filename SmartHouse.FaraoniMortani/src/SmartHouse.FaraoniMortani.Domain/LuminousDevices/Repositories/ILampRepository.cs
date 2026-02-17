using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Domain.LuminousDevices.Repositories
{
    public interface ILampRepository
    {
        void Create(Lamp newLamp);  

        void Update(Lamp newLamp);

        void Delete(Lamp newLamp);

        Lamp GetById(Guid id);

        List<Lamp> GetAll();

        void Add(Lamp newLamp);
    }
}
