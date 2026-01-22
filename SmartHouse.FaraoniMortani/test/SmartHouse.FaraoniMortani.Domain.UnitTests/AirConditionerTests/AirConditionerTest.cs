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
        public void SetTemperatureToMin_WhenTemperatureIs20_TemperatureBecome5()
        {
            AirConditioner airConditioner = new AirConditioner("Stefano's air conditioner");

            airConditioner.SetTemperatureToMin();

            Assert.Equal(0, airConditioner.TargetTemperature);
        }

        [Fact]
        public void SetTemperatureToDefault_WhenTemperatureIs25_TemperatureBecome20()
        {
            AirConditioner airConditioner = new AirConditioner("Stefano's air conditioner");

            airConditioner.SetCustomTemperature(25);
            airConditioner.SetTemperatureToDefault();

            Assert.Equal(20, airConditioner.TargetTemperature);
        }

        [Fact]
        public void SetTemperatureToMax_WhenTemperatureIs20_TemperatureBecome40()
        {
            AirConditioner airConditioner = new AirConditioner("Stefano's air conditioner");

            airConditioner.SetTemperatureToMax();

            Assert.Equal(40, airConditioner.TargetTemperature);
        }

        [Fact]
        public void SetCustomTemperature_WhenCustomTemperatureIs30_TargetTemperatureBecome30()
        {
            AirConditioner airConditioner = new AirConditioner("Stefano's air conditioner");

            airConditioner.SetCustomTemperature(30);

            Assert.Equal(30, airConditioner.TargetTemperature);
        }

        [Fact]
        public void SetCustomTemperature_WhenCustomTemperatureIs0_ThrowsException()
        {
            AirConditioner airConditioner = new AirConditioner("Stefano's air conditioner");

            Assert.Throws<ArgumentOutOfRangeException>(() => airConditioner.SetCustomTemperature(0));
        }

        [Fact]
        public void SetCustomTemperature_WhenCustomTemperatureIs41_ThrowsException()
        {
            AirConditioner airConditioner = new AirConditioner("Stefano's air conditioner");

            Assert.Throws<ArgumentOutOfRangeException>(() => airConditioner.SetCustomTemperature(41));
        }

        [Fact]
        public void IncreaseTemperature_WhenTemperatureIs20_TemperatureBecome21()
        {
            AirConditioner airConditioner = new AirConditioner("Stefano's air conditioner");

            airConditioner.IncreaseTemperature();

            Assert.Equal(21, airConditioner.TargetTemperature);
        }

        [Fact]
        public void Increasetemperature_WhenTemperatureIs40_DoesNotIncrease()
        {

            // Arrange
            AirConditioner airConditioner = new AirConditioner("Stefano's air conditioner");

            // Act
            airConditioner.SetTemperatureToMax();
            airConditioner.IncreaseTemperature();

            // Assert
            Assert.Equal(40, airConditioner.TargetTemperature);
        }

        [Fact]
        public void DecreaseTemperature_WhenTemperatureIs20_TemperatureBecome19()
        {

            // Arrange
            AirConditioner airConditioner = new AirConditioner("Stefano's air conditioner");

            // Act
            airConditioner.DecreaseTemperature();

            // Assert
            Assert.Equal(19,5, airConditioner.TargetTemperature);
        }

        [Fact]
        public void DecreaseTemperature_WhenTemperatureIs5_DoesNotDecrease()
        {

            // Arrange
            AirConditioner airconditioner = new AirConditioner("Stefano's air conditioner");

            // Act
            airconditioner.SetCustomTemperature(0);
            airconditioner.DecreaseTemperature();

            // Assert
            Assert.Equal(5, airconditioner.TargetTemperature);
        }
    }
}
