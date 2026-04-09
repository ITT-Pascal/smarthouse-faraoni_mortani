using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHouse.FaraoniMortani.Domain.Devices.HeatDevice.ThermostatDevice;

namespace SmartHouse.FaraoniMortani.Domain.Devices.HeatDevice.AirConditioner.Repositories
{
    public interface IAirConditionerRepository
    {
        void Add(AirConditioner airConditioner);
        void Update(AirConditioner airConditioner);
        void Delete(AirConditioner airConditioner);
        AirConditioner GetById(Guid id);
        List<AirConditioner> GetAll();
    }
}
