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

            Assert.Equal(5, airConditioner.TargetTemperature);
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
        public void SetCostumTemperature_WhenCustomTemperatureIs0_ThrowsException()
        {
            AirConditioner airConditioner = new AirConditioner("Stefano's air conditioner");

            Assert.Throws<ArgumentOutOfRangeException>(() => airConditioner.SetCustomTemperature(0));
        }

        [Fact]
        public void SetCostumTemperature_WhenCustomTemperatureIs41_ThrowsException()
        {
            AirConditioner airConditioner = new AirConditioner("Stefano's air conditioner");

            Assert.Throws<ArgumentOutOfRangeException>(() => airConditioner.SetCustomTemperature(41));
        }

        [Fact]
        public void HeatUp_WhenTemperatureIs20_TemperatureBecome21()
        {
            AirConditioner airConditioner = new AirConditioner("Stefano's air conditioner");

            airConditioner.HeatUp();

            Assert.Equal(21, airConditioner.TargetTemperature);

        }
        
        // TODO: Finish HeatUp tests and start CoolDown tests
    }
}
