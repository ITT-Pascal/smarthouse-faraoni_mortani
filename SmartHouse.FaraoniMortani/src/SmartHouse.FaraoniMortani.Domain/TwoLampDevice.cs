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

        public void TurnBothLightsOn()
        {
            if(Lamp1.GetIsOn())
                Lamp1.Switch();

            if(Lamp2.GetIsOn())
                Lamp2.Switch();    
        }
        
        public void TurnBothLightsOff()
        {
            if(!Lamp1.GetIsOn())
                Lamp1.Switch();
            
            if(!Lamp2.GetIsOn())
                Lamp2.Switch();  
        }

        public void TurnOnlyFirstLight()
        {
            if(!Lamp1.GetIsOn())
                Lamp1.Switch() ;

            if(Lamp2.GetIsOn())
                Lamp2.Switch(); 
        }

        public void TurnOnlySecondLight()
        {
            if (Lamp1.GetIsOn())
                Lamp1.Switch();

            if (!Lamp2.GetIsOn())
                Lamp2.Switch(); 
        }
    }
}
