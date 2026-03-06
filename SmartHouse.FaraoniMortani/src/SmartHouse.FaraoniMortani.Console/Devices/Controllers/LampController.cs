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
            System.Console.Write("Lamp Id: ");
            string id = System.Console.ReadLine();

            if(string.IsNullOrWhiteSpace(id))
            {
                System.Console.WriteLine("Invalid name");
                return;
            }

            new AddLampCommand(_repository).Execute(id);
            System.Console.WriteLine("Lamp added");
        }

        public void RemoveLamp()
        {
            System.Console.Write("Lamp Id: ");      
            string id = System.Console.ReadLine();

            if (string.IsNullOrWhiteSpace(id))
            {
                System.Console.WriteLine("Invalid Id");
                return;
            }

            new RemoveLampCommand(_repository).Execute(new Guid(id));
            System.Console.WriteLine("Lamp removed");
        }

        public void Brighten()
        {
            System.Console.Write("Lamp Id: ");
            string id = System.Console.ReadLine();

            System.Console.Write("Insert amount: ");
            int amount = Convert.ToInt16(System.Console.ReadLine());

            if (string.IsNullOrWhiteSpace(id))
            {
                System.Console.WriteLine("Invalid Id");
                return;
            }

            new BrightenLampCommand(_repository).Execute(new Guid(id), amount);
            System.Console.WriteLine("Lamp brightness increased");
        }

        public void Dimmer()
        {
            System.Console.Write("Lamp Id: ");
            string id = System.Console.ReadLine();

            System.Console.Write("Insert amount: ");
            int amount = Convert.ToInt16(System.Console.ReadLine());

            if (string.IsNullOrWhiteSpace(id))
            {
                System.Console.WriteLine("Invalid Id");
                return;
            }

            new DimmerLampCommand(_repository).Execute(new Guid(id), amount);
            System.Console.WriteLine("Lamp brightness decreased");
        }
        public void ChangeBrightness()
        {
            var lamp = SelectLamp();
            if (lamp == null) return;

            System.Console.Write("New brightness (0-100): ");

            int intensity;
            if (!int.TryParse(System.Console.ReadLine(), out intensity))
            {
                System.Console.WriteLine("Invalid value");
                return;
            }

            try
            {
                new SetCustomBrightnessCommand(_repository).Execute(lamp.Id, intensity);
                System.Console.WriteLine("Intensity updated");
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

        public void SwitchOn()
        {
            System.Console.Write("Lamp Id: ");
            string id = System.Console.ReadLine();

            if (string.IsNullOrWhiteSpace(id))
            {
                System.Console.WriteLine("Invalid Id");
                return;
            }

            new SwitchLampOnCommand(_repository).Execute(new Guid(id));
            System.Console.WriteLine("Lamp has turned on");

        }

        public void SwitchOff()
        {
            System.Console.Write("Lamp Id: ");
            string id = System.Console.ReadLine();

            if (string.IsNullOrWhiteSpace(id))
            {
                System.Console.WriteLine("Invalid Id");
                return;
            }

            new SwitchLampOffCommand(_repository).Execute(new Guid(id));
            System.Console.WriteLine("Lamp has turned off");
        }

        public void ShowLamps()
        {
            var lamps = new GetAllLampsQuery(_repository).Execute();

            System.Console.WriteLine("Lamps:");
            System.Console.WriteLine("---------------------------------");

            if (lamps.Count == 0)
            {
                System.Console.WriteLine("No lamps available");
                return;
            }

            for (int i = 0; i < lamps.Count; i++)
            {
                var l = lamps[i];
                System.Console.WriteLine($"{i + 1}. {l.Name}\n{l}");
            }
        }

        public void ShowMenu()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("1 - Add Lamp");
            System.Console.WriteLine("2 - Remove Lamp");
            System.Console.WriteLine("3 - Show Lamps");
            System.Console.WriteLine("4 - Switch On");
            System.Console.WriteLine("5 - Switch Off");
            System.Console.WriteLine("6 - Change Brightness");
            System.Console.WriteLine("7 - Brighten");
            System.Console.WriteLine("8 - Dimmer");



        }
        private LampDto SelectLamp()
        {
            var lamps = new GetAllLampsQuery(_repository).Execute();

            if (lamps.Count == 0)
            {
                System.Console.WriteLine("No lamps available");
                return null;
            }

            System.Console.Write("Lamp number: ");
            string strIndex = System.Console.ReadLine();

            int index;
            if (!int.TryParse(strIndex, out index))
            {
                System.Console.WriteLine("Invalid number");
                return null;
            }

            if (index < 1 || index > lamps.Count)
            {
                System.Console.WriteLine("Lamp not found");
                return null;
            }

            return lamps[index - 1];
        }
    }
}
