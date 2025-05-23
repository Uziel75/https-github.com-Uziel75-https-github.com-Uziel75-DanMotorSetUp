
using System.Collections.Generic;
using System.Linq;
using DanMotor.Common;

namespace DanMotor.BL
{
    public class MotorService
    {
        private readonly IDataStore dataStore;

        public MotorService(IDataStore dataStore)
        {
            this.dataStore = dataStore;
        }

        public List<string> GetBrands() => new List<string> { "Honda", "Yamaha" };

        public List<string> GetModels(string brand) =>
            dataStore.GetAll()
                     .Where(d => d.Brand == brand)
                     .Select(d => d.Model)
                     .Distinct()
                     .ToList();

        public List<string> GetConcepts(string brand, string model) =>
            dataStore.GetAll()
                     .Where(d => d.Brand == brand && d.Model == model)
                     .Select(d => d.Concept)
                     .Distinct()
                     .ToList();

        public List<string> GetParts(string brand, string model, string concept)
        {
            var data = dataStore.GetAll()
                .FirstOrDefault(d => d.Brand == brand && d.Model == model && d.Concept == concept);
            return data?.Parts ?? new List<string>();
        }

        public bool AddPart(string brand, string model, string concept, string part)
        {
            if (string.IsNullOrWhiteSpace(part)) return false;
            var allData = dataStore.GetAll();
            var entry = allData.FirstOrDefault(d => d.Brand == brand && d.Model == model && d.Concept == concept);

            if (entry == null)
            {
                entry = new MotorPartData
                {
                    Brand = brand,
                    Model = model,
                    Concept = concept,
                    Parts = new List<string>()
                };
                allData.Add(entry);
            }

            if (!entry.Parts.Contains(part))
            {
                entry.Parts.Add(part);
                dataStore.SaveAll(allData);
                return true;
            }

            return false;
        }

        public bool EditPart(string brand, string model, string concept, string oldPart, string newPart)
        {
            if (string.IsNullOrWhiteSpace(newPart)) return false;
            var allData = dataStore.GetAll();
            var entry = allData.FirstOrDefault(d => d.Brand == brand && d.Model == model && d.Concept == concept);
            if (entry == null) return false;

            int idx = entry.Parts.IndexOf(oldPart);
            if (idx >= 0 && !entry.Parts.Contains(newPart))
            {
                entry.Parts[idx] = newPart;
                dataStore.SaveAll(allData);
                return true;
            }

            return false;
        }

        public bool DeletePart(string brand, string model, string concept, string part)
        {
            var allData = dataStore.GetAll();
            var entry = allData.FirstOrDefault(d => d.Brand == brand && d.Model == model && d.Concept == concept);
            if (entry == null) return false;

            if (entry.Parts.Remove(part))
            {
                dataStore.SaveAll(allData);
                return true;
            }

            return false;
        }

        public List<string> SearchParts(string brand, string model, string concept, string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword)) return new List<string>();

            var parts = GetParts(brand, model, concept);
            return parts.Where(p => p.ToLower().Contains(keyword.ToLower())).ToList();
        }
    }
}
