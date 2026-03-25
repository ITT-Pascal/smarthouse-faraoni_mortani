using SmartHouse.FaraoniMortani.Domain.Devices.LuminousDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Domain.Devices.DoorDevice.Repositories
{
    public interface IDoorRepository
    {
        void Add(Door newDoor);
        void Delete(Door newDoor);
        void Update(Door newDoor);
        void Open();
        void Close();
        void Lock();
        void Unlock(string password);
        void SetPassword(string currentPassword, string newPassword);
        Door GetById(Guid id);
        List<Door> GetAll();
    }
}
