using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Domain.HeatDevice
{
    public record Degree
    {
        public double Value { get; }

        public const double Max = 40;
        public const double Min = 0;
        public const double Default = 20;


        public Degree(double value)
        {
            Value = Default;
        }

        public static Degree operator +(Degree d, double amount)
        {
            if (d.Value + amount > Max)
                return new(Max);

            return new(d.Value + amount);
        }

        public static Degree operator -(Degree d, double amount)
        {
            if (d.Value - amount < Min)
                return new(Min);

            return new(d.Value - amount); 
        }

        public override string ToString()
        {
            return $"{Value}%";
        }
    }
}
