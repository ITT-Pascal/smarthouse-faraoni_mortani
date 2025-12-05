using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHouse.FaraoniMortani.Domain;

namespace SmartHouse.FaraoniMortani.Domain
{
    public class CCTV: AbstractDevice
    {
        // Properties
        public CctvMode Mode { get; private set; }
        public int CurrentInclination { get; private set; }
        public double CurrentZoom { get; private set; }
        
        // Constants
        public const int MaxInclination = 90;
        public const int MinInclination = -90;
        public const double MaxZoom = 10.0;


        // Constructor
        public CCTV(string name): base(name) 
        {
            Mode = CctvMode.Infrared;
            CurrentInclination = 0;
            CurrentZoom = 1;
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
            if (newTiltDegrees > MaxInclination || newTiltDegrees < MinInclination)
                throw new ArgumentOutOfRangeException($"The inclination must be between {MaxInclination} and {MinInclination} degrees");
            else 
                CurrentInclination = newTiltDegrees;
        }

        /// <summary>
        /// Increases the inclination by 5
        /// </summary>
        public void IncreaseInclination() 
        {
            if(CurrentInclination + 5 < MaxInclination)
                CurrentInclination += 5;
            else 
                CurrentInclination = MaxInclination;
        }

        /// <summary>
        /// Decreases the inclination by 5
        /// </summary>
        public void DecreaseInclination()
        {
            if(CurrentInclination - 5 > MinInclination)
                CurrentInclination -= 5;
            else 
                CurrentInclination = MinInclination;
        }

        /// <summary>
        /// Changes the zoom of a certain number choosed by the user
        /// </summary>
        /// <param name="newZoom"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void ChangeZoom(double newZoom)
        {
            if (newZoom > MaxZoom || newZoom < 1)
                throw new ArgumentOutOfRangeException($"New zoom value must be between 1 and {MaxZoom}");
            else 
                CurrentZoom = newZoom;
        }
    }
}
