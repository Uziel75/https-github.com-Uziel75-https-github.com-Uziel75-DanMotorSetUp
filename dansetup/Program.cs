using DanMotor.Business;
using DanMotor.Common;
using DanMotor.Data;
using System;

namespace DanMotor
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataStore dataStore = new DbMotoDataStore();
            MotorService service = new MotorService(dataStore);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== DAN MOTOR PARTS MANAGEMENT ===");
                Console.WriteLine("1. View Brands");
                Console.WriteLine("2. Add Part");
                Console.WriteLine("3. Edit Part");
                Console.WriteLine("4. Delete Part");
                Console.WriteLine("5. Search Parts");
                Console.WriteLine("0. Exit");
                Console.Write("Select an option: ");

                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        var brands = service.GetBrands();
                        Console.WriteLine("Brands:");
                        foreach (var b in brands)
                            Console.WriteLine("- " + b);
                        break;

                    case "2":
                        Console.Write("Brand: ");
                        string addBrand = Console.ReadLine();
                        Console.Write("Model: ");
                        string addModel = Console.ReadLine();
                        Console.Write("Concept: ");
                        string addConcept = Console.ReadLine();
                        Console.Write("Part: ");
                        string newPart = Console.ReadLine();
                        var added = service.AddPart(addBrand, addModel, addConcept, newPart);
                        Console.WriteLine(added ? "Part added." : "Part already exists.");
                        break;

                    case "3":
                        Console.Write("Brand: ");
                        string editBrand = Console.ReadLine();
                        Console.Write("Model: ");
                        string editModel = Console.ReadLine();
                        Console.Write("Concept: ");
                        string editConcept = Console.ReadLine();
                        Console.Write("Old Part: ");
                        string oldPart = Console.ReadLine();
                        Console.Write("New Part: ");
                        string editedPart = Console.ReadLine();
                        var edited = service.EditPart(editBrand, editModel, editConcept, oldPart, editedPart);
                        Console.WriteLine(edited ? "Part edited." : "Part not found.");
                        break;

                    case "4":
                        Console.Write("Brand: ");
                        string delBrand = Console.ReadLine();
                        Console.Write("Model: ");
                        string delModel = Console.ReadLine();
                        Console.Write("Concept: ");
                        string delConcept = Console.ReadLine();
                        Console.Write("Part: ");
                        string delPart = Console.ReadLine();
                        var deleted = service.DeletePart(delBrand, delModel, delConcept, delPart);
                        Console.WriteLine(deleted ? "Part deleted." : "Part not found.");
                        break;

                    case "5":
                        Console.Write("Brand: ");
                        string searchBrand = Console.ReadLine();
                        Console.Write("Model: ");
                        string searchModel = Console.ReadLine();
                        Console.Write("Concept: ");
                        string searchConcept = Console.ReadLine();
                        Console.Write("Keyword: ");
                        string keyword = Console.ReadLine();
                        var results = service.SearchParts(searchBrand, searchModel, searchConcept, keyword);
                        Console.WriteLine("Search Results:");
                        foreach (var result in results)
                            Console.WriteLine("- " + result);
                        break;

                    case "0": return;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
