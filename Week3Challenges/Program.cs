using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Challenges
{
    class Program
    {
        static void Main(string[] args)
        {
            TopMenu:
                Console.Clear();
                Console.WriteLine("What would you like to do?\n" +
                    "1. Create a new character\n" +
                    "2. Edit an existing character\n" +
                    "3. Delete an existing character\n" +
                    "4. Exit\n");

                EntityCreationScreen create = new EntityCreationScreen();
               // CharacterEditScreen edit = new CharacterEditScreen();
              //  CharacterDeleteScreen delete = new CharacterDeleteScreen();

                string input = Console.ReadLine();
                bool parsed = int.TryParse(input, out int whatToDo);
            
                if (parsed)
                {
                    switch (whatToDo)
                    {
                        case 1:
                            create.Run();
                            break;
                        case 2:
                           // edit.Run();
                            break;
                        case 3:
                           // delete.Run();
                            break;
                        default:
                            Console.WriteLine("Invalid input. Press enter to continue.");
                            if (Console.ReadKey().Key == ConsoleKey.Enter)
                            {
                            goto TopMenu;
                            }
                            else
                            {
                            Console.Clear();
                            goto default;
                            }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Press enter to continue.");
                    while (Console.ReadKey().Key != ConsoleKey.Enter)
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid input. Press enter to continue.");
                        Console.ReadKey();
                    }
                    goto TopMenu;
                }
        }
    }
}
