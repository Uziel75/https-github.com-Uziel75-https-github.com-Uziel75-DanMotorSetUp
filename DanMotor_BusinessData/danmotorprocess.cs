using DanMotor.Common;
using DanMotor.Data;
using System.Collections.Generic;

namespace DanMotor.Business
{
    public class MotorService
    {
        private readonly IDataStore dataStore;

        public MotorService(IDataStore store)
        {
            dataStore = store;
        }

        public List<string> GetBrands()
        {
            return dataStore.GetBrands();
        }

        public List<string> GetModels(string brand)
        {
            return dataStore.GetModels(brand);
        }

        public List<string> GetConcepts(string brand, string model)
        {
            return dataStore.GetConcepts(brand, model);
        }

        public List<string> GetParts(string brand, string model, string concept)
        {
            return dataStore.GetParts(brand, model, concept);
        }

        public bool AddPart(string brand, string model, string concept, string part)
        {
            return dataStore.AddPart(brand, model, concept, part);
        }

        public bool EditPart(string brand, string model, string concept, string oldPart, string newPart)
        {
            return dataStore.EditPart(brand, model, concept, oldPart, newPart);
        }

        public bool DeletePart(string brand, string model, string concept, string part)
        {
            return dataStore.DeletePart(brand, model, concept, part);
        }

        public List<string> SearchParts(string brand, string model, string concept, string keyword)
        {
            return dataStore.SearchParts(brand, model, concept, keyword);
        }

        public List<string> ViewBrands()
        {
            return dataStore.GetBrands();
        }
    }
}
