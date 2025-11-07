using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Domain
{
    public class EcoLamp : AbstractLamp
    {
        public override bool IsOn { get; set; }
        public DateTime AccensionTime { get; set; }
        public int BrightnessLevel { get; private set; }
        
        public EcoLamp()
        {
            IsOn = false;
            BrightnessLevel = 100;
            
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
                if (newBrightnessLevel < 0 || newBrightnessLevel > 100)
                    throw new ArgumentOutOfRangeException();
                else if (newBrightnessLevel == 0)
                    IsOn = false;
                else
                    BrightnessLevel = newBrightnessLevel;

        }

        /// <summary>
        /// 
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
