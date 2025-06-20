using System;
using DanMotor.Common;
using DanMotor.Data;

namespace DanMotor.Business
{
    public class MotorService
    {
        private IDataStore dataStore;

        public MotorService()
        {
            // Change here which data store you want to use:
            // dataStore = new InMemoryDataStore();
            // dataStore = new TextFileDataStore();
            dataStore = new JsonFileDataStore();
        }

        public void ViewBrands()
        {
            var brands = dataStore.GetBrands();
            Console.WriteLine("\nBrands:");
            foreach (var brand in brands)
                Console.WriteLine("- " + brand);
        }

        public void AddPart()
        {
            Console.Write("Enter brand: ");
            string brand = Console.ReadLine();
            Console.Write("Enter model: ");
            string model = Console.ReadLine();
            Console.Write("Enter concept: ");
            string concept = Console.ReadLine();
            Console.Write("Enter part: ");
            string part = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(brand) || string.IsNullOrWhiteSpace(model) ||
                string.IsNullOrWhiteSpace(concept) || string.IsNullOrWhiteSpace(part))
            {
                Console.WriteLine("All fields are required.");
                return;
            }

            if (dataStore.AddPart(brand.Trim(), model.Trim(), concept.Trim(), part.Trim()))
                Console.WriteLine("Part added successfully.");
            else
                Console.WriteLine("Failed to add part. Maybe it already exists.");
        }

        public void EditPart()
        {
            Console.Write("Enter brand: ");
            string brand = Console.ReadLine();
            Console.Write("Enter model: ");
            string model = Console.ReadLine();
            Console.Write("Enter concept: ");
            string concept = Console.ReadLine();
            Console.Write("Enter old part: ");
            string oldPart = Console.ReadLine();
            Console.Write("Enter new part: ");
            string newPart = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(brand) || string.IsNullOrWhiteSpace(model) ||
                string.IsNullOrWhiteSpace(concept) || string.IsNullOrWhiteSpace(oldPart) ||
                string.IsNullOrWhiteSpace(newPart))
            {
                Console.WriteLine("All fields are required.");
                return;
            }

            if (dataStore.EditPart(brand.Trim(), model.Trim(), concept.Trim(), oldPart.Trim(), newPart.Trim()))
                Console.WriteLine("Part updated successfully.");
            else
                Console.WriteLine("Failed to update part. Check if old part exists.");
        }

        public void DeletePart()
        {
            Console.Write("Enter brand: ");
            string brand = Console.ReadLine();
            Console.Write("Enter model: ");
            string model = Console.ReadLine();
            Console.Write("Enter concept: ");
            string concept = Console.ReadLine();
            Console.Write("Enter part to delete: ");
            string part = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(brand) || string.IsNullOrWhiteSpace(model) ||
                string.IsNullOrWhiteSpace(concept) || string.IsNullOrWhiteSpace(part))
            {
                Console.WriteLine("All fields are required.");
                return;
            }

            if (dataStore.DeletePart(brand.Trim(), model.Trim(), concept.Trim(), part.Trim()))
                Console.WriteLine("Part deleted successfully.");
            else
                Console.WriteLine("Failed to delete part. Check if part exists.");
        }

        public void SearchParts()
        {
            Console.Write("Enter brand: ");
            string brand = Console.ReadLine();
            Console.Write("Enter model: ");
            string model = Console.ReadLine();
            Console.Write("Enter concept: ");
            string concept = Console.ReadLine();
            Console.Write("Enter keyword to search: ");
            string keyword = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(brand) || string.IsNullOrWhiteSpace(model) ||
                string.IsNullOrWhiteSpace(concept) || string.IsNullOrWhiteSpace(keyword))
            {
                Console.WriteLine("All fields are required.");
                return;
            }

            var results = dataStore.SearchParts(brand.Trim(), model.Trim(), concept.Trim(), keyword.Trim());
            Console.WriteLine("\nSearch Results:");
            if (results.Count == 0)
                Console.WriteLine("No matching parts found.");
            else
                foreach (var part in results)
                    Console.WriteLine("- " + part);
        }
    }
}
