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
        public void TurnBothLampsOn_WhenBothLampsGetTurnedOn_BothLampsHaveGetIsOnTrue()
        {
            // Arrange
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            TwoLampDevice twoLampDevice = new TwoLampDevice(lamp1, lamp2);

            // Act
            twoLampDevice.TurnBothLampsOn();

            // Assert

            Assert.True(lamp1.IsOn);
            Assert.True(lamp2.IsOn);

        }

        [Fact]
        public void TurnBothLampsOff_WhenBothLampsGetTurnedOff_BothLampsHaveGetIsOnFalse()
        {
            // Arrange
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            TwoLampDevice twoLampDevice = new TwoLampDevice(lamp1, lamp2);

            // Act
            twoLampDevice.TurnBothLampsOff();

            // Assert

            Assert.False(lamp1.IsOn);
            Assert.False(lamp2.IsOn);

        }

        [Fact]
        public void TurnOnlyFirstLampOn_WhenFirstLampGetTurnedOn_FirstLampHaveGetIsOnTrue()
        {
            // Arrange
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            TwoLampDevice twoLampDevice = new TwoLampDevice(lamp1, lamp2);

            // Act
            twoLampDevice.TurnOnlyFirstLampOn();

            // Assert
            Assert.True(lamp1.IsOn);

        }

        [Fact]
        public void TurnOnlySecondLampOn_WhenSecondLampGetTurnedOn_SecondLampHaveGetIsOnTrue()
        {
            // Arrange
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            TwoLampDevice twoLampDevice = new TwoLampDevice(lamp1, lamp2);

            // Act
            twoLampDevice.TurnOnlySecondLampOn();

            // Assert
            Assert.True(lamp2.IsOn);

        }



    }
}
