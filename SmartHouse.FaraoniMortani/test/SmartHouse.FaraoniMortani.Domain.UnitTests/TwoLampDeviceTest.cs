using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Domain.UnitTests
{
    public class TwoLampDeviceTest
    {
        // Adjust This two tests

        [Fact]
        public void TurnBothOn_WhenBothLampsGetTurnedOn_BothLampsHaveGetIsOnTrue()
        {
            // Arrange
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            TwoLampDevice twoLampDevice = new TwoLampDevice(lamp1, lamp2);

            // Act
            twoLampDevice.TurnBothLightsOn();

            // Assert

            Assert.True(lamp1.GetIsOn());
            Assert.True(lamp2.GetIsOn());

        }

        [Fact]
        public void TurnBothOff_WhenBothLampsGetTurnedOff_BothLampsHaveGetIsOnFalse()
        {
            // Arrange
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            TwoLampDevice twoLampDevice = new TwoLampDevice(lamp1, lamp2);

            // Act
            twoLampDevice.TurnBothLightsOff();

            // Assert

            Assert.False(lamp1.GetIsOn());
            Assert.False(lamp2.GetIsOn());

        }

        [Fact]
        public void TurnOnlyFirst_WhenFirstLampGetTurnedOn_OnlyFirstLampHaveGetIsOnTrue()
        {
            // Arrange
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            TwoLampDevice twoLampDevice = new TwoLampDevice(lamp1, lamp2);

            // Act
            twoLampDevice.TurnOnlyFirstLight();

            // Assert

            Assert.True(lamp1.GetIsOn());
            Assert.False(lamp2.GetIsOn());

        }

        [Fact]
        public void TurnOnlySecond_WhenSecondLampGetTurnedOn_OnlySecondLampHaveGetIsOnTrue()
        {
            // Arrange
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            TwoLampDevice twoLampDevice = new TwoLampDevice(lamp1, lamp2);

            // Act
            twoLampDevice.TurnOnlySecondLight();

            // Assert

            Assert.False(lamp1.GetIsOn());
            Assert.True(lamp2.GetIsOn());

        }



    }
}
