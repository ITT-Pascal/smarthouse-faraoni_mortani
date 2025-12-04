using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Domain
{
    public class Door: AbstractDevice
    {
        public bool IsLocked { get; private set; }
        public string Password { get; private set; }

        public Door(string name, string password)
        {
            Id = new Guid();
            Name = name;
            Status = DeviceStatus.Closed;
            CreationTime = DateTime.UtcNow;
            LastChangeTime = DateTime.UtcNow;
            IsLocked = false;
            Password = password;
        }

        public void OpenDoor()
        {
            if (Status == DeviceStatus.Closed)
            {
                if (IsLocked == false)
                {
                    Status = DeviceStatus.Open;
                }
                else throw new Exception("Door is locked. To open it, unlock it first");
            }
            else throw new Exception("Door is already open");
        }

        public void CloseDoor()
        {
            if(Status == DeviceStatus.Open)
            {
                Status = DeviceStatus.Closed;
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
