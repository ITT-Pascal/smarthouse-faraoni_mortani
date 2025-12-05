using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SmartHouse.FaraoniMortani.Domain
{
    public class LampRow
    {
        // Attributes
        public List<AbstractLamp> lampRow {  get; set; }

        // Constructors
        public LampRow()
        {
            lampRow = new List<AbstractLamp>();
        }

        // Methods
        /// <summary>
        /// This method adds a lamp into the row
        /// </summary>
        /// <param name="lamp"></param>
        public void AddLamp(AbstractLamp lamp)
        {
            lampRow.Add(lamp);
        }

        /// <summary>
        /// This method adds a lamp in a specified position into the row
        /// </summary>
        /// <param name="lamp"></param>
        /// <param name="position"></param>
        public void AddLampInPosition(AbstractLamp lamp, int position)
        {
            if (position < 0)
            {
                throw new ArgumentException("Invalid position");
            }
            lampRow.Insert(position, lamp);
        }

        /// <summary>
        /// This method removes a lamp with a specified id from the row
        /// </summary>
        /// <param name="id"></param>
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

        /// <summary>
        /// This method removes a lamp with a specified name from the row
        /// </summary>
        /// <param name="name"></param>
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

        /// <summary>
        /// This method removes a lamp located in a specified position from the row
        /// </summary>
        /// <param name="position"></param>
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

        /// <summary>
        /// This method turns on a lamp with a specified id
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="ArgumentException"></exception>
        public void TurnOnSingleLamp(Guid id)
        {
            for (int i = 0; i < lampRow.Count(); i++)
            {
                if (lampRow[i].Id == id)
                {
                    if (lampRow[i].Status == DeviceStatus.Off)
                    {
                        lampRow[i].Switch();
                    }
                }
                else
                {
                    if (i == (lampRow.Count() - 1))
                    {
                        throw new ArgumentException("No lamp with given id was found");
                    }
                }
            }
        }

        /// <summary>
        /// This method turns on a lamp with a specified name
        /// </summary>
        /// <param name="name"></param>
        /// <exception cref="ArgumentException"></exception>
        public void TurnOnSingleLamp(string name)
        {
            for(int i = 0; i < lampRow.Count(); i++)
            {
                if (lampRow[i].Name == name)
                {
                    if(lampRow[i].Status == DeviceStatus.Off)
                    {
                        lampRow[i].Switch();
                    }
                }
                else
                {
                    if(i == (lampRow.Count() - 1))
                    {
                        throw new ArgumentException("No lamp with given name was found");
                    }
                }
            }
        }

        /// <summary>
        /// This method turns all the lamps in the row on(if they are not already turned on)
        /// </summary>
        public void TurnOnAllLamps()
        {
            for(int i = 0; i<lampRow.Count; i++)
            {
                if (lampRow[i].Status == DeviceStatus.Off)
                lampRow[i].Switch();
            }
        }

        /// <summary>
        /// This method turns off a lamp with a specified id
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="ArgumentException"></exception>
        public void TurnOffSingleLamp(Guid id)
        {
            for (int i = 0; i < lampRow.Count(); i++)
            {
                if (lampRow[i].Id == id)
                {
                    if (lampRow[i].Status == DeviceStatus.On)
                    {
                        lampRow[i].Switch();
                    }
                }
                else
                {
                    if (i == (lampRow.Count() - 1))
                    {
                        throw new ArgumentException("No lamp with given id was found");
                    }
                }
            }
        }

        /// <summary>
        /// This method turns off a lamp with a specified name
        /// </summary>
        /// <param name="name"></param>
        /// <exception cref="ArgumentException"></exception>
        public void TurnOffSingleLamp(string name)
        {
            for (int i = 0; i < lampRow.Count(); i++)
            {
                if (lampRow[i].Name == name)
                {
                    if (lampRow[i].Status == DeviceStatus.On)
                    {
                        lampRow[i].Switch();
                    }
                }
                else
                {
                    if (i == (lampRow.Count() - 1))
                    {
                        throw new ArgumentException("No lamp with given name was found");
                    }
                }
            }
        }

        /// <summary>
        /// This method turns all the lamps in the row off(if they are not already turned off)
        /// </summary>
        public void TurnOffAllLamps()
        {
            for (int index = 0; index < lampRow.Count; index++)
            {
                if (lampRow[index].Status == DeviceStatus.On)
                    lampRow[index].Switch();
            }
        }

        /// <summary>
        /// This method sets the brightness of a lamp with a specified id to a specified value
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newBrightness"></param>
        /// <exception cref="ArgumentException"></exception>
        public void SetBrightnessForLamp(Guid id, int newBrightness)
        {
            if (newBrightness < 0 || newBrightness > 100)
                throw new ArgumentOutOfRangeException("New brightness must be between 0 and 100");
            else
            {
				for (int i = 0; i < lampRow.Count(); i++)
				{
					if (lampRow[i].Id == id)
					{
						if (lampRow[i].Status == DeviceStatus.On)
							lampRow[i].SetBrightness(newBrightness);
						else
						{
							lampRow[i].Switch();
							lampRow[i].SetBrightness(newBrightness);
						}

					}
					else
					{
						if (i == (lampRow.Count() - 1))
						{
							throw new ArgumentException("No lamp with given id was found");
						}
					}
				}
			}
        }

        /// <summary>
        /// This method sets the bightness of a lamp with a specified name to a specified value
        /// </summary>
        /// <param name="name"></param>
        /// <param name="newBrightness"></param>
        /// <exception cref="ArgumentException"></exception>
        public void SetBrightnessForLamp(string name, int newBrightness)
        {
			if (newBrightness < 0 || newBrightness > 100)
				throw new ArgumentOutOfRangeException("New brightness must be between 0 and 100");
			else
			{
				for (int i = 0; i < lampRow.Count(); i++)
				{
					if (lampRow[i].Name == name)
					{
						if (lampRow[i].Status == DeviceStatus.On)
							lampRow[i].SetBrightness(newBrightness);
						else
						{
							lampRow[i].Switch();
							lampRow[i].SetBrightness(newBrightness);
						}

					}
					else
					{
						if (i == (lampRow.Count() - 1))
						{
							throw new ArgumentException("No lamp with given id was found");
						}
					}
				}
			}
		}

        /// <summary>
        /// This method sets the brightness of all lamps to a specified value
        /// </summary>
        /// <param name="newBrightness"></param>
        public void SetBrightnessForAllLamps(int newBrightness)
        {
            for (int i = 0; i < lampRow.Count; i++)
            {
                lampRow[i].SetBrightness(newBrightness);
            }
        }
    }
}
