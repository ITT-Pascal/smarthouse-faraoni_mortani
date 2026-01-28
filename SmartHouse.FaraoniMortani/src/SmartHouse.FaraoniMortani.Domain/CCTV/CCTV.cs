using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHouse.FaraoniMortani.Domain;
using SmartHouse.FaraoniMortani.Domain.CCTV;

namespace SmartHouse.FaraoniMortani.Domain.CCTV
{
    public class CCTV: AbstractDevice
    {
        // Properties
        public CctvMode Mode { get; private set; }
        public Inclination CurrentInclination { get; private set; }
        public double CurrentZoom { get; private set; }
        
        // Constants
        public const int MaxInclination = 90;
        public const int MinInclination = -90;
        public const double MaxZoom = 10.0;
        public const double MinZoom = 1.0;


        // Constructor
        public CCTV(string name): base(name) 
        {
            Mode = CctvMode.Infrared;
            CurrentZoom = 1.0;
        }

        // Methods
        public void ChangeMode(CctvMode newMode)
        {
            if (Mode != newMode)
                Mode = newMode;
        }

        //TODO: Fix methods

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
            if(CurrentInclination + CurrentInclination.MinInclination < MaxInclination)
                CurrentInclination += 1;
            else 
                CurrentInclination = MaxInclination;
        }

        /// <summary>
        /// Decreases the inclination by 5
        /// </summary>
        public void DecreaseInclination()
        {
            if(CurrentInclination - MinInclination > MinInclination)
                CurrentInclination -= 1;
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
            if (newZoom > MaxZoom || newZoom < MinZoom)
                throw new ArgumentOutOfRangeException($"New zoom value must be between 1 and {MaxZoom}");
            else 
                CurrentZoom = newZoom;
        }
    }
}
