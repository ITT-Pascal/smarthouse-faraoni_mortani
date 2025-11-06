namespace SmartHouse.FaraoniMortani.Domain
{
    public class Lamp : AbstractLamp 
    {
        public int BrightnessLevel { get; private set; }
        private bool IsOn { get;  set; }

        public override bool GetIsOn()
        {
            return IsOn;
        }

        public Lamp()
        {
            IsOn = false;
            BrightnessLevel = 50;
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