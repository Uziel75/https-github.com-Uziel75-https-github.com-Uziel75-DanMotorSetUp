using System.Collections.Generic;

namespace DanMotor.Common
{
    public class MotorPartData
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Concept { get; set; }
        public List<string> Parts { get; set; }
    }
}


using System.Collections.Generic;

namespace DanMotor.Common
{
    public interface IDataStore
    {
        List<MotorPartData> GetAll();
        void SaveAll(List<MotorPartData> data);
    }
}
