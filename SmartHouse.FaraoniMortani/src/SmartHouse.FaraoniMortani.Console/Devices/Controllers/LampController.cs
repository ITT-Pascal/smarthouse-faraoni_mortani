using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHouse.FaraoniMortani.Application.Devices.LuminousDevice.Lamps.Commands;
using SmartHouse.FaraoniMortani.Application.Devices.LuminousDevice.Lamps.DTO;
using SmartHouse.FaraoniMortani.Application.Devices.LuminousDevice.Lamps.Queries;
using SmartHouse.FaraoniMortani.Domain.Devices.LuminousDevices.Repositories;

namespace SmartHouse.FaraoniMortani.Console.Devices.Controllers
{
    public class LampController
    {
        private readonly ILampRepository _repository;

        public LampController(ILampRepository repository)
        {
            _repository = repository;
        }

        public void AddLamp()
        {
            Console.Write("Lamp Id: ");
            string id = Console.ReadLine();

            if(string.IsNullOrWhiteSpace(id))
            {
                Console.WriteLine("Invalid name");
                return;
            }

            new AddLampCommand(_repository).Execute(id);
            Console.WriteLine("Lamp added");
        }

        public void RemoveLamp()
        {
            Console.Write("Lamp Id: ");
            string id = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(id))
            {
                Console.WriteLine("Invalid Id");
                return;
            }

            new RemoveLampCommand(_repository).Execute(new Guid(id));
            Console.WriteLine("Lamp removed");
        }

        public void Brighten()
        {
            Console.Write("Lamp Id: ");
            string id = Console.ReadLine();

            Console.Write("Insert amount: ");
            int amount = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(id))
            {
                Console.WriteLine("Invalid Id");
                return;
            }

            new BrightenLampCommand(_repository).Execute(new Guid(id), amount);
            Console.WriteLine("Lamp brightness increased");
        }

        public void Dimmer()
        {
            Console.Write("Lamp Id: ");
            string id = Console.ReadLine();

            Console.Write("Insert amount: ");
            int amount = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(id))
            {
                Console.WriteLine("Invalid Id");
                return;
            }

            new DimmerLampCommand(_repository).Execute(new Guid(id), amount);
            Console.WriteLine("Lamp brightness decreased");
        }

        public void SwitchOn()
        {
            Console.Write("Lamp Id: ");
            string id = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(id))
            {
                Console.WriteLine("Invalid Id");
                return;
            }

            new SwitchLampOnCommand(_repository).Execute(new Guid(id));
            Console.WriteLine("Lamp has turned on");
        }

        public void SwitchOff()
        {
            Console.Write("Lamp Id: ");
            string id = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(id))
            {
                Console.WriteLine("Invalid Id");
                return;
            }

            new SwitchLampOffCommand(_repository).Execute(new Guid(id));
            Console.WriteLine("Lamp has turned off");
        }

        public void ShowLamps()
        {
            var lamps = new GetAllLampsQuery(_repository).Execute();

            Console.WriteLine("Lamps:");
            Console.WriteLine("---------------------------------");

            if (lamps.Count == 0)
            {
                Console.WriteLine("No lamps available");
                return;
            }

            for (int i = 0; i < lamps.Count; i++)
            {
                var l = lamps[i];
                Console.WriteLine($"{i + 1}. {l.Name}\n{l}");
            }
        }
    }
}
