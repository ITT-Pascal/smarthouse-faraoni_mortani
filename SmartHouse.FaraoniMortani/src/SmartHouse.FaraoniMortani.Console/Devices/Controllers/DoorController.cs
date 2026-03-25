using SmartHouse.FaraoniMortani.Application.Devices.Door.Commands;
using SmartHouse.FaraoniMortani.Application.Devices.Door.Queries;
using SmartHouse.FaraoniMortani.Application.Devices.DoorDevice.Commands;
using SmartHouse.FaraoniMortani.Application.Devices.DoorDevice.DTO;
using SmartHouse.FaraoniMortani.Application.Devices.LuminousDevice.Lamps.Commands;
using SmartHouse.FaraoniMortani.Application.Devices.LuminousDevice.Lamps.DTO;
using SmartHouse.FaraoniMortani.Application.Devices.LuminousDevice.Lamps.Queries;
using SmartHouse.FaraoniMortani.Domain.Devices.DoorDevice.Repositories;
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

            System.Console.Write("New Pin: ");
            if (!int.TryParse(System.Console.ReadLine(), out int pin))
            {
                System.Console.WriteLine("Invalid Pin");
                return;
            }

            new AddDoorCommand(_repository).Execute(name, pin);
            System.Console.WriteLine("Door added!");

        }

        public void OpenDoor()
        {
            System.Console.Write("Door Id: ");
            string id = System.Console.ReadLine();

            if (string.IsNullOrWhiteSpace(id))
            {
                System.Console.WriteLine("Invalid name");
                return;
            }
            
            new OpenDoorCommand(_repository).Execute(new Guid(id));
            System.Console.WriteLine("Door opened");
        }

        public void CloseDoor()
        {
            System.Console.Write("Door Id: ");
            string id = System.Console.ReadLine();

            if (string.IsNullOrWhiteSpace(id))
            {
                System.Console.WriteLine("Invalid Id");
                return;
            }

            new CloseDoorCommand(_repository).Execute(new Guid(id));
            System.Console.WriteLine("Door closed");
        }

        public void LockDoor()
        {
            System.Console.Write("Door Id: ");
            string id = System.Console.ReadLine();

            if (string.IsNullOrWhiteSpace(id))
            {
                System.Console.WriteLine("Invalid Id");
                return;
            }

            new LockDoorCommand(_repository).Execute(new Guid(id));
            System.Console.WriteLine("Door locked");
        }

        public void UnlockDoor()
        {
            System.Console.Write("Door Id: ");
            string id = System.Console.ReadLine();

            if (string.IsNullOrWhiteSpace(id))
            {
                System.Console.WriteLine("Invalid Id");
                return;
            }

            System.Console.Write("Door password: ");
            string password = System.Console.ReadLine();

            if (string.IsNullOrWhiteSpace(password))
            {
                System.Console.WriteLine("Invalid Password");
                return;
            }

            new UnlockDoorCommand(_repository).Execute(new Guid(id), password);
            System.Console.WriteLine("Door unlocked");
        }

        public void SetPassword()
        {
            System.Console.Write("Door Id: ");
            string id = System.Console.ReadLine();

            if (string.IsNullOrWhiteSpace(id))
            {
                System.Console.WriteLine("Invalid Id");
                return;
            }

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

            new SetPasswordCommand(_repository).Execute(new Guid(id), password, newPassword);
            System.Console.WriteLine("Password updated");
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
