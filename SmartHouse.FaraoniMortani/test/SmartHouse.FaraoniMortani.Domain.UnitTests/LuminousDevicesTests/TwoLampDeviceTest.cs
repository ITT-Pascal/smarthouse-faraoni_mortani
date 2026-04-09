using SmartHouse.FaraoniMortani.Domain.Devices.Abstractions;
using SmartHouse.FaraoniMortani.Domain.Devices.LuminousDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Domain.UnitTests.LuminousDevicesTests
{
    public class TwoLampDeviceTest
    {
        [Fact]
        public void TurnBothOn_WhenBothLampsGetTurnedOn_BothLampsHaveStatusOn()
        {
            // Arrange
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            TwoLampDevice twoLampDevice = new TwoLampDevice(lamp1, lamp2);

            // Act
            twoLampDevice.TurnBothOn();

            // Assert
            Assert.Equal(DeviceStatus.On, lamp1.Status);
            Assert.Equal(DeviceStatus.On, lamp2.Status );
        }

        [Fact]
        public void TurnBothOff_WhenBothLampsGetTurnedOff_BothLampsHaveStatusOff()
        {
            // Arrange
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            TwoLampDevice twoLampDevice = new TwoLampDevice(lamp1, lamp2);

            // Act
            twoLampDevice.TurnBothOff();

            // Assert
            Assert.Equal(DeviceStatus.Off, lamp1.Status);
            Assert.Equal(DeviceStatus.Off, lamp2.Status);
        }

        [Fact]
        public void TurnOnOneLamp_WhenFirstLampGetTurnedOn_FirstLampHaveOnStatus()
        {
            // Arrange
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            TwoLampDevice twoLampDevice = new TwoLampDevice(lamp1, lamp2);

            // Act
            twoLampDevice.TurnOnOneLamp(lamp1);

            // Assert
            Assert.Equal(DeviceStatus.On, lamp1.Status);
        }

        [Fact]
        public void TurnOnOneLamp_WhenSecondLampGetTurnedOn_SecondLampHaveStatusOn()
        {
            // Arrange
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            TwoLampDevice twoLampDevice = new TwoLampDevice(lamp1, lamp2);

            // Act
            twoLampDevice.TurnOnOneLamp(lamp2);

            // Assert
            Assert.Equal(DeviceStatus.On, lamp2.Status);
        }

        [Fact]
        public void SetOneBrightness_WhenFirstLampBrightnessIsSetTo30_BrightnessIs30()
        {
            // Arrange
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            TwoLampDevice twoLampDevice = new TwoLampDevice(lamp1, lamp2);

            // Act
            twoLampDevice.TurnOnOneLamp(lamp1);
            twoLampDevice.SetBrightnessForSingleLamp(lamp1, new Brightness(30));

            // Assert
            Assert.Equal(30, lamp1.BrightnessLevel.Value);
        }

        [Fact]
        public void SetOneBrightness_WhenSecondLampBrightnessIsSetTo30_BrightnessIs30()
        {
            // Arrange
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            TwoLampDevice twoLampDevice = new TwoLampDevice(lamp1, lamp2);

            // Act
            twoLampDevice.SetBrightnessForSingleLamp(lamp2, new Brightness(30));

            // Assert
            Assert.Equal(30, lamp2.BrightnessLevel.Value);
        }

        [Fact]
        public void SetBothSameBrightness_WhenLampsBrightnessIsSetTo30_BrightnessIs30()
        {
            // Arrange
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            TwoLampDevice twoLampDevice = new TwoLampDevice(lamp1, lamp2);

            // Act
            twoLampDevice.SetBrightnessForBothLamps(new Brightness(30));

            // Assert
            Assert.Equal(30, lamp1.BrightnessLevel.Value);
            Assert.Equal(30, lamp2.BrightnessLevel.Value);
        }

        [Fact]
        public void SetOneEcoLampBrightnessToEco_WhenFirstLampIsEcoLamp_BrightnessIs50()
        {
            // Arrange
            EcoLamp ecoLamp1 = new EcoLamp("Stefano's EcoLamp");
            Lamp lamp2 = new Lamp();
            TwoLampDevice twoLampDevice = new TwoLampDevice(ecoLamp1, lamp2);

            // Act
            twoLampDevice.SetOneEcoLampBrightnessToEco(ecoLamp1);

            // Assert
            Assert.Equal(50, ecoLamp1.BrightnessLevel.Value);
        }

        [Fact]
        public void SetOneEcoLampBrightnessToEco_WhenSecondLampIsEcoLamp_BrightnessIs50()
        {
            // Arrange
            Lamp lamp1 = new Lamp();
            EcoLamp ecoLamp2 = new EcoLamp("Stefano's EcoLamp");
            TwoLampDevice twoLampDevice = new TwoLampDevice(lamp1, ecoLamp2);

            // Act
            twoLampDevice.SetOneEcoLampBrightnessToEco(ecoLamp2);

            // Assert
            Assert.Equal(50, ecoLamp2.BrightnessLevel.Value);
        }

        [Fact]
        public void SetBothEcoLampsBrightnessToEco_WhenBothLampAreEcoLamp_BrightnessIs50()
        {
            // Arrange
            EcoLamp ecoLamp1 = new EcoLamp("Stefano's EcoLamp1");
            EcoLamp ecoLamp2 = new EcoLamp("Stefano's EcoLamp2");
            TwoLampDevice twoLampDevice = new TwoLampDevice(ecoLamp1, ecoLamp2);

            // Act
            twoLampDevice.SetBothEcoLampsBrightnessToEco();

            // Assert
            Assert.Equal(50, ecoLamp1.BrightnessLevel.Value);
            Assert.Equal(50, ecoLamp2.BrightnessLevel.Value);
        }
    }
}