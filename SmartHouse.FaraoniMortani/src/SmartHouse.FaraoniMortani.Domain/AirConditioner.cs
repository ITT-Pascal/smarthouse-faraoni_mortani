using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Domain
{
    public class AirConditioner : AbstractDevice
    {
        public const int MinTemperature = 5;
        public const int DefaultTemperature = 20;
        public const int MaxTemperature = 40; 
        public int CurrentTemperature { get; set; }
        public int TargetTemperature { get; set; }

        public AirConditioner(string name): base(name)
        {
            TargetTemperature = DefaultTemperature;
        }

        public void SetTemperatureToMin()
        {
            TargetTemperature = MinTemperature;
        }

        public void SetTemperatureToDefault()
        {
            TargetTemperature = DefaultTemperature;
        }

        public void SetTemperatureToMax()
        {
            TargetTemperature = MaxTemperature;
        }

        public void SetCustomTemperature(int customTemperature)
        {
            if (customTemperature < MinTemperature || customTemperature > MaxTemperature)
                throw new ArgumentOutOfRangeException($"Brightness level must be between {MinTemperature} and {MaxTemperature}.");
            else
                TargetTemperature = customTemperature;
        }

        
        public void HeatUp()
        {
            if (TargetTemperature < MaxTemperature)
                TargetTemperature += 1;

        }

        public void CoolDown()
        {
            if (TargetTemperature > MinTemperature)
                TargetTemperature -= 1;

        }

    }
}


