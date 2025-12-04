using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Domain.UnitTests.DoorTests
{
    public class DoorTest
    {
        [Fact]
        public void OpenDoor_WhenDoorIsClosedAndUnlocked_DoorCanBeOpened()
        {
            Door door1 = new Door("Main Door", "1234");

            door1.OpenDoor();

            Assert.Equal(DeviceStatus.Open, door1.Status);
        }

        [Fact]
        public void OpenDoor_WhenDoorIsClosedAndLocked_DoorCannotBeOpened()
        {
            Door door1 = new Door("Main Door", "1234");

            door1.LockDoor();

            Assert.Throws<Exception>(() => door1.OpenDoor());
        }

        [Fact]
        public void OpenDoor_WhenDoorIsOpen_DoorCannotBeOpened()
        {
            Door door1 = new Door("Main Door", "1234");

            door1.OpenDoor();

            Assert.Throws<Exception>(() => door1.OpenDoor());
        }

        [Fact]
        public void CloseDoor_WhenDoorIsOpen_DoorCanBeClosed()
        {
            Door door1 = new Door("Main Door", "1234");

            door1.OpenDoor();
            door1.CloseDoor();

            Assert.Equal(DeviceStatus.Closed, door1.Status);
        }

        [Fact]
        public void CloseDoor_WhenDoorIsClosed_DoorCannotBeClosed()
        {
            Door door1 = new Door("Main Door", "1234");

            Assert.Throws<Exception>(() => door1.CloseDoor());
        }

        [Fact]
        public void LockDoor_WhenDoorIsUnlocked_DoorCanBeLocked()
        {
            Door door1 = new Door("Main Door", "1234");

            door1.LockDoor();

            Assert.True(door1.IsLocked);
        }

        [Fact]
        public void LockDoor_WhenDoorIsLocked_DoorCannotBeLocked()
        {
            Door door1 = new Door("Main Door", "1234");

            door1.LockDoor();

            Assert.Throws<Exception>(() => door1.LockDoor());
        }

        [Fact]
        public void UnlockDoor_WhenDoorIsLockedAndPasswordIsCorrect_DoorCanBeUnlocked()
        {
            Door door1 = new Door("Main Door", "1234");

            door1.LockDoor();

            door1.UnlockDoor("1234");

            Assert.False(door1.IsLocked);
        }

        [Fact]
        public void UnlockDoor_WhenDoorIsLockedAndPasswordIsNotCorrect_DoorCannotBeUnlocked()
        {
            Door door1 = new Door("Main Door", "1234");

            door1.LockDoor();

            Assert.Throws<ArgumentException>(() => door1.UnlockDoor("1235"));
            Assert.True(door1.IsLocked);
        }

        [Fact]
        public void UnlockDoor_WhenDoorIsUnlockedt_DoorCannotBeUnlocked()
        {
            Door door1 = new Door("Main Door", "1234");

            Assert.Throws<Exception>(() => door1.UnlockDoor("1234"));
        }

        [Fact]
        public void SetNewDoorPassword_WhenOldPasswordIsCorrect_ChangePassword()
        {
            Door door1 = new Door("Main Door", "1234");

            door1.SetNewDoorPassword("1234", "1050");
            Assert.Equal("1050", door1.Password);
        }

        [Fact]
        public void SetNewDoorPassword_WhenOldPasswordIsIncorrect_ThrowException()
        {
            Door door1 = new Door("Main Door", "1234");

            Assert.Throws<ArgumentException>(() => door1.SetNewDoorPassword("1235", "1050"));
        }
    }
}
