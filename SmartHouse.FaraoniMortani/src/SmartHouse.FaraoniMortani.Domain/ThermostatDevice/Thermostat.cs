using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Domain
{
    public class Thermostat: AbstractDevice
    {
        public double Temperature { get; private set; }
        public const double DefaultTemperature = 15.0;

        public Thermostat(string name): base(name)
        {
            Temperature = DefaultTemperature;
        }

        public void IncreaseTemperature()
        {
            if(Status == DeviceStatus.On)
            {
                Temperature += 0.5;
            }
            else
            {
                throw new Exception("Cannot change temperature because thermostat is turned off");
            }
        }

        public void DecreaseTemperature()
        {
            if (Status == DeviceStatus.On)
            {
                Temperature -= 0.5;
            }
            else
            {
                throw new Exception("Cannot change temperature because thermostat is turned off");
            }
        }

        public void SetTemperature(double temperature)
        {
            if (Status == DeviceStatus.On)
            {
                Temperature = temperature;
            }
            else
            {
                throw new Exception("Cannot change temperature because thermostat is turned off");
            }
        }
    }
}
