namespace SmartHouse.FaraoniMortani.Domain
{
    public class Lamp : AbstractLamp 
    {
        public const int StandardMinimumIntensity = 0;
        public const int StandardMaximumIntensity = 100;
        public int BrightnessLevel { get; private set; }

        public override int MinimumIntensity => StandardMinimumIntensity;
        public override int MaximumIntensity => StandardMaximumIntensity;

        public Lamp()
        {
            IsOn = false;
            Id = new Guid();
            BrightnessLevel = StandardMaximumIntensity;
        }

        public Lamp(string name)
        {
            IsOn = false;
            Id = new Guid();
            Name = name;
            BrightnessLevel = StandardMaximumIntensity;
        }

        public override void Switch()
        {
            IsOn = !IsOn;
        }

        public override void ChangeBrightness(int newBrightnessLevel)
        {

            if(IsOn)
                if (newBrightnessLevel < StandardMinimumIntensity || newBrightnessLevel > StandardMaximumIntensity)
                    throw new ArgumentOutOfRangeException();
                else if (newBrightnessLevel == StandardMinimumIntensity)
                    IsOn = false; 
                else
                    BrightnessLevel = newBrightnessLevel;
        }

        public override void Brighten()
        {
            if (BrightnessLevel + 5 > MaximumIntensity)
            {
                BrightnessLevel = MaximumIntensity;
            }
            else
            {
                BrightnessLevel += 5;
            }
        }
        public override void Dimmer()
        {
            if (BrightnessLevel - 5 < MinimumIntensity)
            {
                BrightnessLevel = MinimumIntensity;
            }
            else
            {
                BrightnessLevel -= 5;
            }
        }
    }
}