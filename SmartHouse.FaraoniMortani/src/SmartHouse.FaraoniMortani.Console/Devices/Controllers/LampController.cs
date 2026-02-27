using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Devices.LuminousDevice.Lamps.Commands;
using Application.Devices.LuminousDevice.Lamps.DTO;
using Application.Devices.LuminousDevice.Lamps.Queries;
using SmartHouse.FaraoniMortani.Application.Devices.LuminousDevice.Lamps.Commands;
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
            Console.Write("Lamp name: ");
            string name = Console.ReadLine();

            if(string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Invalid name");
                return;
            }

            new AddLampCommand(_repository).Execute(name: name);
            Console.WriteLine("Lamp added");
        }
    }
}
