namespace SmartHouse.FaraoniMortani.Domain
{
    public class Lamp : AbstractLamp 
    {
        public int BrightnessLevel { get; private set; }

        public Lamp()
        {
            IsOn = false;
            Id = new Guid();
            BrightnessLevel = 100;
        }

        public Lamp(string name)
        {
            IsOn = false;
            Id = new Guid();
            Name = name;
            BrightnessLevel = 100;
        }

        public override void Switch()
        {
            IsOn = !IsOn;
        }

        public override void ChangeBrightness(int newBrightnessLevel)
        {

            if(IsOn)
                if (newBrightnessLevel < 0 || newBrightnessLevel > 100)
                    throw new ArgumentOutOfRangeException();
                else if (newBrightnessLevel == 0)
                    IsOn = false; 
                else
                    BrightnessLevel = newBrightnessLevel;
      
        }
    }
}