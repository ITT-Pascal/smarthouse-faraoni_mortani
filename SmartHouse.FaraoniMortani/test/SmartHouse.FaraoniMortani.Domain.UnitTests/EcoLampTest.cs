using System;
using System.Collections.Generic;
using System.Linq;
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
            Assert.True(ecoLamp.GetIsOn());
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
            Assert.False(ecoLamp.GetIsOn());

        }

        [Fact]
        public void ChangeBrightness_WhenBrightnessLevelIsSetTo100AssignBrightnessValue()
        {
            EcoLamp ecoLamp = new EcoLamp();

            ecoLamp.Switch();
            ecoLamp.ChangeBrightness(100);

            Assert.Equal(100, ecoLamp.BrightnessLevel);
        }

        [Fact]
        public void ChangeBrightness_WhenBrightnessLevelIsSetTo0LampGetsTurnedOff()
        {
            EcoLamp ecoLamp = new EcoLamp();

            ecoLamp.Switch();
            ecoLamp.ChangeBrightness(0);

            Assert.False(ecoLamp.GetIsOn());
        }

        [Fact]
        public void ChangeBrightness_WhenBrightnessLevelIsSetToANegativeNumberSelectionIsNot()
        {
            EcoLamp ecoLamp = new EcoLamp();
            ecoLamp.Switch();
            Assert.Throws<ArgumentOutOfRangeException>(() => ecoLamp.ChangeBrightness(-1));
        }

        //TODO: Test function TurnOffAfterTime (At least four tests)

        

        
    }
}
