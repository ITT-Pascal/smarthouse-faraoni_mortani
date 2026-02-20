using SmartHouse.FaraoniMortani.Domain.Devices.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Domain.Devices.LuminousDevices
{
    public abstract class AbstractLamp: AbstractDevice, ILuminousDevice
    {
        // Properties
        public Brightness BrightnessLevel { get; protected set; }

        // Constructors
        protected AbstractLamp() { }
        protected AbstractLamp(string name) : base(name)
        {
            BrightnessLevel = new Brightness(Brightness.Max);
        }
        protected AbstractLamp(Guid guid, string name) : base(name, guid)
        {
            BrightnessLevel = new Brightness(Brightness.Max);
        }


        // Methods
        public virtual void Dimmer(int amount)
        {
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("Lamp is turned off");

            if (amount < 1)
                throw new ArgumentOutOfRangeException(nameof(amount), "Invalid Amount");
            else if (BrightnessLevel.Value - amount < Brightness.Min)
                BrightnessLevel.Value = Brightness.Min;
            else BrightnessLevel.Value -= amount;
        }

        public virtual void Brighten(int amount)
        {
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("Lamp is turned off");

            if (amount < 1)
                throw new ArgumentOutOfRangeException(nameof(amount), "Invalid Amount");
            else if (BrightnessLevel.Value + amount > Brightness.Max)
                BrightnessLevel.Value = Brightness.Max;
            else BrightnessLevel.Value += amount;
        }

        public virtual void SetBrightness(Brightness levelOfBrightness)
        {
            if (levelOfBrightness.Value == 0)
                Status = DeviceStatus.Off;
            else
                BrightnessLevel = levelOfBrightness;
        }
    }
}
