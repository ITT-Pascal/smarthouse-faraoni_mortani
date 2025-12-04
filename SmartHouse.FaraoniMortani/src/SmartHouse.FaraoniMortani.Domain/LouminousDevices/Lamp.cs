namespace SmartHouse.FaraoniMortani.Domain
{
    public class Lamp : AbstractLamp
    {
        // Constructors
        public Lamp() { }
        public Lamp(Guid guid, string name) : base(guid, name) { }
        public Lamp(string name) : base(name) { }

    }
}