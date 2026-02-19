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
        //TODO: implement Brightness record 

        // Properties
        public Brightness BrightnessLevel { get; protected set; }

        // Constants
        public const int MaxBrightnessLevel = 100;
        public const int MinBrightnessLevel = 0;


        // Constructors
        protected AbstractLamp() { }
        protected AbstractLamp(string name) : base(name)
        {
            BrightnessLevel = new Brightness(MaxBrightnessLevel);
        }
        protected AbstractLamp(Guid guid, string name) : base(name, guid)
        {
            BrightnessLevel = new Brightness(MaxBrightnessLevel);
        }


        // Methods
        public virtual void Dimmer(int amount)
        {
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("Lamp is turned off");

            if (amount < 1)
                throw new ArgumentOutOfRangeException(nameof(amount), "Invalid Amount");
            else if (BrightnessLevel.Value - amount < MinBrightnessLevel)
                BrightnessLevel.Value = MinBrightnessLevel;
            else BrightnessLevel.Value -= amount;
        }

        public virtual void Brighten(int amount)
        {
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("Lamp is turned off");

            if (amount < 1)
                throw new ArgumentOutOfRangeException(nameof(amount), "Invalid Amount");
            else if (BrightnessLevel.Value + amount > MaxBrightnessLevel)
                BrightnessLevel.Value = MaxBrightnessLevel;
            else BrightnessLevel.Value += amount;
        }

        public virtual void SetBrightness(Brightness levelOfBrightness)
        {
            if (levelOfBrightness.Value < MinBrightnessLevel || levelOfBrightness.Value > MaxBrightnessLevel)
                throw new ArgumentOutOfRangeException($"Brightness level must be between {MinBrightnessLevel} and {MaxBrightnessLevel}.");
            else if (levelOfBrightness.Value == 0)
                Status = DeviceStatus.Off;
            else
                BrightnessLevel.Value = levelOfBrightness.Value;
        }
    }
}
