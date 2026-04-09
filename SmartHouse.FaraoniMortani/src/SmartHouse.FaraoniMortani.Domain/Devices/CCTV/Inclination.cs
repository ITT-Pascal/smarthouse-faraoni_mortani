using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Domain.Devices.CCTV
{
    public record Inclination
    {
        public const int Min = -90;
        public const int Max = 90;
        public const int Step = 1;

        public int CurrentInclination { get; set; }

        public Inclination(int value)
        {
            if (value > Max || value < Min)
                throw new ArgumentOutOfRangeException($"The inclination must be between {Max} and {Min} degrees");
            CurrentInclination = value;
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
