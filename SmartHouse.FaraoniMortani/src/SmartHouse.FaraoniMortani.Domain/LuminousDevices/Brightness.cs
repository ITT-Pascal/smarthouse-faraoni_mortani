using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Domain.LuminousDevices
{
    public record Brightness
    {
        public int Value { get; set; }

        public const int Min = 0;
        public const int Max = 100;

        public Brightness(int value)
        {
            Value = Math.Clamp(value, Min, Max);
        }

        public static Brightness operator +(Brightness b, int amount)
        {
            if (b.Value + amount > Max)
                return new(Max);

            return new(b.Value + amount);
        }

        public static Brightness operator -(Brightness b, int amount)
        {
            if (b.Value - amount < Min)
                return new(Min);

            return new(b.Value - amount);
        }

        public override string ToString()
        {
            return $"{Value}%";
        }


    }
}
