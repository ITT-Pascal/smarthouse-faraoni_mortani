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
        public string Password { get; private set; }

        public Door(string name, string password)
        {
            Id = new Guid();
            Name = name;
            IsOpen = false;
            IsLocked = false;
            Password = password;
        }

        public void OpenDoor()
        {
            if (IsOpen == false)
            {
                if (IsLocked == false)
                {
                    IsOpen = true;
                }
                else throw new Exception("Door is locked. To open it, unlock it first");
            }
            else throw new Exception("Door is already open");
        }

        public void CloseDoor()
        {
            if(IsOpen == true)
            {
                IsOpen = false;
            }
            else throw new Exception("Door is already closed");
        }

        public void LockDoor()
        {
            if(IsLocked == false)
            {
                IsLocked = true;
            }
            else throw new Exception("Door is already locked");
        }

        public void UnlockDoor(string password)
        {
            if (IsLocked == true)
            {
                if (Password == password)
                {
                    IsLocked = false;
                }
                else throw new ArgumentException("Incorrect Password");
            }
            else throw new Exception("Door is already unlocked");
        }

        public void SetNewDoorPassword(string currentPassword, string newPassword)
        {
            if(Password == currentPassword)
            {
                Password = newPassword;
            }
            else throw new ArgumentException("Incorrect Password");
        }
    }
}
