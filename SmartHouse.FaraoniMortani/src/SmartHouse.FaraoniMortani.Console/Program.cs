using SmartHouse.FaraoniMortani.Console.Devices.Controllers;
using SmartHouse.FaraoniMortani.Domain.Devices.LuminousDevices.Repositories;
using SmartHouse.FaraoniMortani.Infrastructure.Repositories.Devices.LuminousDevice.Lamps.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        InMemoryLampRepository lampRepository = new InMemoryLampRepository();
        LampController lampController = new LampController(lampRepository);

        while (true)
        {
            Console.Clear();
            lampController.ShowLamps();
            lampController.ShowMenu();
            Console.Write("\nScelta: ");
            var scelta = Console.ReadLine();
            Console.WriteLine();

            switch (scelta)
            {
                case "1": lampController.AddLamp(); break;
                case "2": lampController.RemoveLamp(); break;
                case "3": lampController.ShowLamps(); break;
                case "4": lampController.SwitchOn(); break;
                case "5": lampController.SwitchOff(); break;
                case "6": lampController.ChangeBrightness(); break;
                case "7": lampController.Brighten(); break;
                case "8": lampController.Dimmer(); break;
                case "0": return;
                default: Console.WriteLine("Scelta non valida."); break;
            }

            Pause();
        }
    }

    static void Pause()
    {
        Console.WriteLine();
        Console.WriteLine("Press ENTER to continue...");
        Console.ReadLine(); ;
    }

}