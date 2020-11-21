using Week3Challenges_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Challenges_Console
{
    class CharacterCreationScreen
    {
        public void Run()
        {
        MainMenu:
            Console.Clear();
            Console.WriteLine("What kind of character are you creating?\n" +
                "1. Player Character\n" +
                "2. Monster\n" +
                "3. Non-Player Character\n");
            string input = Console.ReadLine();
            bool parsed = int.TryParse(input, out int whichClass);
            if (parsed)
            {
                switch (whichClass)
                {
                    case 1:
                        // Code for Character creation
                        Console.WriteLine("Test 1");
                        Console.ReadLine();
                        break;
                    case 2:
                        // Code for Monster creation
                        Console.WriteLine("Test 2");
                        Console.ReadLine();
                        break;
                    case 3:
                        // Code for NPC creation
                        Console.WriteLine("Test 3");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Invalid input. Press enter to continue.");
                        if (Console.ReadKey().Key == ConsoleKey.Enter)
                        {
                            goto MainMenu;
                        }
                        else
                        {
                            Console.Clear();
                            goto default;
                        }
                }
            }
            else{
                Console.WriteLine("Invalid input. Press enter to continue.");
                while (Console.ReadKey().Key != ConsoleKey.Enter)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input. Press enter to continue.");
                    Console.ReadKey();
                }
                goto MainMenu;
            }
            
        }

        private void CreateEntity()
        {
            Console.Clear();

            Entity newCharacter = new Entity();
            CharacterCRUD characterInfo = new CharacterCRUD();
            List<string> characterClasses = characterInfo.FindRace_Character();
        }
    }
}
