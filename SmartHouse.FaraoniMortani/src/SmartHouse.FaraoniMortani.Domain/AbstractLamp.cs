using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Domain
{
    public abstract class AbstractLamp
    {
        public bool IsOn { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }

        public abstract void Switch();
        public abstract void ChangeBrightness(int newBrightnessLevel);
    }
}
