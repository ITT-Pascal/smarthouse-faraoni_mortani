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

        // TODO: If there are two ecolamp, can activate TurnOffAfterTime

        public TwoLampDevice(AbstractLamp lamp1, AbstractLamp lamp2)
        {
            Lamp1 = lamp1;
            Lamp2 = lamp2;
        }

        public void TurnBothLampsOn()
        {
            if(!Lamp1.IsOn)
                Lamp1.Switch();

            if(!Lamp2.IsOn)
                Lamp2.Switch();    
        }
        
        public void TurnBothLampsOff()
        {
            if(Lamp1.IsOn)
                Lamp1.Switch();
            
            if(Lamp2.IsOn)
                Lamp2.Switch();  
        }

        public void TurnOnlyFirstLampOn()
        {
            if(!Lamp1.IsOn)
                Lamp1.Switch() ;

            if(Lamp2.IsOn)
                Lamp2.Switch(); 
        }

        /// <summary>
        /// 
        /// </summary>
        public void TurnOnlySecondLampOn()
        {
            if (Lamp1.IsOn)
                Lamp1.Switch();

            if (!Lamp2.IsOn)
                Lamp2.Switch(); 
        }
    }
}
