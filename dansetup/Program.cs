using System;

namespace DanMotor
{
    internal class Program
    {
        static void Main()
        {
            while (true)
            {
                DisplayMotorMenu();

                int userInput = GetUserInput();

                switch (userInput)
                {
                    case 1:
                        ThailandMotor();
                        break;
                    case 2:
                        IndonesiaMotor();
                        break;
                    case 3:
                        MalaysiaMotor();
                        break;
                    case 4:
                        Console.WriteLine("Thank you for using Motor system setup!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter between 1-4 only.");
                        break;
                }
            }
        }

        static void DisplayMotorMenu() 
        {
            Console.WriteLine("\n-------------------");
            Console.WriteLine("MOTOR SYSTEM MENU");
            Console.WriteLine("[1] Thailand Motor");
            Console.WriteLine("[2] Indonesia Motor");
            Console.WriteLine("[3] Malaysia Motor");
            Console.WriteLine("[4] Exit");
            Console.Write("[User Input]: ");
        }

        static int GetUserInput() 
        {
            if (int.TryParse(Console.ReadLine(), out int userInput))
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                return GetUserInput(); 
            }
        }

        
        static void ThailandMotor()
        {
            bool thiaMotor = false;

            while (true)
            {
                Console.WriteLine("Motor System:");
                Console.WriteLine("[1]  Rimset 17's");
                Console.WriteLine("[2]  Lowered,open canister");
                Console.WriteLine("[3]  Ligthen Swing Arm/faring");
                Console.WriteLine("[4]  Back");
                Console.Write("Enter your choice: ");

                if (int.TryParse(Console.ReadLine(), out int action))
                {
                    Console.Clear();

                    switch (action)
                    {
                        case 1:
                            thiaMotor = true;
                            Console.WriteLine("Rimset 17's");
                            break;
                        case 2:
                            thiaMotor = false;
                            Console.WriteLine("Lowered,open canister");
                            break;
                        case 3:
                            Console.WriteLine(thiaMotor ? "Ligthen Swing Arm/faring" : "this is thia setup");
                            break;
                        case 4:
                            return;
                        default:
                            Console.WriteLine(" Invalid thiasetup.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid number.");
                }
            }
        }

    
        static void IndonesiaMotor()
        {
            bool indoMotor = false;

            while (true)
            {
                Console.WriteLine("Motor System:");
                Console.WriteLine("[1]  Mags 14's");
                Console.WriteLine("[2]  Lowered");
                Console.WriteLine("[3]  alloy crank");
                Console.WriteLine("[4]  Back");
                Console.Write("Enter your choice: ");

                if (int.TryParse(Console.ReadLine(), out int action))
                {
                    Console.Clear();

                    switch (action)
                    {
                        case 1:
                            indoMotor = true;
                            Console.WriteLine("Rimset 17's");
                            break;
                        case 2:
                            indoMotor = false;
                            Console.WriteLine("Lowered");
                            break;
                        case 3:
                            Console.WriteLine(indoMotor ? "alloy crank" : "this is t setup");
                            break;
                        case 4:
                            return;
                        default:
                            Console.WriteLine(" Invalid indoMotor.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid number.");
                }
            }
        }

        static void MalaysiaMotor()
        {
            bool malayMotor = false;


            while (true)
            {
                Console.WriteLine("Motor System:");
                Console.WriteLine("[1]  CNC Mags 14's");
                Console.WriteLine("[2]  Nickel GP4 Caliper");
                Console.WriteLine("[3]  CNC crank");
                Console.WriteLine("[4]  Back");
                Console.Write("Enter your choice: ");

                if (int.TryParse(Console.ReadLine(), out int action))
                {
                    Console.Clear();

                    switch (action)
                    {
                        case 1:
                            malayMotor = true;
                            Console.WriteLine("CNC Mags 14's's");
                            break;
                        case 2:
                            malayMotor = false;
                            Console.WriteLine("Nickel GP4 Caliper");
                            break;
                        case 3:
                            Console.WriteLine(malayMotor ? "CNC crank" : "No CNC crank");
                            break;
                        case 4:
                            return;
                        default:
                            Console.WriteLine(" Invalid malayMotor.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid number.");
                }
            }
        }
    }
}