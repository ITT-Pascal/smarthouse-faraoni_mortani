using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Domain
{
    public abstract class AbstractDevice
    {
        // Properties
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public DeviceStatus Status { get; protected set; }
        public DateTime CreationTime { get; protected set; }
        public DateTime LastChangeTime { get; protected set; }


        // Constructors
        protected AbstractDevice() { }

        public AbstractDevice(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            Status = DeviceStatus.Off;
            CreationTime = DateTime.UtcNow;
            LastChangeTime = DateTime.UtcNow;
        }

        public AbstractDevice(string name, Guid newGuid)
        {
            Id = newGuid;
            Name = name;
            Status = DeviceStatus.Off;
            CreationTime = DateTime.UtcNow;
            LastChangeTime = DateTime.UtcNow;
        }


        // Methods
        public virtual void Switch()
        {
            if (Status == DeviceStatus.Off)
                SwitchOn();
            else
                SwitchOff();
        }

        private void SwitchOn()
        {
            if (Status == DeviceStatus.On)
            {
                throw new InvalidOperationException("Device is already turned on");
            } 
            else
            {
                Status = DeviceStatus.On;
                LastChangeTime = DateTime.UtcNow;
            }
        }

        private void SwitchOff()
        {
            if (Status == DeviceStatus.Off)
            {
                throw new InvalidOperationException("Device is already turned off");
            }
            else
            {
                Status = DeviceStatus.Off;
                LastChangeTime = DateTime.UtcNow;
            }          
        }
    }
}
