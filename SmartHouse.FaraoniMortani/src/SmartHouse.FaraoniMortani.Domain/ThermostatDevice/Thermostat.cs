using SmartHouse.FaraoniMortani.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Domain
{
    public class Thermostat: AbstractDevice, IHeatDevice
    {
        // Properities
        public double Temperature { get; private set; }

        // Constants
        public const double DefaultTemperature = 15.0;
        public const double MaxTemperature = 40;
        public const double MinTemperature = 0;
        public const double Step = 0.5;

        // Constructor
        public Thermostat(string name): base(name)
        {
            Temperature = DefaultTemperature;
        }

        // Methods

        /// <summary>
        /// Increases temperature value by 0.5
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void IncreaseTemperature()
        {
            if(Status == DeviceStatus.On)
            {
                if (Temperature + Step > MaxTemperature)
                    Temperature = MaxTemperature;
                else
                    Temperature += Step;
            }
            else
            {
                throw new Exception("Cannot change temperature because thermostat is turned off");
            }
        }

        /// <summary>
        /// Decreases temperature value by 0.5 
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void DecreaseTemperature()
        {
            if (Status == DeviceStatus.On)
            {
				if (Temperature - Step < MinTemperature)
					Temperature = MinTemperature;
				else
					Temperature -= Step;
			}
            else
            {
                throw new Exception("Cannot change temperature because thermostat is turned off");
            }
        }

        public void SetCustomTemperature(double customTemperature)
        {
            if (Status == DeviceStatus.On)
            {
                if (customTemperature < MinTemperature || customTemperature > MaxTemperature)
                    throw new ArgumentOutOfRangeException($"New temperature must be between {MinTemperature} and {MaxTemperature}");
                else 
                    Temperature = customTemperature;
            }
            else
            {
                throw new Exception("Cannot change temperature because thermostat is turned off");
            }
        }

        public void SetTemperatureToMin()
        {
            Temperature = MinTemperature;
        }

        public void SetTemperatureToDefault()
        {
            Temperature = DefaultTemperature;
        }

        public void SetTemperatureToMax()
        {
            Temperature = MaxTemperature;
        }
    }
}
