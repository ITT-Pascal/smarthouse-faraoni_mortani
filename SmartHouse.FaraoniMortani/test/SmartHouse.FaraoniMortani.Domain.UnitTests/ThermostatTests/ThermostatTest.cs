using SmartHouse.FaraoniMortani.Domain.HeatDevice.ThermostatDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Domain.UnitTests.ThermostatTests
{
   public class ThermostatTest
    {
        [Fact]
        public void IncreaseTemperature_IfTemperatureIs15_AndTemperatureIsIncreasedWithDeviceTurnedOn_TemperatureIs15Dot5()
        {
            // Arrange
            Thermostat thermostat = new Thermostat("Stefano's Thermostat");

            // Act
            thermostat.Toggle();
            thermostat.IncreaseTemperature();

            // Assert
            Assert.Equal(15.5, thermostat.Temperature);
        }

        [Fact]
        public void IncreaseTemperature_IfTemperatureIs15_AndTemperatureIsIncreasedWithDeviceTurnedOff_TemperatureCannotBeModified()
        {
            // Arrange
            Thermostat thermostat = new Thermostat("Stefano's Thermostat");

            // Assert 
            Assert.Throws<Exception>(() => thermostat.IncreaseTemperature());
        }

        [Fact]
        public void IncreaseTemperature_WhenTemperatureIs39Dot9_TemperatureBecome40()
        {
            // Arrange
            Thermostat thermostat = new Thermostat("Stefano's Thermostat");

            // Act
            thermostat.Toggle();
            thermostat.SetCustomTemperature(39.9);
            thermostat.IncreaseTemperature();

            // Assert
            Assert.Equal(40, thermostat.Temperature);
        }

        [Fact]
        public void DecreaseTemperature_IfTemperatureIs15_AndTemperatureIsDecreasedWithDeviceTurnedOn_TemperatureIs14Dot5()
        {
            // Arrange
            Thermostat thermostat = new Thermostat("Stefano's Thermostat");

            // Act
            thermostat.Toggle();
            thermostat.DecreaseTemperature();

            // Assert
            Assert.Equal(19.5, thermostat.Temperature);
        }

        [Fact]
        public void DecreaseTemperature_IfTemperatureIs15_AndTemperatureIsDecreasedWithDeviceTurnedOff_TemperatureCannotBeModified()
        {
            // Arrange
            Thermostat thermostat = new Thermostat("Stefano's Thermostat");

            // Assert
            Assert.Throws<Exception>(() => thermostat.DecreaseTemperature());
        }

        [Fact]
        public void DecreaseTemperature_WhenTemperatureIs0Dot1_TemperatureBecome0()
        {
            // Arrange
            Thermostat thermostat = new Thermostat("Stefano's Thermostat");

            // Act
            thermostat.Toggle();
            thermostat.SetCustomTemperature(0.1);
            thermostat.DecreaseTemperature();

            // Assert
            Assert.Equal(0, thermostat.Temperature);
        }

        [Fact]
        public void SetCustomTemperature_IfTemperatureIs15_AndTemperatureIsSetTo16WithDeviceTurnedOn_TemperatureIs16()
        {
            // Arrange
            Thermostat thermostat = new Thermostat("Stefano's Thermostat");

            // Act
            thermostat.Toggle();
            thermostat.SetCustomTemperature(16.0);

            // Assert
            Assert.Equal(16.0, thermostat.Temperature);
        }

        [Fact]
        public void SetCustomTemperature_IfTemperatureIs15_AndTemperatureIsSetTo16WithDeviceTurnedOff_TemperatureCannotBeModified()
        {
            // Arrange
            Thermostat thermostat = new Thermostat("Stefano's Thermostat");

            // Assert
            Assert.Throws<Exception>(() => thermostat.SetCustomTemperature(16.0));
        }

        [Fact]
        public void SetCustomTemperature_WhenNewTemperatureIsLowerThanMinTemperature_ThrowsException()
        {
            // Arrange
            Thermostat thermostat = new Thermostat("Stefano's Thermostat");

            // Act
            thermostat.Toggle();

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => thermostat.SetCustomTemperature(-0.1));
        }

        [Fact]
        public void SetCustomTemperature_WhenNewTemperatureIsHigherThanMaxTemperature_ThrowsException()
        {
            // Arrange
            Thermostat thermostat = new Thermostat("Stefano's Thermostat");

            // Act
            thermostat.Toggle();

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => thermostat.SetCustomTemperature(40.1));
        }
    }
}
