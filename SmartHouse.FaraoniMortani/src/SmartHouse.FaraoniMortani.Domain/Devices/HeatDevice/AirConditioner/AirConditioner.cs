using SmartHouse.FaraoniMortani.Domain.Devices.Abstractions;
using SmartHouse.FaraoniMortani.Domain.Devices.HeatDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Domain.Devices.HeatDevice.AirConditioner
{
    public class AirConditioner: AbstractDevice, IHeatDevice
    {
        // Properties
        public Degree TargetTemperature { get; private set; }

        // Constructors
        public AirConditioner(string name): base(name)
        {
            TargetTemperature = new Degree(Degree.Default);
        }

        // Methods
        public void SetTemperatureToMin()
        {
            TargetTemperature.Value = Degree.Min;
        }

        public void SetTemperatureToDefault()
        {
            TargetTemperature.Value = Degree.Default;
        }

        public void SetTemperatureToMax()
        {
            TargetTemperature.Value = Degree.Max;
        }

        public void SetCustomTemperature(double customTemperature)
        { 
            if (Status == DeviceStatus.On)
            {
                TargetTemperature = new Degree(customTemperature);
            }
            else
            {
                throw new Exception("Cannot change temperature because thermostat is turned off");
            }
        }

        public void IncreaseTemperature()
        {
            if (Status == DeviceStatus.On)
            {
                if (TargetTemperature.Value + Degree.Step > Degree.Max)
                    TargetTemperature.Value = Degree.Max;
                else
                    TargetTemperature.Value += Degree.Step;
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
                if (TargetTemperature.Value - Degree.Step < Degree.Min)
                    TargetTemperature.Value = Degree.Min;
                else
                    TargetTemperature -= Degree.Step;
            }
            else
            {
                throw new Exception("Cannot change temperature because thermostat is turned off");
            }
        }
    }
}


