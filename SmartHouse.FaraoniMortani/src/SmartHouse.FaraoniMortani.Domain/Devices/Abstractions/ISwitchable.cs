using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Domain.Devices.Abstractions
{
    public interface ISwitchable
    {
        void Toggle();
        void SwitchOn();
        void SwitchOff();
    }
}
