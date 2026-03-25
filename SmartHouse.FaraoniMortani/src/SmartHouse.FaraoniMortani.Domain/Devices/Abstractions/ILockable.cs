using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Domain.Devices.Abstractions
{
    public interface ILockable
    {
        public void Lock();
        public void Unlock(int password);
    }
}
