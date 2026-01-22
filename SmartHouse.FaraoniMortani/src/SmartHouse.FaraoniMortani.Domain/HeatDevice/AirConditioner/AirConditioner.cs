using SmartHouse.FaraoniMortani.Domain.HeatDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Domain.HeatDevice.AirConditioner
{
    public class AirConditioner: AbstractDevice, IHeatDevice
    {
        // Constants
        public const double MinTemperature = 5;
        public const double DefaultTemperature = 20;
        public const double MaxTemperature = 40;
        public const double Step = 1;

        // Properties
        public double TargetTemperature { get; private set; }

        // Constructors
        public AirConditioner(string name): base(name)
        {
            TargetTemperature = DefaultTemperature;
        }

        // Methods
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

        public void SetCustomTemperature(double customTemperature)
        {
            if (Status == DeviceStatus.On)
            {
                if (customTemperature < MinTemperature || customTemperature > MaxTemperature)
                    throw new ArgumentOutOfRangeException($"New temperature must be between {MinTemperature} and {MaxTemperature}");
                else
                    TargetTemperature = customTemperature;
            }
            else
            {
                throw new Exception("Cannot change temperature because thermostat is turned off");
            }
        }

        /// <summary>
        /// Increases the target temperature by one
        /// </summary>
        public void IncreaseTemperature()
        {
            if (Status == DeviceStatus.On)
            {
                if (TargetTemperature + Step > MaxTemperature)
                    TargetTemperature = MaxTemperature;
                else
                    TargetTemperature += Step;
            }
            else
            {
                throw new Exception("Cannot change temperature because thermostat is turned off");
            }
        }

        /// <summary>
        /// Decreases the target temerature by one
        /// </summary>
        public void DecreaseTemperature()
        {
            if (Status == DeviceStatus.On)
            {
                if (TargetTemperature - Step < MinTemperature)
                    TargetTemperature = MinTemperature;
                else
                    TargetTemperature -= Step;
            }
            else
            {
                throw new Exception("Cannot change temperature because thermostat is turned off");
            }
        }
    }
}


