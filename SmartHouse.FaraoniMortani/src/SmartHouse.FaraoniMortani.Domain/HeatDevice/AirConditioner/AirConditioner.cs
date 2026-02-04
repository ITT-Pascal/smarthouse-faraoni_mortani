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
        public const double MinTemperature = 0;
        public const double DefaultTemperature = 20;
        public const double MaxTemperature = 40;
        public const double Step = 0.5;

        // Properties
        public Degree TargetTemperature { get; private set; }

        // Constructors
        public AirConditioner(string name): base(name)
        {
            TargetTemperature = new Degree(DefaultTemperature);
        }

        // Methods
        public void SetTemperatureToMin()
        {
            TargetTemperature.Value = MinTemperature;
        }

        public void SetTemperatureToDefault()
        {
            TargetTemperature.Value = DefaultTemperature;
        }

        public void SetTemperatureToMax()
        {
            TargetTemperature.Value = MaxTemperature;
        }

        public void SetCustomTemperature(double customTemperature)
        { 
            if (Status == DeviceStatus.On)
            {
                if (customTemperature < MinTemperature || customTemperature > MaxTemperature)
                    throw new ArgumentOutOfRangeException($"New temperature must be between {MinTemperature} and {MaxTemperature}");
                else
                    TargetTemperature.Value = customTemperature;
            }
            else
            {
                throw new Exception("Cannot change temperature because thermostat is turned off");
            }
        }

        /// <summary>
        /// Increases the target temperature by 0.5
        /// </summary>
        public void IncreaseTemperature()
        {
            if (Status == DeviceStatus.On)
            {
                if (TargetTemperature.Value + Step > MaxTemperature)
                    TargetTemperature.Value = MaxTemperature;
                else
                    TargetTemperature += Step;
            }
            else
            {
                throw new Exception("Cannot change temperature because thermostat is turned off");
            }
        }

        /// <summary>
        /// Decreases the target temerature by 0.5
        /// </summary>
        public void DecreaseTemperature()
        {
            if (Status == DeviceStatus.On)
            {
                if (TargetTemperature.Value - Step < MinTemperature)
                    TargetTemperature.Value = MinTemperature;
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


