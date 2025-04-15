using System;
using DanMotor.BL;
using System.Collections.Generic;

namespace DanMotor.UI
{
    class Program
    {
        static MotorService motorService = new MotorService();

        static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\nMOTOR BRAND MENU");
                Console.WriteLine("[1] Honda");
                Console.WriteLine("[2] Yamaha");
                Console.WriteLine("[3] Exit");
                Console.Write("Select a brand: ");

                if (!int.TryParse(Console.ReadLine(), out int brandChoice) || brandChoice < 1 || brandChoice > 3)
                {
                    Console.WriteLine("Invalid input. Try again.");
                    continue;
                }
                if (brandChoice == 3) break;

                string selectedBrand = brandChoice == 1 ? "Honda" : "Yamaha";
                HandleModelSelection(selectedBrand);
            }
        }

        static void HandleModelSelection(string brand)
        {
            var models = motorService.GetModels(brand);
            if (models.Count == 0)
            {
                Console.WriteLine("No models available.");
                return;
            }

            Console.WriteLine($"\nChoose a Model for {brand}:");
            for (int i = 0; i < models.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {models[i]}");
            }
            Console.WriteLine("[0] Back");
            Console.Write("Enter choice: ");

            if (!int.TryParse(Console.ReadLine(), out int modelChoice) || modelChoice < 0 || modelChoice > models.Count)
            {
                Console.WriteLine("Invalid input. Try again.");
                return;
            }
            if (modelChoice == 0) return;

            HandleConceptSelection(brand, models[modelChoice - 1]);
        }

        static void HandleConceptSelection(string brand, string model)
        {
            var concepts = motorService.GetConcepts(brand, model);
            if (concepts.Count == 0)
            {
                Console.WriteLine("No concepts available.");
                return;
            }

            Console.WriteLine($"\nChoose a Concept for {brand} - {model}:");
            for (int i = 0; i < concepts.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {concepts[i]}");
            }
            Console.WriteLine("[0] Back");
            Console.Write("Enter choice: ");

            if (!int.TryParse(Console.ReadLine(), out int conceptChoice) || conceptChoice < 0 || conceptChoice > concepts.Count)
            {
                Console.WriteLine("Invalid input. Try again.");
                return;
            }
            if (conceptChoice == 0) return;

            DisplayParts(brand, model, concepts[conceptChoice - 1]);
        }

        static void DisplayParts(string brand, string model, string concept)
        {
            var parts = motorService.GetParts(brand, model, concept);
            if (parts.Count == 0)
            {
                Console.WriteLine("No parts available. You can add new parts.");
            }
            else
            {
                Console.WriteLine($"\nParts for {brand} - {model} ({concept} Concept):");
                for (int i = 0; i < parts.Count; i++)
                {
                    Console.WriteLine($"[{i + 1}] {parts[i]}");
                }
            }
            AddEditDeletePart(brand, model, concept);
        }

        static void AddEditDeletePart(string brand, string model, string concept)
        {
            Console.WriteLine("\nOptions: ");
            Console.WriteLine("[1] Add Part");
            Console.WriteLine("[2] Edit Part");
            Console.WriteLine("[3] Delete Part");
            Console.WriteLine("[4] Search Part");
            Console.WriteLine("[0] Back");
            Console.Write("Choose an option: ");

            if (!int.TryParse(Console.ReadLine(), out int actionChoice) || actionChoice < 0 || actionChoice > 4)
            {
                Console.WriteLine("Invalid input. Try again.");
                return;
            }

            switch (actionChoice)
            {
                case 1:
                    Console.Write("Enter the name of the part to add: ");
                    string newPart = Console.ReadLine();
                    if (motorService.AddPart(brand, model, concept, newPart))
                        Console.WriteLine($"Part '{newPart}' added successfully!");
                    else
                        Console.WriteLine("Error: Unable to add part.");
                    break;
                case 2:
                    EditPart(brand, model, concept);
                    break;
                case 3:
                    DeletePart(brand, model, concept);
                    break;
                case 4:
                    Console.Write("Enter part name keyword to search: ");
                    string keyword = Console.ReadLine();
                    var results = motorService.SearchParts(brand, model, concept, keyword);
                    if (results.Count > 0)
                    {
                        Console.WriteLine("Search Results:");
                        foreach (var result in results)
                            Console.WriteLine("- " + result);
                    }
                    else
                    {
                        Console.WriteLine("No parts found matching keyword.");
                    }
                    break;
                case 0:
                    return;
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            DisplayParts(brand, model, concept);
        }

        static void EditPart(string brand, string model, string concept)
        {
            var parts = motorService.GetParts(brand, model, concept);
            if (parts.Count == 0)
            {
                Console.WriteLine("No parts to edit.");
                return;
            }

            Console.WriteLine("Select a part to edit by number:");
            for (int i = 0; i < parts.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {parts[i]}");
            }
            Console.Write("Enter part number: ");

            if (!int.TryParse(Console.ReadLine(), out int partChoice) || partChoice < 1 || partChoice > parts.Count)
            {
                Console.WriteLine("Invalid input. Try again.");
                return;
            }

            Console.Write("Enter the new name for the part: ");
            string newPartName = Console.ReadLine();

            if (motorService.EditPart(brand, model, concept, parts[partChoice - 1], newPartName))
                Console.WriteLine($"Part '{parts[partChoice - 1]}' successfully updated to '{newPartName}'!");
            else
                Console.WriteLine("Error: Unable to update part.");
        }

        static void DeletePart(string brand, string model, string concept)
        {
            var parts = motorService.GetParts(brand, model, concept);
            if (parts.Count == 0)
            {
                Console.WriteLine("No parts to delete.");
                return;
            }

            Console.WriteLine("Select a part to delete by number:");
            for (int i = 0; i < parts.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {parts[i]}");
            }
            Console.Write("Enter part number to delete: ");

            if (!int.TryParse(Console.ReadLine(), out int partChoice) || partChoice < 1 || partChoice > parts.Count)
            {
                Console.WriteLine("Invalid input. Try again.");
                return;
            }

            if (motorService.DeletePart(brand, model, concept, parts[partChoice - 1]))
                Console.WriteLine($"Part '{parts[partChoice - 1]}' has been deleted successfully!");
            else
                Console.WriteLine("Error: Unable to delete part.");
        }
    }
}
