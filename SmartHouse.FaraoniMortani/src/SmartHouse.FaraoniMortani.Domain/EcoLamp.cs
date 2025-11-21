using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Domain
{
    public class EcoLamp : AbstractLamp
    {
        public const int StandardMinimumIntensity = 0;
        public const int StandardMaximumIntensity = 70;
        public DateTime AccensionTime { get; set; }
        public int BrightnessLevel { get; private set; }

        public override int MinimumIntensity => StandardMinimumIntensity;
        public override int MaximumIntensity => StandardMaximumIntensity;

        public EcoLamp()
        {
            IsOn = false;
            Id = new Guid();
            BrightnessLevel = StandardMaximumIntensity;  
        }

        public EcoLamp(string name)
        {
            IsOn = false;
            Id = new Guid();
            Name = name;
            BrightnessLevel = StandardMaximumIntensity;
        }

        public override void Switch()
        {
            IsOn = !IsOn;

            if(IsOn)
                AccensionTime = DateTime.UtcNow;
        }


        public override void ChangeBrightness(int newBrightnessLevel)
        {

            if (IsOn)
                if (newBrightnessLevel < StandardMinimumIntensity || newBrightnessLevel > StandardMaximumIntensity)
                    throw new ArgumentOutOfRangeException();
                else if (newBrightnessLevel == StandardMinimumIntensity)
                    IsOn = false;
                else
                    BrightnessLevel = newBrightnessLevel;
        }

        /// <summary>
        /// It turns off the lamp when the difference of the AccensionTime and currentTime is higher than period of time choose by the user
        /// </summary>
        /// <param name="initialTime"></param>
        /// <param name="minutes"></param>
        public void TurnOffAfterTime(DateTime currentTime, int minutes)
        {

            if (IsOn)
                if (AccensionTime - currentTime > TimeSpan.FromMinutes(minutes))
                    Switch();  
        }
    }
}
