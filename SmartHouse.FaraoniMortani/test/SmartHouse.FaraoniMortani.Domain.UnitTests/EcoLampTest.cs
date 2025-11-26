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
            EcoLamp ecoLamp = new EcoLamp();

            // Act
            ecoLamp.Switch();

            // Assert
            Assert.True(ecoLamp.IsOn);
        }

        [Fact]
        public void Switch_WhenSwitchIsUsedAndLampIsTurnedOn_IsOnIsFalse()
        {
            // Arrange
            EcoLamp ecoLamp = new EcoLamp();

            // Act
            ecoLamp.Switch();
            ecoLamp.Switch();

            // Assert
            Assert.False(ecoLamp.IsOn);

        }

        [Fact]
        public void ChangeBrightness_WhenBrightnessLevelIsSetTo70AssignBrightnessValue()
        {
            // Arrange
            EcoLamp ecoLamp = new EcoLamp();

            // Act
            ecoLamp.Switch();
            ecoLamp.ChangeBrightness(70);

            // Assert
            Assert.Equal(70, ecoLamp.BrightnessLevel);
        }

        [Fact]
        public void ChangeBrightness_WhenBrightnessLevelIsSetTo0LampGetsTurnedOff()
        {
            // Arrange
            EcoLamp ecoLamp = new EcoLamp();

            // Act
            ecoLamp.Switch();
            ecoLamp.ChangeBrightness(0);

            // Assert
            Assert.False(ecoLamp.IsOn);
        }

        [Fact]
        public void ChangeBrightness_WhenBrightnessLevelIsSetToANegativeNumberSelectionIsNotChanged()
        {
            // Arrange
            EcoLamp ecoLamp = new EcoLamp();
            
            // Act
            ecoLamp.Switch();

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => ecoLamp.ChangeBrightness(-1));
        }

        //TODO:  Complete Test function TurnOffAfterTime (At least four tests)

        [Fact]
        public void TurnOffAfterTime_IfTheLampIsOff_ItDoesNotSwitch()
        {
            // Arrange
            EcoLamp ecoLamp = new EcoLamp();
            DateTime time = DateTime.UtcNow;

            // Act
            ecoLamp.TurnOffAfterTime(time, 30);

            // Assert
            Assert.False(ecoLamp.IsOn);
        }

        [Fact]
        public void TurnOffAfterTime_w()
        {
            // Arrange
            EcoLamp ecolamp = new EcoLamp();

            // Act

        }

        [Fact]
        public void TurnOffAfterTime_y()
        {
            // Arrange
            EcoLamp ecolamp = new EcoLamp();
        
            // Act
        
        }

        [Fact]
        public void TurnOffAfterTime_t()
        {
            // Arrange
            EcoLamp ecolamp = new EcoLamp();

            // Act
        }
    }
}