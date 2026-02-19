namespace SmartHouse.FaraoniMortani.Domain.Devices.LuminousDevices
{
    public sealed class Lamp: AbstractLamp
    {
        // Constructors
        public Lamp() { }
        public Lamp(Guid guid, string name) : base(guid, name) { }
        public Lamp(string name) : base(name) { }
    }
}