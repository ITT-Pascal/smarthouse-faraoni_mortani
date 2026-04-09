using Smarthouse.FaraoniMortani.Infrastructure.Repositories.Devices.DoorDevice.InMemory;
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
        InMemoryLampRepository lampRepository;
        LampController lampController;

        InMemoryDoorRepository doorRepository;
        DoorController doorController;

        Console.Clear();
        Console.WriteLine("Select one of the following devices to manage");
        Console.WriteLine("1) Lamp");
        Console.WriteLine("2) Door");
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("Press 0 to exit program");
        var menuSelection = Console.ReadLine();

        switch(menuSelection)
        {
            case "1":
                while (true)
                {
                    lampRepository = new InMemoryLampRepository();
                    lampController = new LampController(lampRepository);

                    Console.Clear();
                    lampController.ShowLamps();
                    lampController.ShowMenu();
                    Console.Write("\nChoice: ");
                    var choice = Console.ReadLine();
                    Console.WriteLine();

                    switch (choice)
                    {
                        case "1": lampController.AddLamp(); break;
                        case "2": lampController.RemoveLamp(); break;
                        case "3": lampController.ShowLamps(); break;
                        case "4": lampController.SwitchOn(); break;
                        case "5": lampController.SwitchOff(); break;
                        case "6": lampController.ChangeBrightness(); break;
                        case "7": lampController.Brighten(); break;
                        case "8": lampController.Dimmer(); break;
                        case "0": Console.WriteLine("Exiting program..."); return;
                        default: Console.WriteLine("Invalid Choice."); break;
                    }

                    Pause();
                }

            case "2":
                while (true)
                {
                    doorRepository = new InMemoryDoorRepository();
                    doorController = new DoorController(doorRepository);

                    Console.Clear();
                    doorController.ShowDoors();
                    doorController.ShowMenu();
                    Console.Write("\nChoice: ");
                    var choice = Console.ReadLine();
                    Console.WriteLine();

                    switch (choice)
                    {
                        case "1": doorController.AddDoor(); break;
                        case "2": doorController.RemoveDoor(); break;
                        case "3": doorController.ShowDoors(); break;
                        case "4": doorController.OpenDoor(); break;
                        case "5": doorController.CloseDoor(); break;
                        case "6": doorController.LockDoor(); break;
                        case "7": doorController.UnlockDoor(); break;
                        case "8": doorController.SetPassword(); break;
                        case "0": Console.WriteLine("Exiting program..."); return;
                        default: Console.WriteLine("Invalid Choice."); break;
                    }

                    Pause();
                }

            case "0":
                Console.WriteLine("Exiting program...");
                return;

            default:
                Console.WriteLine("Invalid Choice.");
                break;
        }
    }

    static void Pause()
    {
        Console.WriteLine();
        Console.WriteLine("Press ENTER to continue...");
        Console.ReadLine(); ;
    }
}