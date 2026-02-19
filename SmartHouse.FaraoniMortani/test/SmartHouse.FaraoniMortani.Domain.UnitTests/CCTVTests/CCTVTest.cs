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
        public void ChangeMode_WhenNewModeIsInfrared_ItRemainsInfrared()
        {
            // Arrange
            Devices.CCTV.CCTV cctv = new CCTV.CCTV("Stefano's CCTV");

            // Act
            cctv.ChangeMode(CctvMode.Infrared);

            // Assert
            Assert.Equal(CctvMode.Infrared, cctv.Mode);
        }

        [Fact]
        public void ChangeMode_WhenNewModeIsNightVision_ModeBecomesNightVision()
        {
            // Arrange
            Devices.CCTV.CCTV cctv = new CCTV.CCTV("Stefano's CCTV");

            // Act
            cctv.ChangeMode(CctvMode.NightVision);

            // Assert
            Assert.Equal(CctvMode.NightVision, cctv.Mode);
        }

        [Fact]
        public void ChangeMode_WhenNewModeIsThermal_ModeBecomesThermal()
        {
            // Arrange
            Devices.CCTV.CCTV cctv = new CCTV.CCTV("Stefano's CCTV");

            // Act
            cctv.ChangeMode(CctvMode.Thermal);

            // Assert
            Assert.Equal(CctvMode.Thermal, cctv.Mode);
        }

        [Fact]
        public void ChangeMode_WhenNewModeIsRecording_ModeBecomesRecording()
        {
            // Arrange
            Devices.CCTV.CCTV cctv = new CCTV.CCTV("Stefano's CCTV");

            // Act
            cctv.ChangeMode(CctvMode.Recording);

            // Assert
            Assert.Equal(CctvMode.Recording, cctv.Mode);
        }

        [Fact]
        public void ChangeInclination_WhenNewTiltDegreesIsOverMaxTiltDegrees_ThrowsException()
        {
            // Arrange
            Devices.CCTV.CCTV cctv = new CCTV.CCTV("Stefano's CCTV");

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => cctv.ChangeInclination(91));            
        }

        [Fact]
        public void ChangeInclination_WhenNewTiltDegreesIsBelowMinTiltDegrees_ThrowsException()
        {
            // Arrange
            Devices.CCTV.CCTV cctv = new CCTV.CCTV("Stefano's CCTV");

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => cctv.ChangeInclination(-91));
        }

        [Fact]
        public void ChangeInclination_WhenNewTiltIs45_InclinationBecomes45()
        {
            // Arrange
            Devices.CCTV.CCTV cctv = new CCTV.CCTV("Stefano's CCTV");

            // Act
            cctv.ChangeInclination(45);

            // Assert
            Assert.Equal(45, cctv.InclinationValue.CurrentInclination);
        }

        [Fact]
        public void IncreaseInclination_WhenCurrentInclinationIs89_CurrentInclinationBecomes90()
        {
            // Arrange
            Devices.CCTV.CCTV cctv = new CCTV.CCTV("Stefano's CCTV");

            // Act
            cctv.ChangeInclination(89);
            cctv.IncreaseInclination();

            // Assert
            Assert.Equal(90, cctv.InclinationValue.CurrentInclination);
        }

        [Fact]
        public void DecreaseInclination_WhenCurrentInclinationIsMinus89_ItBecomesMinus90()
        {
            // Arrange
            Devices.CCTV.CCTV cctv = new CCTV.CCTV("Stefano's CCTV");

            // Act
            cctv.ChangeInclination(-89);
            cctv.DecreaseInclination();

            // Assert
            Assert.Equal(-90, cctv.InclinationValue.CurrentInclination);
        }

        [Fact]
        public void ChangeZoom_WhenNewZoomIsHigherThanMaxZoom_ThrowsException()
        {
            // Arrange
            Devices.CCTV.CCTV cctv = new CCTV.CCTV("Stefano's CCTV");

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => cctv.ChangeZoom(10.1));     
        }

        [Fact]
        public void ChangeZoom_WhenNewZoomIsLessThan1_ThrowsException()
        {
            // Arrange
            Devices.CCTV.CCTV cctv = new CCTV.CCTV("Stefano's CCTV");

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => cctv.ChangeZoom(0.9));
        }

        [Fact]
        public void ChangeZoom_WhenNewZoomIs7_CurrentZoomBecomes7()
        {
            // Arrange
            Devices.CCTV.CCTV cctv = new CCTV.CCTV("Stefano's CCTV");

            // Act
            cctv.ChangeZoom(7);

            // Assert
            Assert.Equal(7, cctv.CurrentZoom);
        }
    }
}