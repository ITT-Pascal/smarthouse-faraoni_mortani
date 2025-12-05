using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Domain
{
    public class EcoLamp: AbstractLamp
    {
        // Constants
        public const int DefaultAutoOffMinutes = 60;
        public const int EcoModeBrightnessValue = 50;

        // Constructors
        public EcoLamp(Guid guid, string name) : base(guid, name) { }
        public EcoLamp(string name) : base(name) { }

        // Methods
		public void SetOnTime(DateTime time)
		{
			LastChangeTime = time;
		}

		public void SetEcoModeBrightness()
        {
            if (Status == DeviceStatus.On && BrightnessLevel > EcoModeBrightnessValue)
            {
                BrightnessLevel = EcoModeBrightnessValue;
            }
        }

        public void TurnOffAfterTime()
        {
            if (Status == DeviceStatus.On)
            {
                if (DateTime.Now - LastChangeTime > TimeSpan.FromMinutes(DefaultAutoOffMinutes))
                {
                    Switch();
                }
            }
        }
    }
}
