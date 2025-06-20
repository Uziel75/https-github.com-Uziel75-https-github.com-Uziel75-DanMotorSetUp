using System.Collections.Generic;
using System.IO;
using System.Linq;
using DanMotor.Common;

namespace DanMotor.Data
{
    public class TextFileDataStore : IDataStore
    {
        private const string filePath = "motors.txt";
        private List<MotorModel> data;

        public TextFileDataStore()
        {
            data = LoadData();
        }

        private List<MotorModel> LoadData()
        {
            var list = new List<MotorModel>();

            if (!File.Exists(filePath))
                return list;

            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                // Each line format: Brand|Model|Concept|Part1,Part2,Part3
                var parts = line.Split('|');
                if (parts.Length == 4)
                {
                    var partsList = parts[3].Split(',')
                        .Where(p => !string.IsNullOrWhiteSpace(p))
                        .Select(p => p.Trim())
                        .ToList();

                    list.Add(new MotorModel
                    {
                        Brand = parts[0].Trim(),
                        Model = parts[1].Trim(),
                        Concept = parts[2].Trim(),
                        Parts = partsList
                    });
                }
            }
            return list;
        }

        private void SaveData()
        {
            var lines = data.Select(d =>
                $"{d.Brand}|{d.Model}|{d.Concept}|{string.Join(",", d.Parts)}");
            File.WriteAllLines(filePath, lines);
        }

        public List<string> GetBrands()
        {
            return data.Select(d => d.Brand).Distinct().ToList();
        }

        public List<string> GetModels(string brand)
        {
            return data.Where(d => d.Brand == brand)
                       .Select(d => d.Model)
                       .Distinct()
                       .ToList();
        }

        public List<string> GetConcepts(string brand, string model)
        {
            return data.Where(d => d.Brand == brand && d.Model == model)
                       .Select(d => d.Concept)
                       .Distinct()
                       .ToList();
        }

        public List<string> GetParts(string brand, string model, string concept)
        {
            var found = data.FirstOrDefault(d =>
                d.Brand == brand && d.Model == model && d.Concept == concept);
            return found != null ? new List<string>(found.Parts) : new List<string>();
        }

        public bool AddPart(string brand, string model, string concept, string part)
        {
            var found = data.FirstOrDefault(d =>
                d.Brand == brand && d.Model == model && d.Concept == concept);

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
            return false; // part already exists
        }

        public bool EditPart(string brand, string model, string concept, string oldPart, string newPart)
        {
            var found = data.FirstOrDefault(d =>
                d.Brand == brand && d.Model == model && d.Concept == concept);

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
            var found = data.FirstOrDefault(d =>
                d.Brand == brand && d.Model == model && d.Concept == concept);

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
