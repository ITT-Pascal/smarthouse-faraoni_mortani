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
            // Arrange
            Door door1 = new Door("Stefano's Door", "1234");

            // Act
            door1.OpenDoor();

            // Assert
            Assert.Equal(DeviceStatus.Open, door1.Status);
        }

        [Fact]
        public void OpenDoor_WhenDoorIsClosedAndLocked_DoorCannotBeOpened()
        {
            // Arrange
            Door door1 = new Door("Stefano's Door", "1234");

            // Act
            door1.Lock();

            // Assert
            Assert.Throws<Exception>(() => door1.OpenDoor());
        }

        [Fact]
        public void OpenDoor_WhenDoorIsOpen_DoorCannotBeOpened()
        {
            // Arrange
            Door door1 = new Door("Stefano's Door", "1234");

            // Act
            door1.OpenDoor();

            // Assert
            Assert.Throws<Exception>(() => door1.OpenDoor());
        }

        [Fact]
        public void CloseDoor_WhenDoorIsOpen_DoorCanBeClosed()
        {
            // Arrange
            Door door1 = new Door("Stefano's Door", "1234");

            // Act
            door1.OpenDoor();
            door1.CloseDoor();

            // Assert
            Assert.Equal(DeviceStatus.Closed, door1.Status);
        }

        [Fact]
        public void CloseDoor_WhenDoorIsClosed_DoorCannotBeClosed()
        {
            // Arrange
            Door door1 = new Door("Stefano's Door", "1234");

            // Assert
            Assert.Throws<Exception>(() => door1.CloseDoor());
        }

        [Fact]
        public void LockDoor_WhenDoorIsUnlocked_DoorCanBeLocked()
        {
            // Arrange
            Door door1 = new Door("Stefano's Door", "1234");

            // Act
            door1.Lock();

            // Assert
            Assert.True(door1.IsLocked);
        }

        [Fact]
        public void LockDoor_WhenDoorIsLocked_DoorCannotBeLocked()
        {
            // Arrange
            Door door1 = new Door("Stefano's Door", "1234");

            // Act
            door1.Lock();

            // Assert
            Assert.Throws<Exception>(() => door1.Lock());
        }

        [Fact]
        public void UnlockDoor_WhenDoorIsLockedAndPasswordIsCorrect_DoorCanBeUnlocked()
        {
            // Arrange
            Door door1 = new Door("Stefano's Door", "1234");

            // Act
            door1.Lock();
            door1.Unlock("1234");

            // Assert
            Assert.False(door1.IsLocked);
        }

        [Fact]
        public void UnlockDoor_WhenDoorIsLockedAndPasswordIsNotCorrect_DoorCannotBeUnlocked()
        {
            // Arrange
            Door door1 = new Door("Stefano's Door", "1234");

            // Act
            door1.Lock();

            // Assert
            Assert.Throws<ArgumentException>(() => door1.Unlock("1235"));
            Assert.True(door1.IsLocked);
        }

        [Fact]
        public void UnlockDoor_WhenDoorIsUnlockedt_DoorCannotBeUnlocked()
        {    
            // Arrange
            Door door1 = new Door("Stefano's Door", "1234");
                
            // Assert
            Assert.Throws<Exception>(() => door1.Unlock("1234"));
        }

        [Fact]
        public void SetNewDoorPassword_WhenOldPasswordIsCorrect_ChangePassword()
        {
            // Arrange
            Door door1 = new Door("Stefano's Door", "1234");

            // Assert
            door1.SetNewDoorPassword("1234", "1050");
            Assert.Equal("1050", door1.Password);
        }

        [Fact]
        public void SetNewDoorPassword_WhenOldPasswordIsIncorrect_ThrowException()
        {
            // Arrange
            Door door1 = new Door("Stefano's Door", "1234");
            
            // Assert
            Assert.Throws<ArgumentException>(() => door1.SetNewDoorPassword("1235", "1050"));
        }
    }
}
