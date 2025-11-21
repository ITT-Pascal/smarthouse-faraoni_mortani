using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Domain
{
    public class Door
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public bool IsOpen;
        public bool IsLocked;

        public Door(string name)
        {
            Id = new Guid();
            Name = name;
            IsOpen = false;
            IsLocked = false;
        }

        public void OpenDoor()
        {
            if(IsOpen == false)
            {
                IsOpen = true;
            }         
        }

        public void CloseDoor()
        {
            if(IsOpen == true)
            {
                IsOpen = false;
            }
        }

        public void LockDoor()
        {
            if(IsLocked == false)
            {
                IsLocked = true;
            }
        }

        public void UnlockDoor()
        {
            if(IsLocked == true)
            {

            }
        }

        //TODO: Upgrade door
    }
}
