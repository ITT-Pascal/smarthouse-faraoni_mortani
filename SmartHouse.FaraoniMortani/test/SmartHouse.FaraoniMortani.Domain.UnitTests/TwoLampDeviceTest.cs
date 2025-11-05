using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Domain.UnitTests
{
    public class TwoLampDeviceTest
    {
        [Fact]
        public void TurnBothOn_WhenBothLampsGetTurnedOn_BothLampsAreTurnedOn()
        {
            // Arrange
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            TwoLampDevice twoLampDevice = new TwoLampDevice(lamp1, lamp2);

            // Act
            twoLampDevice.TurnBothOn();

            // Assert

            Assert.True(lamp1.IsOn);
            Assert.True(lamp2.IsOn);

        }
    }
}
