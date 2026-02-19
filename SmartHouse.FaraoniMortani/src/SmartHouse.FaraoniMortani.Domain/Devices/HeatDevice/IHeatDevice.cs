using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Domain.Devices.HeatDevice
{
    public interface IHeatDevice
    {
        void SetTemperatureToMin();
        void SetTemperatureToDefault();
        void SetTemperatureToMax();
        void SetCustomTemperature(double customTemperature);
        void IncreaseTemperature();
        void DecreaseTemperature();
    }
}
