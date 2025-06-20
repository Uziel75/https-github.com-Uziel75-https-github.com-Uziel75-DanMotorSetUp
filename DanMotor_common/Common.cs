using System.Collections.Generic;

namespace DanMotor.Common
{
    public class MotorModel
    {
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Concept { get; set; } = string.Empty;
        public List<string> Parts { get; set; } = new List<string>();
    }
}
