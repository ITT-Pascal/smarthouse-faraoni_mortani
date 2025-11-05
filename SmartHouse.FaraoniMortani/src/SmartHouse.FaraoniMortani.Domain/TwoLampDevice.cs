using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace SmartHouse.FaraoniMortani.Domain
{
    public class TwoLampDevice
    {
        // TODO: Complete TwoLampDevice

        public AbstractLamp Lamp1 { get; private set; } 
        public AbstractLamp Lamp2 { get; private set; } 

        public TwoLampDevice(AbstractLamp lamp1, AbstractLamp lamp2)
        {
            

        }

        public void TurnBothOn()
        {
            if(Lamp1.IsOn)
            {
                Lamp1.Switch();
            }

            if(Lamp2.IsOn)
            {
                Lamp2.Switch();
            }
        }
        
        public void TurnBothOff()
        {
            if(!Lamp1.IsOn)
            {
                Lamp1.Switch();
            }

            if(!Lamp2.IsOn)
            {
                Lamp2.Switch();
            }
        }
    }
}
