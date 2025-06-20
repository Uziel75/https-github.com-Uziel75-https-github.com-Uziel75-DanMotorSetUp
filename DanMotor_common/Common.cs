using System.Collections.Generic;

namespace DanMotor.Common
{
    public class MotorModel
    {
        public string Brand { get; set; } = "";
        public string Model { get; set; } = "";
        public string Concept { get; set; } = "";
        public List<string> Parts { get; set; } = new List<string>();
    }
}
