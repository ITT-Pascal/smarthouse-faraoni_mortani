namespace SmartHouse.FaraoniMortani.Domain
{
    public class Lamp
    {
        public int BrightnessLevel { get; private set; }
        private bool IsOn { get; set; }
        


        public Lamp()
        {
            IsOn = false;
            BrightnessLevel = 50;
        }


        public void Switch()
        {
            if (IsOn)
            {
                IsOn = false;
            }
            else
            {
                IsOn = true;
            }

        }


        public void ChangeBrightness(int newBrightnessLevel)
        {
            if(newBrightnessLevel <= 0 && newBrightnessLevel > 100)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                BrightnessLevel = newBrightnessLevel;
            }
                
        }

    }

}