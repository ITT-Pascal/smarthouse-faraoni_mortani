using System;
using System.Collections.Generic;
using System.Linq;
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

        public void RemoveLamp(int index)
        {
            lampRow.RemoveAt(index);
        }

        public void TurnOnSingleLamp(int index)
        {
            if (!lampRow[index].IsOn)
            {
                lampRow[index].Switch();
            }
        }

        public void TurnOnAllLamps()
        {
            for(int index = 0; index<lampRow.Count; index++)
            {
                if (!lampRow[index].IsOn)
                lampRow[index].Switch();
            }
        }

        public void TurnOffSingleLamp(int index)
        {
            if (lampRow[index].IsOn)
            {
                lampRow[index].Switch();
            }
        }

        public void TurnOffAllLamps()
        {
            for (int index = 0; index < lampRow.Count; index++)
            {
                if (lampRow[index].IsOn)
                    lampRow[index].Switch();
            }
        }
    }
}
