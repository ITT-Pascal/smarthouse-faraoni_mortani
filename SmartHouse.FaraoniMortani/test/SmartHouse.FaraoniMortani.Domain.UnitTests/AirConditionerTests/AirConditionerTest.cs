using SmartHouse.FaraoniMortani.Domain.HeatDevice.AirConditioner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Domain.UnitTests
{
    public class AirConditionerTest
    {
        [Fact]
        public void SetTemperatureToMin_WhenTemperatureIs20_TemperatureBecomes5()
        {
            AirConditioner airConditioner = new AirConditioner("Stefano's air conditioner");

            airConditioner.SetTemperatureToMin();

            Assert.Equal(0, airConditioner.TargetTemperature.Value);
        }

        [Fact]
        public void SetTemperatureToDefault_WhenTemperatureIs25_TemperatureBecomes20()
        {
            AirConditioner airConditioner = new AirConditioner("Stefano's air conditioner");

            airConditioner.Toggle();
            airConditioner.SetCustomTemperature(25);
            airConditioner.SetTemperatureToDefault();

            Assert.Equal(20, airConditioner.TargetTemperature.Value);
        }

        [Fact]
        public void SetTemperatureToMax_WhenTemperatureIs20_TemperatureBecomes40()
        {
            AirConditioner airConditioner = new AirConditioner("Stefano's air conditioner");

            airConditioner.SetTemperatureToMax();

            Assert.Equal(40, airConditioner.TargetTemperature.Value);
        }

        [Fact]
        public void SetCustomTemperature_WhenCustomTemperatureIs30_TargetTemperatureBecomes30()
        {
            AirConditioner airConditioner = new AirConditioner("Stefano's air conditioner");

            airConditioner.Toggle();
            airConditioner.SetCustomTemperature(30);

            Assert.Equal(30, airConditioner.TargetTemperature.Value);
        }

        [Fact]
        public void SetCustomTemperature_WhenCustomTemperatureIsMinus1_ThrowsException()
        {
            AirConditioner airConditioner = new AirConditioner("Stefano's air conditioner");

            airConditioner.Toggle();
            Assert.Throws<ArgumentOutOfRangeException>(() => airConditioner.SetCustomTemperature(-1));
        }

        [Fact]
        public void SetCustomTemperature_WhenCustomTemperatureIs41_ThrowsException()
        {
            AirConditioner airConditioner = new AirConditioner("Stefano's air conditioner");

            airConditioner.Toggle();
            Assert.Throws<ArgumentOutOfRangeException>(() => airConditioner.SetCustomTemperature(41));
        }

        [Fact]
        public void IncreaseTemperature_WhenTemperatureIs20_TemperatureBecomes20Dot5()
        {
            AirConditioner airConditioner = new AirConditioner("Stefano's air conditioner");

            airConditioner.Toggle();
            airConditioner.IncreaseTemperature();

            Assert.Equal(20.5, airConditioner.TargetTemperature.Value);
        }

        [Fact]
        public void Increasetemperature_WhenTemperatureIs40_DoesNotIncrease()
        {

            // Arrange
            AirConditioner airConditioner = new AirConditioner("Stefano's air conditioner");

            // Act
            airConditioner.Toggle();
            airConditioner.SetTemperatureToMax();
            airConditioner.IncreaseTemperature();

            // Assert
            Assert.Equal(40, airConditioner.TargetTemperature.Value);
        }

        [Fact]
        public void DecreaseTemperature_WhenTemperatureIs20_TemperatureBecomes19()
        {

            // Arrange
            AirConditioner airConditioner = new AirConditioner("Stefano's air conditioner");

            // Act
            airConditioner.Toggle();
            airConditioner.DecreaseTemperature();

            // Assert
            Assert.Equal(19,5, airConditioner.TargetTemperature.Value);
        }

        [Fact]
        public void DecreaseTemperature_WhenTemperatureIs5_DoesNotDecrease()
        {

            // Arrange
            AirConditioner airconditioner = new AirConditioner("Stefano's air conditioner");

            // Act
            airconditioner.Toggle();
            airconditioner.SetCustomTemperature(0);
            airconditioner.DecreaseTemperature();

            // Assert
            Assert.Equal(0, airconditioner.TargetTemperature.Value);
        }
    }
}
