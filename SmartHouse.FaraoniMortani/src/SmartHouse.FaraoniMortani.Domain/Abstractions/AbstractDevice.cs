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
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DeviceStatus Status { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastChangeTime { get; set; }


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

        public virtual void SwitchOn()
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

        public virtual void SwitchOff()
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
