using System.Collections.Generic;
using System.Linq;
using DanMotor.Common;

namespace DanMotor.Data
{
    public class InMemoryDataStore : IDataStore
    {
        private List<MotorModel> data = new List<MotorModel>();

        public List<string> GetBrands() => data.Select(d => d.Brand).Distinct().ToList();

        public List<string> GetModels(string brand) =>
            data.Where(d => d.Brand == brand).Select(d => d.Model).Distinct().ToList();

        public List<string> GetConcepts(string brand, string model) =>
            data.Where(d => d.Brand == brand && d.Model == model).Select(d => d.Concept).Distinct().ToList();

        public List<string> GetParts(string brand, string model, string concept) =>
            data.FirstOrDefault(d => d.Brand == brand && d.Model == model && d.Concept == concept)?.Parts ?? new List<string>();

        public bool AddPart(string brand, string model, string concept, string part)
        {
            var found = data.FirstOrDefault(d => d.Brand == brand && d.Model == model && d.Concept == concept);
            if (found == null)
            {
                data.Add(new MotorModel
                {
                    Brand = brand,
                    Model = model,
                    Concept = concept,
                    Parts = new List<string> { part }
                });
                return true;
            }
            else
            {
                if (!found.Parts.Contains(part))
                {
                    found.Parts.Add(part);
                    return true;
                }
            }
            return false; // part already exists
        }

        public bool EditPart(string brand, string model, string concept, string oldPart, string newPart)
        {
            var found = data.FirstOrDefault(d => d.Brand == brand && d.Model == model && d.Concept == concept);
            if (found != null && found.Parts.Contains(oldPart))
            {
                found.Parts.Remove(oldPart);
                found.Parts.Add(newPart);
                return true;
            }
            return false;
        }

        public bool DeletePart(string brand, string model, string concept, string part)
        {
            var found = data.FirstOrDefault(d => d.Brand == brand && d.Model == model && d.Concept == concept);
            if (found != null && found.Parts.Contains(part))
            {
                found.Parts.Remove(part);
                return true;
            }
            return false;
        }

        public List<string> SearchParts(string brand, string model, string concept, string keyword)
        {
            var parts = GetParts(brand, model, concept);
            return parts.Where(p => p.Contains(keyword)).ToList();
        }
    }
}
