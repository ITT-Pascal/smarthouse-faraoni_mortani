using SmartHouse.FaraoniMortani.Domain.Devices.Abstractions;
using SmartHouse.FaraoniMortani.Domain.Devices.HeatDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Domain.Devices.HeatDevice.ThermostatDevice
{
    public class Thermostat: AbstractDevice, IHeatDevice
    {
        private DeviceStatus deviceStatus;
        private double temperature;
        private DateTime lastUpdateTime;

        // Properities
        public Degree Temperature { get; private set; }

        // Constructor
        public Thermostat(string name): base(name)
        {
            Temperature = new Degree(Degree.Default);
        }

        public Thermostat(Guid id, string name, DeviceStatus deviceStatus, double temperature, DateTime creationTime, DateTime lastUpdateTime)
        {
            Id = id;
            Name = name;
            this.deviceStatus = deviceStatus;
            this.temperature = temperature;
            CreationTime = creationTime;
            this.lastUpdateTime = lastUpdateTime;
        }

        // Methods
        public void IncreaseTemperature()
        {
            if(Status == DeviceStatus.On)
            {
                if (Temperature.Value + Degree.Step > Degree.Max)
                    Temperature.Value = Degree.Max;
                else
                    Temperature += Degree.Step;
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
				if (Temperature.Value - Degree.Step < Degree.Min)
					Temperature.Value = Degree.Min;
				else
					Temperature -= Degree.Step;
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
                Temperature = new Degree(customTemperature);
            }
            else
            {
                throw new Exception("Cannot change temperature because thermostat is turned off");
            }
        }

        public void SetTemperatureToMin()
        {
            Temperature.Value = Degree.Min;
        }

        public void SetTemperatureToDefault()
        {
            Temperature.Value = Degree.Default;
        }

        public void SetTemperatureToMax()
        {
            Temperature.Value = Degree.Max;
        }
    }
}
