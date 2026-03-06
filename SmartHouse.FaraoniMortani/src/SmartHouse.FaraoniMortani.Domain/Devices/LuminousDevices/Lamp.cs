namespace SmartHouse.FaraoniMortani.Domain.Devices.LuminousDevices
{
    public sealed class Lamp: AbstractLamp
    {
        // Constructors
        public Lamp() { }
        public Lamp(Guid guid, string name) : base(guid, name) { }
        public Lamp(string name) : base(name) { }
        public Lamp(Guid id, string name, Brightness brightness, DateTime creationTime, DateTime lastChangeTime) : base(id, name) { }
    }
}