using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Domain
{
    public class LampRow
    {
        public List<AbstractLamp> lampRow;
        public LampRow(){}

        public void AddLamp(AbstractLamp lamp)
        {
            lampRow.Add(lamp);
        }

        public void AddLampInPosition(AbstractLamp lamp, int position)
        {
            lampRow.Insert(position, lamp);
        }

        public void RemoveLamp(Guid id)
        {
            lampRow.Remove(new Lamp(){ Id = id });
        }

        public void RemoveLamp(string name)
        {
            lampRow.Remove(new Lamp() { Name = name });
        }

        public void RemoveLampInPosition(int position)
        {
            lampRow.RemoveAt(position);
        }

        public void TurnOnSingleLamp(Guid id)
        {
            //TODO
        }

        public void TurnOnSingleLamp(string name)
        {
            //TODO
        }

        public void TurnOnAllLamps()
        {
            for(int index = 0; index<lampRow.Count; index++)
            {
                if (!lampRow[index].IsOn)
                lampRow[index].Switch();
            }
        }

        public void TurnOffSingleLamp(Guid id)
        {
           //TODO
        }

        public void TurnOffSingleLamp(string name)
        {
            //TODO
        }

        public void TurnOffAllLamps()
        {
            for (int index = 0; index < lampRow.Count; index++)
            {
                if (lampRow[index].IsOn)
                    lampRow[index].Switch();
            }
        }

        public void SetBrightnessForLamp(Guid id, int newBrightness)
        {
            //TODO
        }

        public void SetBrightnessForLamp(string name, int newBrightness)
        {
            //TODO
        }

        public void SetBrightnessForAllLamps(int newBrightness)
        {
            for (int index = 0; index < lampRow.Count; index++)
            {
                lampRow[index].ChangeBrightness(newBrightness);
            }
        }
    }
}
