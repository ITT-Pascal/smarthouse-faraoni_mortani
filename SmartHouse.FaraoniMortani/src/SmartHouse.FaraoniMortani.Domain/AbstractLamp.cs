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

        public virtual int MinimumIntensity { get; set;}
        public virtual int MaximumIntensity { get; set; }

        /// <summary>
        /// Changes the accension status of the lamp
        /// </summary>
        public abstract void Switch();

        /// <summary>
        /// Sets the brightness of the lamp to a specified value
        /// </summary>
        /// <param name="newBrightnessLevel"></param>
        public abstract void ChangeBrightness(int newBrightnessLevel);

        /// <summary>
        /// Changes the brightness of the lamp by +5
        /// </summary>
        public abstract void Brighten();

        /// <summary>
        /// Changes the brightness of the lamp by -5
        /// </summary>
        public abstract void Dimmer();
    }
}
