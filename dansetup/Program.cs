using System;

namespace DanMotor
{
    class Program
    {
        static void Main(string[] args)
        {
            DanMotor_BusinessData motorSystem = new DanMotor_BusinessData();

            while (true)
            {
                Console.WriteLine("\n-------------------");
                Console.WriteLine("MOTOR SYSTEM MENU");
                Console.WriteLine("[1] Thailand Motor");
                Console.WriteLine("[2] Indonesia Motor");
                Console.WriteLine("[3] Malaysia Motor");
                Console.WriteLine("[4] Exit");
                Console.Write("[User Input]: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                Console.Clear();

                switch (choice)
                {
                    case 1:
                        HandleMotorSelection(motorSystem, "Thailand");
                        break;
                    case 2:
                        HandleMotorSelection(motorSystem, "Indonesia");
                        break;
                    case 3:
                        HandleMotorSelection(motorSystem, "Malaysia");
                        break;
                    case 4:
                        Console.WriteLine("Exiting... Thank you!");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void HandleMotorSelection(DanMotor_BusinessData motorSystem, string country)
        {
            Console.WriteLine($"Motor System ({country}):");
            Console.WriteLine("[1] First Option");
            Console.WriteLine("[2] Second Option");
            Console.WriteLine("[3] Third Option");
            Console.WriteLine("[4] Back");
            Console.Write("Enter your choice: ");

            if (!int.TryParse(Console.ReadLine(), out int action))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                return;
            }

            Console.Clear();

            if (action == 4) return;

            string result = country switch
            {
                "Thailand" => motorSystem.GetThailandMotor(action),
                "Indonesia" => motorSystem.GetIndonesiaMotor(action),
                "Malaysia" => motorSystem.GetMalaysiaMotor(action),
                _ => "Invalid selection"
            };

            Console.WriteLine(result);
        }
    }
}
