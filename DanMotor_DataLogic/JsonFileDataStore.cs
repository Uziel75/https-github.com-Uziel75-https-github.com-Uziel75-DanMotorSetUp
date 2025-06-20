using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using DanMotor.Common;

namespace DanMotor.Data
{
    public class JsonFileDataStore : IDataStore
    {
        private const string filePath = "motors.json";
        private List<MotorModel> data;

        public JsonFileDataStore()
        {
            data = LoadData();
        }

        private List<MotorModel> LoadData()
        {
            if (!File.Exists(filePath))
                return new List<MotorModel>();

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<MotorModel>>(json) ?? new List<MotorModel>();
        }

        private void SaveData()
        {
            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

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
                SaveData();
                return true;
            }
            else
            {
                if (!found.Parts.Contains(part))
                {
                    found.Parts.Add(part);
                    SaveData();
                    return true;
                }
            }
            return false;
        }

        public bool EditPart(string brand, string model, string concept, string oldPart, string newPart)
        {
            var found = data.FirstOrDefault(d => d.Brand == brand && d.Model == model && d.Concept == concept);
            if (found != null && found.Parts.Contains(oldPart))
            {
                found.Parts.Remove(oldPart);
                found.Parts.Add(newPart);
                SaveData();
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
                SaveData();
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
