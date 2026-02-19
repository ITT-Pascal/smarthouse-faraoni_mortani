using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Domain.Devices.CCTV
{
    public record Inclination
    {
        public const int MinimumInclination = -90;
        public const int MaximumInclination = 90;

        public int CurrentInclination { get; set; }

        public Inclination(int value)
        {
            CurrentInclination = 0;
        }

        public static Inclination operator +(Inclination inclination, int tiltingAngle)
        {
            return new(inclination.CurrentInclination + tiltingAngle);
        }
        public static Inclination operator -(Inclination inclination, int tiltingAngle)
        {
            return new(inclination.CurrentInclination - tiltingAngle);
        }

    }
}
