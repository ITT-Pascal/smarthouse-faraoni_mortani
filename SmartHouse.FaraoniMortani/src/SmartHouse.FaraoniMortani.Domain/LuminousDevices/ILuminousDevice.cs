using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Domain.LuminousDevices
{
    public interface ILuminousDevice
    {
        void Dimmer(int amount);
        void Brighten(int amount);
        void SetBrightness(Brightness newBrightness);
    }
}
