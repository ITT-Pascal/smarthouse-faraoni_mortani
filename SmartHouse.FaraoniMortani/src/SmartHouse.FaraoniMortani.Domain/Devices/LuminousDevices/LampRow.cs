using SmartHouse.FaraoniMortani.Domain.Devices.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SmartHouse.FaraoniMortani.Domain.Devices.LuminousDevices
{
    public class LampRow
    {
        // Attributes
        public List<AbstractLamp> lampRow {  get; private set; }

        // Constructors
        public LampRow()
        {
            lampRow = new List<AbstractLamp>();
        }

        // Methods
        public void AddLamp(AbstractLamp lamp)
        {
            lampRow.Add(lamp);
        }

        public void AddLampInPosition(AbstractLamp lamp, int position)
        {
            if (position < 0)
            {
                throw new ArgumentException("Invalid position");
            }
            lampRow.Insert(position, lamp);
        }

        public void RemoveLamp(Guid id)
        {
            for(int i = 0; i < lampRow.Count; i++)
            {
                if (lampRow[i].Id == id)
                {
                    lampRow.Remove(lampRow[i]);
                    break;
                }
            }
        }

        public void RemoveLamp(string name)
        {
            for (int i = 0; i < lampRow.Count; i++)
            {
                if (lampRow[i].Name == name)
                {
                    lampRow.Remove(lampRow[i]);
                    break;
                }
            }
        }

        public void RemoveLampInPosition(int position)
        {
            if(position < 0 || position >= lampRow.Count)
            {
                throw new ArgumentException("Invalid position");
            }
            else
            {
                lampRow.RemoveAt(position);
            }  
        }

        public void TurnOnSingleLamp(Guid id)
        {
            for (int i = 0; i < lampRow.Count(); i++)
            {
                if (lampRow[i].Id == id)
                {
                    if (lampRow[i].Status == DeviceStatus.Off)
                    {
                        lampRow[i].Toggle();
                    }
                }
                else
                {
                    if (i == lampRow.Count() - 1)
                    {
                        throw new ArgumentException("No lamp with given id was found");
                    }
                }
            }
        }

        public void TurnOnSingleLamp(string name)
        {
            for(int i = 0; i < lampRow.Count(); i++)
            {
                if (lampRow[i].Name == name)
                {
                    if(lampRow[i].Status == DeviceStatus.Off)
                    {
                        lampRow[i].Toggle();
                    }
                }
                else
                {
                    if(i == lampRow.Count() - 1)
                    {
                        throw new ArgumentException("No lamp with given name was found");
                    }
                }
            }
        }

        public void TurnOnAllLamps()
        {
            for(int i = 0; i<lampRow.Count; i++)
            {
                if (lampRow[i].Status == DeviceStatus.Off)
                lampRow[i].Toggle();
            }
        }

        public void TurnOffSingleLamp(Guid id)
        {
            for (int i = 0; i < lampRow.Count(); i++)
            {
                if (lampRow[i].Id == id)
                {
                    if (lampRow[i].Status == DeviceStatus.On)
                    {
                        lampRow[i].Toggle();
                    }
                }
                else
                {
                    if (i == lampRow.Count() - 1)
                    {
                        throw new ArgumentException("No lamp with given id was found");
                    }
                }
            }
        }

        public void TurnOffSingleLamp(string name)
        {
            for (int i = 0; i < lampRow.Count(); i++)
            {
                if (lampRow[i].Name == name)
                {
                    if (lampRow[i].Status == DeviceStatus.On)
                    {
                        lampRow[i].Toggle();
                    }
                }
                else
                {
                    if (i == lampRow.Count() - 1)
                    {
                        throw new ArgumentException("No lamp with given name was found");
                    }
                }
            }
        }

        public void TurnOffAllLamps()
        {
            for (int index = 0; index < lampRow.Count; index++)
            {
                if (lampRow[index].Status == DeviceStatus.On)
                    lampRow[index].Toggle();
            }
        }

        public void SetBrightnessForLamp(Guid id, Brightness newBrightness)
        {
			for (int i = 0; i < lampRow.Count(); i++)
			{
				if (lampRow[i].Id == id)
				{
					if (lampRow[i].Status == DeviceStatus.On)
						lampRow[i].SetBrightness(newBrightness);
					else
					{
						lampRow[i].Toggle();
						lampRow[i].SetBrightness(newBrightness);
					}

				}
				else
				{
					if (i == lampRow.Count() - 1)
					{
						throw new ArgumentException("No lamp with given id was found");
					}
				}
			}
        }

        public void SetBrightnessForLamp(string name, Brightness newBrightness)
        {
            for (int i = 0; i < lampRow.Count(); i++)
            {
                if (lampRow[i].Name == name)
                {
                    if (lampRow[i].Status == DeviceStatus.On)
                        lampRow[i].SetBrightness(newBrightness);
                    else
                    {
                        lampRow[i].Toggle();
                        lampRow[i].SetBrightness(newBrightness);
                    }

                }
                else
                {
                    if (i == lampRow.Count() - 1)
                    {
                        throw new ArgumentException("No lamp with given id was found");
                    }
                }
            }
        }

        public void SetBrightnessForAllLamps(Brightness newBrightness)
        {
            for (int i = 0; i < lampRow.Count; i++)
            {
                lampRow[i].SetBrightness(newBrightness);
            }
        }
    }
}
