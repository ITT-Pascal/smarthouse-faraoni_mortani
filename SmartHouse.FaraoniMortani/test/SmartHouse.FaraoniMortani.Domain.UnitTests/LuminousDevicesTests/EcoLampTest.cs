using SmartHouse.FaraoniMortani.Domain.Devices.Abstractions;
using SmartHouse.FaraoniMortani.Domain.Devices.LuminousDevices;
using SmartHouse.FaraoniMortani.Domain.LuminousDevices;
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
        public void Switch_WhenSwitchIsUsedAndLampIsTurnedOff_IsOnIsTrue()
        {
            // Arrange
            EcoLamp ecoLamp = new EcoLamp("Stefano's EcoLamp");

            // Act
            ecoLamp.Toggle();

            // Assert
            Assert.Equal(DeviceStatus.On, ecoLamp.Status);
        }

        [Fact]
        public void Switch_WhenSwitchIsUsedAndLampIsTurnedOn_IsOnIsFalse()
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
        public void ChangeBrightness_WhenBrightnessLevelIsSetTo70AssignBrightnessValue()
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
        public void ChangeBrightness_WhenBrightnessLevelIsSetToANegativeNumberSelectionIsNotChanged()
        {
            // Arrange
            EcoLamp ecoLamp = new EcoLamp("Stefano's EcoLamp");
            
            // Act
            ecoLamp.Toggle();

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => ecoLamp.SetBrightness(new Brightness(-1)));
        }

        [Fact]
        public void TurnOffAfterTime_IfTheLampIsOff_ItDoesNotSwitch()
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