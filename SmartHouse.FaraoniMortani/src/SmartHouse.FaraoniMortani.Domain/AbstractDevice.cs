using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Domain
{
    public abstract class AbstractDevice
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DeviceStatus Status { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastChangeTime { get; set; }

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
                throw new InvalidOperationException("Il disposotivo è già accesso");

            Status = DeviceStatus.On;
            LastChangeTime = DateTime.UtcNow;

        }

        public virtual void SwitchOff()
        {
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("Il dispositivo è già spento");

            Status = DeviceStatus.Off;
            LastChangeTime = DateTime.UtcNow;
        }
    }
}
