using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Domain.UnitTests.CCTVTests
{
    public class CCTVTest
    {
        [Fact]
        public void ChangeMode_WhenNewModeIsInfrared_ItRemainsInfrared()
        {
            // Arrange
            CCTV cctv = new CCTV("Stefano's CCTV");

            // Act
            cctv.ChangeMode(CctvMode.Infrared);

            // Assert
            Assert.Equal(CctvMode.Infrared, cctv.Mode);
        }

        [Fact]
        public void ChangeMode_WhenNewModeIsNightVision_ModeBecomesNightVision()
        {
            // Arrange
            CCTV cctv = new CCTV("Stefano's CCTV");

            // Act
            cctv.ChangeMode(CctvMode.NightVision);

            // Assert
            Assert.Equal(CctvMode.NightVision, cctv.Mode);
        }

        [Fact]
        public void ChangeMode_WhenNewModeIsThermal_ModeBecomesThermal()
        { 
            // Arrange
            CCTV cctv = new CCTV("Stefano's CCTV");

            // Act
            cctv.ChangeMode(CctvMode.Thermal);

            // Assert
            Assert.Equal(CctvMode.Thermal, cctv.Mode);
        }

        [Fact]
        public void ChangeMode_WhenNewModeIsRecording_ModeBecomesRecording()
        {
            // Arrange
            CCTV cctv = new CCTV("Stefano's CCTV");

            // Act
            cctv.ChangeMode(CctvMode.Recording);

            // Assert
            Assert.Equal(CctvMode.Recording, cctv.Mode);
        }

        [Fact]
        public void ChangeInclination_WhenNewTiltDegreesIsOverMaxTiltDegrees_ThrowsException()
        {
            // Arrange
            CCTV cctv = new CCTV("Stefano's CCTV");

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => cctv.ChangeInclination(91));            
        }

        [Fact]
        public void ChangeInclination_WhenNewTiltDegreesIsBelowMinTiltDegrees_ThrowsException()
        {
            // Arrange
            CCTV cctv = new CCTV("Stefano's CCTV");

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => cctv.ChangeInclination(-91));
        }

        [Fact]
        public void ChangeInclination_WhenNewTiltIs45_InclinationBecome45()
        {
            // Arrange
            CCTV cctv = new CCTV("Stefano's CCTV");

            // Act
            cctv.ChangeInclination(45);

            // Assert
            Assert.Equal(45, cctv.CurrentInclination);
        }

        [Fact]
        public void IncreaseInclination_WhenCurrentInclinationIs89_CurrentInclinationBecome90()
        {
            // Arrange
            CCTV cctv = new CCTV("Stefano's CCTV");

            // Act
            cctv.ChangeInclination(89);
            cctv.IncreaseInclination();

            // Assert
            Assert.Equal(90, cctv.CurrentInclination);
        }

        [Fact]
        public void IncreaseInclination_WhenCurrentInclinationIs45_CurrentInclinationBecome50()
        {
            // Arrange
            CCTV cctv = new CCTV("Stefano's CCTV");

            // Act
            cctv.ChangeInclination(45);
            cctv.IncreaseInclination();

            // Assert
            Assert.Equal(50, cctv.CurrentInclination);
        }

        [Fact]
        public void DecreaseInclination_WhenCurrentInclinationIsMinus89_ItBecome90()
        {
            // Arrange
            CCTV cctv = new CCTV("Stefano's CCTV");

            // Act
            cctv.ChangeInclination(-89);
            cctv.DecreaseInclination();

            // Assert
            Assert.Equal(-90, cctv.CurrentInclination);
        }

        [Fact]
        public void DecreaseInclination_WhenCurrentInclinationIs45_ItBecome40()
        {
            // Arrange
            CCTV cctv = new CCTV("Stefano's CCTV");

            // Act
            cctv.ChangeInclination(45);
            cctv.DecreaseInclination();

            // Assert
            Assert.Equal(40, cctv.CurrentInclination);
        }

        [Fact]
        public void ChangeZoom_WhenNewZoomIsHigherThanMaxZoom_ThrowsException()
        {
            // Arrange
            CCTV cctv = new CCTV("Stefano's CCTV");

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => cctv.ChangeZoom(10.1));     
        }

        [Fact]
        public void ChangeZoom_WhenNewZoomIsLessThan1_ThrowsException()
        {
            // Arrange
            CCTV cctv = new CCTV("Stefano's CCTV");

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => cctv.ChangeZoom(0.9));
        }

        [Fact]
        public void ChangeZoom_WhenNewZoomIs7_CurrentZoomBecome7()
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