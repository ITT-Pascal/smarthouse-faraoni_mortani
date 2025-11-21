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
        /// This method turns on both lamps
        /// </summary>
        public void TurnBothLampsOn()
        {
            if(!Lamp1.IsOn)
                Lamp1.Switch();

            if(!Lamp2.IsOn)
                Lamp2.Switch();    
        }
        
        /// <summary>
        /// This method turns off both lamps
        /// </summary>
        public void TurnBothLampsOff()
        {
            if(Lamp1.IsOn)
                Lamp1.Switch();
            
            if(Lamp2.IsOn)
                Lamp2.Switch();  

        }

        /// <summary>
        /// This method turns the first lamp on
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
            if (!Lamp2.IsOn)
                Lamp2.Switch(); 
        }

        /// <summary>
        /// This method turns the first lamp off after a specified amount of time if the lamp is a EcoLamp
        /// </summary>
        /// <param name="currentTime"></param>
        /// <param name="minutes"></param>
        public void TurnFirstLampOffAfterTime(DateTime currentTime, int minutes)
        {
            if(Lamp1 is EcoLamp EcoLamp1)
            {
                EcoLamp1.TurnOffAfterTime(currentTime, minutes);
            }
        }

        /// <summary>
        /// This method turns the second lamp off after a specified amount of time if the lamp is a EcoLamp
        /// </summary>
        /// <param name="currentTime"></param>
        /// <param name="minutes"></param>
        public void TurnSecondLampOffAfterTime(DateTime currentTime, int minutes)
        {
            if(Lamp2 is EcoLamp EcoLamp2)
            {
                EcoLamp2.TurnOffAfterTime(currentTime, minutes);
            }
        }

        /// <summary>
        /// This method turns both lamps off after a specified amount of time if both lamps is a EcoLamp
        /// </summary>
        /// <param name="currentTime"></param>
        /// <param name="minutes"></param>
        public void TurnBothLampsOffAfterTime(DateTime currentTime, int minutes)
        {
            if(Lamp1 is EcoLamp EcoLamp1)
            {
                EcoLamp1.TurnOffAfterTime(currentTime, minutes);
            }
        }
    }
}
