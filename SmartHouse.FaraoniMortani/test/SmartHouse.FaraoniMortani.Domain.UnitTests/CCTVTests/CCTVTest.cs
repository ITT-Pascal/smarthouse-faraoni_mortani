using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHouse.FaraoniMortani.Domain.Devices.CCTV;

namespace SmartHouse.FaraoniMortani.Domain.UnitTests.CCTVTests
{
    public class CCTVTest
    {
        [Fact]
        public void ChangeMode_WhenNewModeIsInfrared_ItSwitchesToInfrared()
        {
            // Arrange
            CCTV cctv = new CCTV("Stefano's CCTV");

            // Act
            cctv.ChangeMode(CctvMode.Infrared);

            // Assert
            Assert.Equal(CctvMode.Infrared, cctv.Mode);
        }

        [Fact]
        public void ChangeMode_WhenNewModeIsNightVision_ModeSwitchesToNightVision()
        {
            // Arrange
            CCTV cctv = new CCTV("Stefano's CCTV");

            // Act
            cctv.ChangeMode(CctvMode.NightVision);

            // Assert
            Assert.Equal(CctvMode.NightVision, cctv.Mode);
        }

        [Fact]
        public void ChangeMode_WhenNewModeIsThermal_ModeSwitchesToThermal()
        {
            // Arrange
            CCTV cctv = new CCTV("Stefano's CCTV");

            // Act
            cctv.ChangeMode(CctvMode.Thermal);

            // Assert
            Assert.Equal(CctvMode.Thermal, cctv.Mode);
        }

        [Fact]
        public void ChangeMode_WhenNewModeIsRecording_ModeSwitchesToRecording()
        {
            // Arrange
            CCTV cctv = new CCTV("Stefano's CCTV");

            // Act
            cctv.ChangeMode(CctvMode.Recording);

            // Assert
            Assert.Equal(CctvMode.Recording, cctv.Mode);
        }

        [Fact]
        public void ChangeInclination_WhenNewInclinationValueIsOverMaxInclination_ThrowException()
        {
            // Arrange
            CCTV cctv = new CCTV("Stefano's CCTV");

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => cctv.ChangeInclination(91));            
        }

        [Fact]
        public void ChangeInclination_WhenNewInclinationValueIsBelowMinInclination_ThrowException()
        {
            // Arrange
            CCTV cctv = new CCTV("Stefano's CCTV");

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => cctv.ChangeInclination(-91));
        }

        [Fact]
        public void ChangeInclination_WhenNewInclinationValueIs45_InclinationBecomes45()
        {
            // Arrange
            CCTV cctv = new CCTV("Stefano's CCTV");

            // Act
            cctv.ChangeInclination(45);

            // Assert
            Assert.Equal(45, cctv.InclinationValue.CurrentInclination);
        }

        [Fact]
        public void IncreaseInclination_WhenInclinationValueIs89_InclinationBecomes90()
        {
            // Arrange
            CCTV cctv = new CCTV("Stefano's CCTV");

            // Act
            cctv.ChangeInclination(89);
            cctv.IncreaseInclination();

            // Assert
            Assert.Equal(90, cctv.InclinationValue.CurrentInclination);
        }

        [Fact]
        public void DecreaseInclination_WhenInclinationValueIsMinus89_InclinationBecomesMinus90()
        {
            // Arrange
            CCTV cctv = new CCTV("Stefano's CCTV");

            // Act
            cctv.ChangeInclination(-89);
            cctv.DecreaseInclination();

            // Assert
            Assert.Equal(-90, cctv.InclinationValue.CurrentInclination);
        }

        [Fact]
        public void ChangeZoom_WhenNewZoomValueIsHigherThanMaxZoom_ThrowException()
        {
            // Arrange
            CCTV cctv = new CCTV("Stefano's CCTV");

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => cctv.ChangeZoom(10.1));     
        }

        [Fact]
        public void ChangeZoom_WhenNewZoomValueIsLessThanMinZoom_ThrowException()
        {
            // Arrange
            CCTV cctv = new CCTV("Stefano's CCTV");

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => cctv.ChangeZoom(0.9));
        }

        [Fact]
        public void ChangeZoom_WhenNewZoomValueIs7_ZoomBecomes7()
        {
            // Arrange
            CCTV cctv = new CCTV("Stefano's CCTV");

            // Act
            cctv.ChangeZoom(7);

            // Assert
            Assert.Equal(7, cctv.CurrentZoom);
        }
    }
}