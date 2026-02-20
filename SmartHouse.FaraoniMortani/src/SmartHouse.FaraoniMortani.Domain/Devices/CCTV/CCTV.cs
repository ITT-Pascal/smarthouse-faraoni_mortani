using SmartHouse.FaraoniMortani.Domain.Devices.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Domain.Devices.CCTV
{
    public class CCTV: AbstractDevice
    {
        // Properties
        public CctvMode Mode { get; private set; }
        public Inclination InclinationValue { get; private set; }
        public double CurrentZoom { get; private set; }
        
        // Constants
        public const double MaxZoom = 10.0;
        public const double MinZoom = 1.0;


        // Constructor
        public CCTV(string name): base(name) 
        {
            Mode = CctvMode.Infrared;
            CurrentZoom = 1.0;
            InclinationValue = new Inclination(0);
        }

        // Methods
        public void ChangeMode(CctvMode newMode)
        {
            if (Mode != newMode)
                Mode = newMode;
        }

        /// <summary>
        /// Changes inclination of a certain number choosed by the user
        /// </summary>
        /// <param name="newTiltDegrees"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void ChangeInclination(int newTiltDegrees)
        {
            InclinationValue = new Inclination(newTiltDegrees);
        }

        /// <summary>
        /// Increases the inclination by 5
        /// </summary>
        public void IncreaseInclination() 
        {
            if(InclinationValue.CurrentInclination + Inclination.Step < Inclination.Max)
                InclinationValue += Inclination.Step;
            else 
                InclinationValue.CurrentInclination = Inclination.Max;
        }

        /// <summary>
        /// Decreases the inclination by 5
        /// </summary>
        public void DecreaseInclination()
        {
            if(InclinationValue.CurrentInclination - Inclination.Step > Inclination.Min)
                InclinationValue -= Inclination.Step;
            else 
                InclinationValue.CurrentInclination = Inclination.Min;
        }

        /// <summary>
        /// Changes the zoom to a certain value chosen by the user
        /// </summary>
        /// <param name="newZoom"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void ChangeZoom(double newZoom)
        {
            if (newZoom > MaxZoom || newZoom < MinZoom)
                throw new ArgumentOutOfRangeException($"New zoom value must be between 1 and {MaxZoom}");
            else 
                CurrentZoom = newZoom;
        }
    }
}
