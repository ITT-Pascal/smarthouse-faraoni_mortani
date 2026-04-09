using SmartHouse.FaraoniMortani.Application.Devices.Door.Commands;
using SmartHouse.FaraoniMortani.Application.Devices.Door.Queries;
using SmartHouse.FaraoniMortani.Application.Devices.DoorDevice.Commands;
using SmartHouse.FaraoniMortani.Application.Devices.DoorDevice.DTO;
using SmartHouse.FaraoniMortani.Application.Devices.LuminousDevice.Lamps.Commands;
using SmartHouse.FaraoniMortani.Application.Devices.LuminousDevice.Lamps.DTO;
using SmartHouse.FaraoniMortani.Application.Devices.LuminousDevice.Lamps.Queries;
using SmartHouse.FaraoniMortani.Domain.Devices.DoorDevice.Repositories;
using SmartHouse.FaraoniMortani.Domain.Devices.LuminousDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Console.Devices.Controllers
{
    internal class DoorController
    {
        private readonly IDoorRepository _repository;

        public DoorController(IDoorRepository repository)
        {
            _repository = repository;
        }

        public void AddDoor()
        {
            System.Console.Write("Door name: ");
            string name = System.Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                System.Console.WriteLine("Invalid name");
                return;
            }

            System.Console.Write("New Password: ");
            string password = System.Console.ReadLine();

            if (string.IsNullOrWhiteSpace(password))
            {
                System.Console.WriteLine("Invalid password");
                return;
            }


            new AddDoorCommand(_repository).Execute(name, password);
            System.Console.WriteLine("Door added");

        }

        public void RemoveDoor()
        {
            var lamp = SelectDoor();

            if (lamp == null)
                return;

            new RemoveDoorCommand(_repository).Execute(lamp.Id);
            System.Console.WriteLine("Door removed");
        }

        public void OpenDoor()
        {
            var door = SelectDoor();

            if (door == null)
                return;

            try
            {
                new OpenDoorCommand(_repository).Execute(door.Id);
                System.Console.WriteLine("Door Opened");
            }
            catch (InvalidOperationException ex)
            {
                System.Console.WriteLine($"ERROR: {ex.Message}");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"ERROR: {ex.Message}");
            }
        }

        public void CloseDoor()
        {
            var door = SelectDoor();

            if (door == null)
                return;

            try
            {
                new CloseDoorCommand(_repository).Execute(door.Id);
                System.Console.WriteLine("Door Closed");
            }
            catch (InvalidOperationException ex)
            {
                System.Console.WriteLine($"ERROR: {ex.Message}");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"ERROR: {ex.Message}");
            }
        }

        public void LockDoor()
        {
            var door = SelectDoor();

            if (door == null)
                return;

            try
            {
                new LockDoorCommand(_repository).Execute(door.Id);
                System.Console.WriteLine("Door Locked");
            }
            catch (InvalidOperationException ex)
            {
                System.Console.WriteLine($"ERROR: {ex.Message}");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"ERROR: {ex.Message}");
            }
        }

        public void UnlockDoor()
        {
            var door = SelectDoor();

            if (door == null)
                return;

            try
            {
                System.Console.Write("Insert password: ");
                string password = System.Console.ReadLine();

                new UnlockDoorCommand(_repository).Execute(door.Id, password);
                System.Console.WriteLine("Door Locked");
            }
            catch (InvalidOperationException ex)
            {
                System.Console.WriteLine($"ERROR: {ex.Message}");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"ERROR: {ex.Message}");
            }
        }

        public void SetPassword()
        {
            var door = SelectDoor();

            if (door == null)
                return;

            try
            {
                System.Console.Write("Door's current password: ");
                string password = System.Console.ReadLine();

                if (string.IsNullOrWhiteSpace(password))
                {
                    System.Console.WriteLine("Invalid Password");
                    return;
                }

                System.Console.Write("Door's new password: ");
                string newPassword = System.Console.ReadLine();

                if (string.IsNullOrWhiteSpace(newPassword))
                {
                    System.Console.WriteLine("Invalid Password");
                    return;
                }

                new SetPasswordCommand(_repository).Execute(door.Id, password, newPassword);
                System.Console.WriteLine("Password updated");
            }
            catch (InvalidOperationException ex)
            {
                System.Console.WriteLine($"ERROR: {ex.Message}");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"ERROR: {ex.Message}");
            }
        }

        public void ShowDoors()
        {
            var doors = new GetAllDoorsQuery(_repository).Execute();

            System.Console.WriteLine("Doors:");
            System.Console.WriteLine("---------------------------------");

            if (doors.Count == 0)
            {
                System.Console.WriteLine("No doors available");
                return;
            }

            for (int i = 0; i < doors.Count; i++)
            {
                var l = doors[i];
                System.Console.WriteLine($"{i + 1}. {l.Name}\n{l}");
            }
        }

        public void ShowMenu()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("1 - Add Door");
            System.Console.WriteLine("2 - Remove Door");
            System.Console.WriteLine("3 - Show Doors");
            System.Console.WriteLine("4 - Open Door");
            System.Console.WriteLine("5 - Close Door");
            System.Console.WriteLine("6 - Lock Door");
            System.Console.WriteLine("7 - Unlock Door");
            System.Console.WriteLine("8 - Set Password");
            System.Console.WriteLine("-----------------------------------");
            System.Console.WriteLine("Press 0 to exit program");
        }

        private DoorDto SelectDoor()
        {
            var doors = new GetAllDoorsQuery(_repository).Execute();

            if (doors.Count == 0)
            {
                System.Console.WriteLine("No doors available");
                return null;
            }

            System.Console.Write("Door number: ");

            int index;
            if (!int.TryParse(System.Console.ReadLine(), out index))
            {
                System.Console.WriteLine("Invalid number");
                return null;
            }

            if (index < 1 || index > doors.Count)
            {
                System.Console.WriteLine("Door not found");
                return null;
            }

            return doors[index - 1];
        }
    }
}
