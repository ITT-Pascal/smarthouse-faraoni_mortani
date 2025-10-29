namespace SmartHouse.FaraoniMortani.Domain
{
    public class Lamp
    {

        // Mode can be: normal, focused and flashing
        public string? _mode;
        public bool IsOn { get; private set; }


        public void TurnOn()
        {
            IsOn = true;
            _mode = "Normal";
        }
        

        public void TurnOff()
        { 
            IsOn = false;
        }


        public void ChangeMode(string newMode)
        {
            // Accepts only the three modes
            // Can be done different
            if (newMode == "Normal" || newMode == "Focused" || newMode == "Flashing")
            {
                _mode = newMode;
            }
        }
        
    }
}
