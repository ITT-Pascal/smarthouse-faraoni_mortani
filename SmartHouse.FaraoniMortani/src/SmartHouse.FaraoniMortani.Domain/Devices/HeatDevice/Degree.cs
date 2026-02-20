using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Domain.Devices.HeatDevice
{
    public record Degree
    {
        // Properties
        public double Value { get; set; }

        // Constants
        public const double Max = 40;
        public const double Min = 0;
        public const double Default = 20;
        public const double Step = 0.5;

        // Constructor
        public Degree(double value)
        {
            if (value < Min || value > Max)
                throw new ArgumentOutOfRangeException($"New temperature must be between {Min} and {Max}");

            Value = value;
        }

        // Method
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