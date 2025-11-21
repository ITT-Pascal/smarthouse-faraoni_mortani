using System.Security.Cryptography.X509Certificates;

namespace SmartHouse.FaraoniMortani.Domain.UnitTests
{
    public class LampTest
    {
        [Fact]
        public void Switch_WhenSwitchIsUsedAndLampIsTurnedOff_IsOnIsTrue()
        {
            // Arrange
            Lamp lamp = new Lamp();

            // Act
            lamp.Switch();

            // Assert
            Assert.True(lamp.IsOn);
        }

        [Fact]
        public void Switch_WhenSwitchIsUsedAndLampIsTurnedOn_IsOnIsFalse()
        {
            // Arrange
            Lamp lamp = new Lamp();

            // Act
            lamp.Switch();
            lamp.Switch();

            // Assert
            Assert.False(lamp.IsOn);
        }

        [Fact]
        public void ChangeBrightness_WhenBrightnessLevelIsSetTo100AssignBrightnessValue()
        {
            Lamp lamp = new Lamp();
            lamp.Switch();
            lamp.ChangeBrightness(100);

            Assert.Equal(100, lamp.BrightnessLevel);
        }

        [Fact]
        public void ChangeBrightness_WhenBrightnessLevelIsSetTo0LampGetsTurnedOff()
        {
            Lamp lamp = new Lamp();
            lamp.Switch();
            lamp.ChangeBrightness(0);

            Assert.False(lamp.IsOn);
        }

        [Fact]
        public void ChangeBrightness_WhenBrightnessLevelIsSetToANegativeNumberThrowArgument()
        {
            Lamp lamp = new Lamp();
            lamp.Switch();
            Assert.Throws<ArgumentOutOfRangeException>(() => lamp.ChangeBrightness(-1));
        }

        [Fact]
        public void ChangeBrightness_WhenBrightnessLevelIsSetToANumberGreaterThanMaximumLimitThrowArgument()
        {
            Lamp lamp = new Lamp();
            lamp.Switch();
            Assert.Throws<ArgumentOutOfRangeException>(() => lamp.ChangeBrightness(101));
        }
    }
}