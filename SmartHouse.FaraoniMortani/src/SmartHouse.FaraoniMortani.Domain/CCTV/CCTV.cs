using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHouse.FaraoniMortani.Domain;

namespace SmartHouse.FaraoniMortani.Domain
{
    public class CCTV : AbstractDevice
    {
        // Properties
        public CctvMode Mode { get; set; }
        public int CurrentTiltDegrees { get; set; }
        public double CurrentZoom { get; set; }
        
        // Constants
        public const int MaxTiltDegrees = 90;
        public const int MinTiltDegrees = -90;
        public const double MaxZoom = 10.0;

        // Constructor
        public CCTV(string name): base(name) 
        {
            Mode = CctvMode.Infrared;
            CurrentTiltDegrees = 0;
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
            if (newTiltDegrees > MaxTiltDegrees || newTiltDegrees < MinTiltDegrees)
                throw new ArgumentOutOfRangeException($"The inclination must be between {MaxTiltDegrees} and {MinTiltDegrees} degrees");
        }

        /// <summary>
        /// Increases the inclination by 5
        /// </summary>
        public void IncreaseInclination() 
        {
            if(CurrentTiltDegrees + 5 > MaxTiltDegrees)
                CurrentTiltDegrees += 5;
            else CurrentTiltDegrees = MaxTiltDegrees;
        }

        /// <summary>
        /// Decreases the inclination by 5
        /// </summary>
        public void DecreaseInclination()
        {
            if(CurrentTiltDegrees - 5 < MinTiltDegrees)
                CurrentTiltDegrees -= 5;
            else CurrentTiltDegrees = MinTiltDegrees;
        }

        /// <summary>
        /// Changes the zoom of a certain number choosed by the user
        /// </summary>
        /// <param name="newZoom"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void Zoom(double newZoom)
        {
            if (newZoom > MaxZoom || newZoom < 1)
                throw new ArgumentOutOfRangeException($"New zoom value must be between 1 and {MaxZoom}");
            else CurrentZoom = newZoom;
        }



        

    }
}
