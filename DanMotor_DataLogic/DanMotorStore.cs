// File: InMemoryDataStore.cs
using System.Collections.Generic;
using System.Linq;
using DanMotor.Common;

namespace DanMotor.DL
{
    public class InMemoryDataStore : IDataStore
    {
        private List<MotorPartData> motorParts;

        public InMemoryDataStore()
        {
            motorParts = new List<MotorPartData>
            {
                new MotorPartData { Brand = "Honda", Model = "Click", Concept = "Sport", Parts = new List<string> { "Engine", "Tire" } },
                new MotorPartData { Brand = "Honda", Model = "Wave", Concept = "Standard", Parts = new List<string> { "Chain", "Brake" } },
                new MotorPartData { Brand = "Yamaha", Model = "Nmax", Concept = "Touring", Parts = new List<string> { "Seat", "Mirror" } },
                new MotorPartData { Brand = "Yamaha", Model = "FZ", Concept = "Sport", Parts = new List<string> { "Exhaust", "Headlight" } }
            };
        }

        public List<MotorPartData> GetAll()
        {
            return motorParts;
        }

        public void SaveAll(List<MotorPartData> data)
        {
            motorParts = data;
        }
    }
}
