using System;
using DanMotor.Business;

namespace DanMotor
{
    class Program
    {
        static void Main(string[] args)
        {
            MotorService service = new MotorService();

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
                    case "1": service.ViewBrands(); break;
                    case "2": service.AddPart(); break;
                    case "3": service.EditPart(); break;
                    case "4": service.DeletePart(); break;
                    case "5": service.SearchParts(); break;
                    case "0": return;
                    default: Console.WriteLine("Invalid option."); break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
}
    }
}
