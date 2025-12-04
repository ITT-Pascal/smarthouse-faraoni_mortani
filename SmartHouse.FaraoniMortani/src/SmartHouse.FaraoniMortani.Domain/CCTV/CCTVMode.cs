using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Domain
{
    public enum CctvMode
    {
        Infrared, // Normal status
        NightVision, // For seeing during night
        Thermal, // For seeing living cratures or heat sources
        Recording
    }
}
