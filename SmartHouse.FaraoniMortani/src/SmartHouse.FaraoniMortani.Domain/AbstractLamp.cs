using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Domain
{
    public abstract class AbstractLamp
    {
        public abstract void Switch();

        public abstract void ChangeBrightness(int newBrightnessLevel);
    }
}
