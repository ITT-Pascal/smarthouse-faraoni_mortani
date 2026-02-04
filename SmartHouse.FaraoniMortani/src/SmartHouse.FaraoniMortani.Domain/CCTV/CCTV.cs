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
        public const double MaxZoom = 10.0;
        public const double MinZoom = 1.0;


        // Constructor
        public CCTV(string name): base(name) 
        {
            Mode = CctvMode.Infrared;
            CurrentZoom = 1.0;
            CurrentInclination = new Inclination(0);
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
            if (newTiltDegrees > Inclination.MaximumInclination || newTiltDegrees < Inclination.MinimumInclination)
                throw new ArgumentOutOfRangeException($"The inclination must be between {Inclination.MaximumInclination} and {Inclination.MinimumInclination} degrees");
            else 
                CurrentInclination.CurrentInclination = newTiltDegrees;
        }

        /// <summary>
        /// Increases the inclination by 5
        /// </summary>
        public void IncreaseInclination() 
        {
            if((CurrentInclination.CurrentInclination + Inclination.MaximumInclination) < Inclination.MaximumInclination)
                CurrentInclination += 1;
            else 
                CurrentInclination.CurrentInclination = Inclination.MaximumInclination;
        }

        /// <summary>
        /// Decreases the inclination by 5
        /// </summary>
        public void DecreaseInclination()
        {
            if(CurrentInclination.CurrentInclination - Inclination.MinimumInclination > Inclination.MinimumInclination)
                CurrentInclination -= 1;
            else 
                CurrentInclination.CurrentInclination = Inclination.MinimumInclination;
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
