namespace DanMotor
{
    public class DanMotor_BusinessData
    {
        public string GetThailandMotor(int choice)
        {
            return choice switch
            {
                1 => "Rimset 17's",
                2 => "Lowered, open canister",
                3 => "Lighten Swing Arm/Fairing",
                _ => "Invalid Thailand Motor setup"
            };
        }

        public string GetIndonesiaMotor(int choice)
        {
            return choice switch
            {
                1 => "Mags 14's",
                2 => "Lowered",
                3 => "Alloy crank",
                _ => "Invalid Indonesia Motor setup"
            };
        }

        public string GetMalaysiaMotor(int choice)
        {
            return choice switch
            {
                1 => "CNC Mags 14's",
                2 => "Nickel GP4 Caliper",
                3 => "Racing clutch",
                _ => "Invalid Malaysia Motor setup"
            };
        }
    }
}
