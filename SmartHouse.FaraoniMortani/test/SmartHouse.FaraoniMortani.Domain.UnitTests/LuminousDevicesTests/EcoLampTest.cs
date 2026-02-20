using SmartHouse.FaraoniMortani.Domain.Devices.Abstractions;
using SmartHouse.FaraoniMortani.Domain.Devices.LuminousDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Domain.UnitTests
{
    public class EcoLampTest
    {
        [Fact]
        public void Toggle_WhenToggleIsUsedAndLampIsTurnedOff_LampIsTurnedOn()
        {
            // Arrange
            EcoLamp ecoLamp = new EcoLamp("Stefano's EcoLamp");

            // Act
            ecoLamp.Toggle();

            // Assert
            Assert.Equal(DeviceStatus.On, ecoLamp.Status);
        }

        [Fact]
        public void Toggle_WhenToggleIsUsedAndLampIsTurnedOn_LampIsTurnedOff()
        {
            // Arrange
            EcoLamp ecoLamp = new EcoLamp("Stefano's EcoLamp");

            // Act
            ecoLamp.Toggle();
            ecoLamp.Toggle();

            // Assert
            Assert.Equal(DeviceStatus.Off, ecoLamp.Status);

        }

        [Fact]
        public void ChangeBrightness_WhenBrightnessLevelIsSetTo70BrightnessValueBecomes70()
        {
            // Arrange
            EcoLamp ecoLamp = new EcoLamp("Stefano's EcoLamp");

            // Act
            ecoLamp.Toggle();
            ecoLamp.SetBrightness(new Brightness(70));

            // Assert
            Assert.Equal(70, ecoLamp.BrightnessLevel.Value);
        }

        [Fact]
        public void ChangeBrightness_WhenBrightnessLevelIsSetTo0LampGetsTurnedOff()
        {
            // Arrange
            EcoLamp ecoLamp = new EcoLamp("Stefano's EcoLamp");

            // Act
            ecoLamp.Toggle();
            ecoLamp.SetBrightness(new Brightness(0));

            // Assert
            Assert.Equal(DeviceStatus.Off, ecoLamp.Status);
        }

        [Fact]
        public void ChangeBrightness_WhenBrightnessLevelIsSetToANegativeNumberThrowException()
        {
            // Arrange
            EcoLamp ecoLamp = new EcoLamp("Stefano's EcoLamp");
            
            // Act
            ecoLamp.Toggle();

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => ecoLamp.SetBrightness(new Brightness(-1)));
        }

        [Fact]
        public void TurnOffAfterTime_IfTheLampIsOff_LampIsNotSwitchedOn()
        {
            // Arrange
            EcoLamp ecoLamp = new EcoLamp("Stefano's EcoLamp");
            DateTime time = DateTime.UtcNow;

            // Act
            ecoLamp.TurnOffAfterTime();

            // Assert
            Assert.Equal(DeviceStatus.Off, ecoLamp.Status);
        }
    }
}