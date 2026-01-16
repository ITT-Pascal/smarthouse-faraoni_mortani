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
        // Properties
        public AbstractLamp Lamp1 { get; private set; }
        public AbstractLamp Lamp2 { get; private set; }
       
        // Constructors
        public TwoLampDevice(AbstractLamp lamp1, AbstractLamp lamp2)
        {
            Lamp1 = lamp1;
            Lamp2 = lamp2;
        }

        // Methods
        public void TurnOnOneLamp(AbstractLamp currentLamp)
        {
            if (currentLamp == Lamp1 || currentLamp == Lamp2)
            {
                if(currentLamp.Status == DeviceStatus.Off)
                {
                    currentLamp.Toggle();
                }
            }         
        }

        public void TurnOffOneLamp(AbstractLamp currentLamp)
        {
            if (currentLamp == Lamp1 || currentLamp == Lamp2)
            {
                if(currentLamp.Status == DeviceStatus.On)
                {
                    currentLamp.Toggle();
                }
            }               
        }

        public void TurnBothOn()
        {
            if (Lamp1.Status == DeviceStatus.Off || Lamp2.Status == DeviceStatus.Off)
            {
                Lamp1.Toggle();
                Lamp2.Toggle();
            }
        }

        public void TurnBothOff()
        {
            if(Lamp1.Status == DeviceStatus.On || Lamp2.Status == DeviceStatus.On)
            {
                Lamp1.Toggle();
                Lamp2.Toggle();
            }
        }

        public void SetBrightnessForSingleLamp(AbstractLamp currentLamp, int newBrightness)
        {
            if (currentLamp == Lamp1 || currentLamp == Lamp2)
                currentLamp.SetBrightness(newBrightness);
        }

        public void SetBrightnessForBothLamps(int newBrightness)
        {
            Lamp1.SetBrightness(newBrightness);
            Lamp2.SetBrightness(newBrightness);
        }

        public void SetOneEcoLampBrightnessToEco(AbstractLamp currentLamp)
        {
            if (currentLamp == Lamp1 || currentLamp == Lamp2)
            {
                if (currentLamp is EcoLamp ecoLamp1)
                {
                    ecoLamp1.Toggle();
					ecoLamp1.SetEcoModeBrightness();
				}
                    
                else if(currentLamp is EcoLamp ecoLamp2)
                {
                    ecoLamp2.Toggle();
					ecoLamp2.SetEcoModeBrightness();
				}
                    
            }
        }

        public void SetBothEcoLampsBrightnessToEco()
        {
            if (Lamp1 is EcoLamp ecoLamp1)
            {
                ecoLamp1.Toggle();
                ecoLamp1.SetEcoModeBrightness();
            }
            if (Lamp2 is EcoLamp ecoLamp2)
            {
                ecoLamp2.Toggle();
                ecoLamp2.SetEcoModeBrightness();
            }
        }

        public void TurnOneEcoLampOffAfterTime(AbstractLamp currentLamp)
        {
            if (currentLamp == Lamp1 || currentLamp == Lamp2)
            {
                if (currentLamp is EcoLamp ecoLamp1)
                {
                    ecoLamp1.TurnOffAfterTime();
                }
            }
        }

        public void TurnBothEcoLampsOffAfterTime()
        {
            if (Lamp1 is EcoLamp ecoLamp1)
            {
                ecoLamp1.TurnOffAfterTime();
            }
            if (Lamp2 is EcoLamp ecoLamp2)
            {
                ecoLamp2.TurnOffAfterTime();
            }
        }
    }
}
