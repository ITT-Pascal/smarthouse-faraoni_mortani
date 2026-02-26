using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Domain.Devices.Abstractions
{
    public enum DeviceStatus
    {
        Off,
        On,
        StandBy,
        Error,
        Open,
        Closed,
        Unknown
    }
}
