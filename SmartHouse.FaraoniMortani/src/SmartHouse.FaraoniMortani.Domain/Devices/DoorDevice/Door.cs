using SmartHouse.FaraoniMortani.Domain.Devices.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Domain.Devices.DoorDevice
{
    public class Door: AbstractDevice, ILockable
    {
        public bool IsLocked { get; private set; }
        public int Password { get; private set; }

        public Door(string name, int password)
        {
            Id = new Guid();
            Name = name;
            Status = DeviceStatus.Closed;
            CreationTime = DateTime.UtcNow;
            LastChangeTime = DateTime.UtcNow;
            IsLocked = false;
            Password = password;
        }

        public void Open()
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

        public void Close()
        {
            if(Status == DeviceStatus.Open)
            {
                Status = DeviceStatus.Closed;
            }
            else throw new Exception("Door is already closed");
        }

        public void Lock()
        {
            if(IsLocked == false)
            {
                IsLocked = true;
            }
            else throw new Exception("Door is already locked");
        }

        public void Unlock(int password)
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

        public void SetNewPassword(int currentPassword, int newPassword)
        {
            if(Password == currentPassword)
            {
                Password = newPassword;
            }
            else throw new ArgumentException("Incorrect Password");
        }
    }
}
