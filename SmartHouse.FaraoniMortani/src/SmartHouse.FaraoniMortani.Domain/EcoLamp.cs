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
        private bool IsOn { get; set; }

        public override bool GetIsOn()
        {
            return IsOn;
        }

        public EcoLamp()
        {
            IsOn = false;
            BrightnessLevel = 50;
        }

        public override void Switch()
        {
            IsOn = !IsOn;
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

        public void TurnOffAfterTime(DateTime initialTime, int minutes)
        {
            if (IsOn)
                if (CurrentTime - initialTime > TimeSpan.FromMinutes(minutes))
                    Switch();
            
        }

    }
}
