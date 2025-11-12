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

        public AbstractLamp Lamp1 { get; private set; } 
        public AbstractLamp Lamp2 { get; private set; } 

        

        public TwoLampDevice(AbstractLamp lamp1, AbstractLamp lamp2)
        {
            Lamp1 = lamp1;
            Lamp2 = lamp2;
        }

        /// <summary>
        /// After the function, both lamps are on
        /// </summary>
        public void TurnBothLampsOn()
        {
            if(!Lamp1.IsOn)
                Lamp1.Switch();

            if(!Lamp2.IsOn)
                Lamp2.Switch();    
        }
        
        /// <summary>
        /// At the end of this function, both lamps are off
        /// </summary>
        public void TurnBothLampsOff()
        {
            if(Lamp1.IsOn)
                Lamp1.Switch();
            
            if(Lamp2.IsOn)
                Lamp2.Switch();  
        }

        /// <summary>
        /// Turns the first lamp on
        /// </summary>
        public void TurnOnlyFirstLampOn()
        {
            if(!Lamp1.IsOn)
                Lamp1.Switch() ;
        }

        /// <summary>
        /// Turns the second lamp on
        /// </summary>
        public void TurnOnlySecondLampOn()
        {
            if (Lamp1.IsOn)
                Lamp1.Switch(); 
        }

        // TODO: If there are two ecolamp, can activate TurnOffAfterTime


        public void TurnFirstLampOffAfterTime()
        {
            if(Lamp1 is EcoLamp)
            {
                Lamp1.TurnOffAfterTime();
            }

        }

        public void TurnSecondLampOffAfterTime()
        {
            if(Lamp2 is EcoLamp)
            {
                Lamp2.TurnOffAfterTime();
            }

        }


    }
}
