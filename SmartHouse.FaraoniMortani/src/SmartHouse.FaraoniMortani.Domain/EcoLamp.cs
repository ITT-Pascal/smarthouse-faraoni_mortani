using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Domain
{
    public class EcoLamp : AbstractLamp
    {
        public DateTime CurrentTime = DateTime.UtcNow;
        public int BrightnessLevel { get; private set; }
        public bool IsOn { get; private set; }


        public EcoLamp()
        {

        }

        public override void Switch()
        {
            IsOn = !IsOn;
        }


        public override void ChangeBrightness(int newBrightnessLevel)
        {

            if (IsOn)
            {
                if (newBrightnessLevel < 0 && newBrightnessLevel > 100)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else if (newBrightnessLevel == 0)
                {
                    IsOn = false;
                }
                else
                {
                    BrightnessLevel = newBrightnessLevel;
                }

            }

        }

        public void TurnOffAfterTime(DateTime initialTime, int minutes)
        {
            if (IsOn)
                if (CurrentTime - initialTime > TimeSpan.FromMinutes(minutes))
                {
                    Switch();
                }
            
        }

    }
}
