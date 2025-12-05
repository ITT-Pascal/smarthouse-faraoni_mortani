using SmartHouse.FaraoniMortani.Domain;
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
            Thermostat thermostat1 = new Thermostat("Stefano's Thermostat");

            // Act
            thermostat1.Switch();
            thermostat1.IncreaseTemperature();

            // Assert
            Assert.Equal(15.5, thermostat1.Temperature);
        }

        [Fact]
        public void IncreaseTemperature_IfTemperatureIs15_AndTemperatureIsIncreasedWithDeviceTurnedOff_TemperatureCannotBeModified()
        {
            // Arrange
            Thermostat thermostat1 = new Thermostat("Stefano's Thermostat");

            // Assert 
            Assert.Throws<Exception>(() => thermostat1.IncreaseTemperature());
        }

        [Fact]
        public void DecreaseTemperature_IfTemperatureIs15_AndTemperatureIsDecreasedWithDeviceTurnedOn_TemperatureIs14Dot5()
        {
            // Arrange
            Thermostat thermostat1 = new Thermostat("Stefano's Thermostat");

            // Act
            thermostat1.Switch();
            thermostat1.DecreaseTemperature();

            // Assert
            Assert.Equal(14.5, thermostat1.Temperature);
        }

        [Fact]
        public void DecreaseTemperature_IfTemperatureIs15_AndTemperatureIsDecreasedWithDeviceTurnedOff_TemperatureCannotBeModified()
        {
            // Arrange
            Thermostat thermostat1 = new Thermostat("Stefano's Thermostat");

            // Assert
            Assert.Throws<Exception>(() => thermostat1.DecreaseTemperature());
        }

        [Fact]
        public void SetTemperature_IfTemperatureIs15_AndTemperatureIsSetTo16WithDeviceTurnedOn_TemperatureIs16()
        {
            // Arrange
            Thermostat thermostat1 = new Thermostat("Stefano's Thermostat");

            // Act
            thermostat1.Switch();
            thermostat1.SetTemperature(16.0);

            // Assert
            Assert.Equal(16.0, thermostat1.Temperature);
        }

        [Fact]
        public void SetTemperature_IfTemperatureIs15_AndTemperatureIsSetTo16WithDeviceTurnedOff_TemperatureCannotBeModified()
        {
            // Arrange
            Thermostat thermostat1 = new Thermostat("Stefano's Thermostat");

            // Assert
            Assert.Throws<Exception>(() => thermostat1.SetTemperature(16.0));
        }
    }
}
