using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Domain
{
    public abstract class AbstractLamp : AbstractDevice
    {
        // Properties
        public int BrightnessLevel { get; protected set; }

        // Constants
        public const int MaxBrightnessLevel = 100;
        public const int MinBrightnessLevel = 0;


        // Constructors
        protected AbstractLamp() { }

        protected AbstractLamp(string name) : base(name)
        {
            BrightnessLevel = MaxBrightnessLevel;

        }
        public AbstractLamp(Guid guid, string name) : base(name, guid)
        {
            BrightnessLevel = MaxBrightnessLevel;

        }


        // Methods
        public virtual void Dimmer(int amount)
        {
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("Lamp is turned off");

            if (amount < 1)
                throw new ArgumentOutOfRangeException(nameof(amount), "Invalid Amount");

            BrightnessLevel = Math.Max(MinBrightnessLevel, BrightnessLevel - amount);

        }

        public virtual void Brighten(int amount)
        {
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("Lamp is turned off");

            if (amount < 1)
                throw new ArgumentOutOfRangeException(nameof(amount), "Invalid Amount");
            else if (BrightnessLevel + amount > MaxBrightnessLevel)
                BrightnessLevel = MaxBrightnessLevel;
            else BrightnessLevel += amount;
                

        }

        public virtual void SetBrightness(int levelOfBrightness)
        {
            if (levelOfBrightness < MinBrightnessLevel || levelOfBrightness > MaxBrightnessLevel)
                throw new ArgumentOutOfRangeException($"Brightness level must be between {MinBrightnessLevel} and {MaxBrightnessLevel}.");
            else if (levelOfBrightness == 0)
                Status = DeviceStatus.Off;
            else
                BrightnessLevel = levelOfBrightness;
            

        }
    }
}
