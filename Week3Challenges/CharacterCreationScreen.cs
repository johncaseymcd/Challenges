using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Challenges
{
    class CharacterCreationScreen
    {
        Entity newCharacter = new Entity();
        CharacterCRUD characterInfo = new CharacterCRUD();

        public void Run()
        {
        MainMenu:
            Console.Clear();
            Console.WriteLine("What kind of character are you creating?\n" +
                "1. Player Character\n" +
                "2. Monster\n" +
                "3. Non-Player Character\n");
            string input = Console.ReadLine();
            bool parsed = int.TryParse(input, out int whichCharacter);
            if (parsed)
            {
                switch (whichCharacter)
                {
                    case 1:
                        // Code for Character creation
                        ChooseRace_Character();
                        ChooseClass_Character();
                        ChooseAlignment_NonMonster();
                        EnterDetails();
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

        private void ChooseRace_Character()
        {
            List<string> characterRaces = characterInfo.FindRace_Character();

        RaceSelect:
            Console.Clear();

            Console.WriteLine("Choose a character race:\n");
            foreach (string raceName in characterRaces)
            {
                for (int x = 0; x <= characterRaces.Count; x++)
                {
                    Console.WriteLine($"{x + 1}. {raceName.Remove(0, 2)}\n");
                }
            }

            string input = Console.ReadLine();
            bool parsed = int.TryParse(input, out int whichRace);

            if (parsed)
            {
                switch (whichRace)
                {
                    case 1:
                        newCharacter.Race = EntityRace.C_Dwarf;
                        break;
                    case 2:
                        newCharacter.Race = EntityRace.C_Elf;
                        break;
                    case 3:
                        newCharacter.Race = EntityRace.C_Gnome;
                        break;
                    case 4:
                        newCharacter.Race = EntityRace.C_Halfling;
                        break;
                    case 5:
                        newCharacter.Race = EntityRace.C_Human;
                        break;
                    case 6:
                        newCharacter.Race = EntityRace.B_Orc;
                        break;
                    case 7:
                        newCharacter.Race = EntityRace.C_Tiefling;
                        break;
                    default:
                        Console.WriteLine("Invalid input. Press enter to continue.");
                        if (Console.ReadKey().Key == ConsoleKey.Enter)
                        {
                            goto RaceSelect;
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
                goto RaceSelect;
            }
        }

        private void ChooseClass_Character() {
            List<string> characterClasses = characterInfo.FindClass_Character();

        ClassSelect:
            Console.Clear();

            Console.WriteLine("Choose a character class:\n");
            foreach(string className in characterClasses)
            {
                for(int x = 0; x <= characterClasses.Count; x++)
                {
                    Console.WriteLine($"{x + 1}. {className.Remove(0, 2)}\n");
                }
            }

            string input = Console.ReadLine();
            bool parsed = int.TryParse(input, out int whichClass);
            if (parsed)
            {
                switch (whichClass)
                {
                    case 1:
                        newCharacter.EntityClass = EntityClass.B_Barbarian;
                        break;
                    case 2:
                        newCharacter.EntityClass = EntityClass.C_Bard;
                        break;
                    case 3:
                        newCharacter.EntityClass = EntityClass.C_Cleric;
                        break;
                    case 4:
                        newCharacter.EntityClass = EntityClass.C_Druid;
                        break;
                    case 5:
                        newCharacter.EntityClass = EntityClass.B_Fighter;
                        break;
                    case 6:
                        newCharacter.EntityClass = EntityClass.C_Monk;
                        break;
                    case 7:
                        newCharacter.EntityClass = EntityClass.C_Paladin;
                        break;
                    case 8:
                        newCharacter.EntityClass = EntityClass.B_Ranger;
                        break;
                    case 9:
                        newCharacter.EntityClass = EntityClass.B_Rogue;
                        break;
                    case 10:
                        newCharacter.EntityClass = EntityClass.B_Wizard;
                        break;
                    default:
                        Console.WriteLine("Invalid input. Press enter to continue.");
                        if(Console.ReadKey().Key == ConsoleKey.Enter)
                        {
                            goto ClassSelect;
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
                goto ClassSelect;
            }
        }

        private void ChooseAlignment_NonMonster()
        {
        AlignmentSelect:
            Console.Clear();
            Console.WriteLine("Choose the character's alignment:\n");

            for (int x = 0; x <= Enum.GetValues(typeof(EntityAlignment)).Length; x++)
            {
                foreach(string alignmentName in Enum.GetValues(typeof(EntityAlignment)))
                {
                    Console.WriteLine($"{x + 1}. {alignmentName.Remove(0,2)}\n");
                }
            }
            

            string input = Console.ReadLine();
            bool parsed = int.TryParse(input, out int whichAlignment);

            if (parsed)
            {
                switch (whichAlignment)
                {
                    case 1:
                        newCharacter.Alignment = EntityAlignment.C_Lawful_Good;
                        break;
                    case 2:
                        newCharacter.Alignment = EntityAlignment.C_Neutral_Good;
                        break;
                    case 3:
                        newCharacter.Alignment = EntityAlignment.C_Chaotic_Good;
                        break;
                    case 4:
                        newCharacter.Alignment = EntityAlignment.C_Lawful_Neutral;
                        break;
                    case 5:
                        newCharacter.Alignment = EntityAlignment.B_True_Neutral;
                        break;
                    case 6:
                        newCharacter.Alignment = EntityAlignment.B_Chaotic_Neutral;
                        break;
                    case 7:
                        newCharacter.Alignment = EntityAlignment.B_Lawful_Evil;
                        break;
                    case 8:
                        newCharacter.Alignment = EntityAlignment.B_Neutral_Evil;
                        break;
                    case 9:
                        newCharacter.Alignment = EntityAlignment.B_Chaotic_Evil;
                        break;
                    default:
                        Console.WriteLine("Invalid input. Press enter to continue.");
                        if (Console.ReadKey().Key == ConsoleKey.Enter)
                        {
                            goto AlignmentSelect;
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
                goto AlignmentSelect;
            }
        }

        private void EnterDetails()
        {
            // Name
            Console.WriteLine("What is your character's name?\n");
            newCharacter.Name = Console.ReadLine();

        // Height
        SetHeight:
            Console.Clear();
            Console.WriteLine($"How tall is {newCharacter.Name} (in inches)?\n");

            string height = Console.ReadLine();
            bool parseHeight = int.TryParse(height, out int howTall);
            if (parseHeight && howTall >= 24 && howTall <= 100)
            {
                newCharacter.Height = howTall;
            }
            else
            {
                Console.WriteLine("Invalid input. Characters should be between 24 and 100 inches tall. Press enter to continue.");
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    goto SetHeight;
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
                    goto SetHeight;
                }
            }

        // Weight
        SetWeight:
            Console.Clear();
            Console.WriteLine($"How much does {newCharacter.Name} weigh (in pounds)?\n");

            string weight = Console.ReadLine();
            bool parseWeight = int.TryParse(weight, out int howHeavy);
            if(parseWeight && howHeavy >= 25 && howHeavy <= 400)
            {
                newCharacter.Weight = howHeavy;
            }
            else
            {
                Console.WriteLine("Invalid input. Characters should weigh between 25 and 400 pounds.");
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    goto SetWeight;
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
                    goto SetWeight;
                }
            }

            // Strength
        SetStrength:
            Console.Clear();
            Random rnd = new Random();
            Console.WriteLine($"What is {newCharacter.Name}'s base Strength?\n" +
                "Enter a number from 10-20 or press R to randomize.");
            string strength = Console.ReadLine().ToLower();
            if (strength.StartsWith("1") || strength.StartsWith("2") && strength.Length == 2)
            {
                bool parseStrength = int.TryParse(strength, out int howStrong);
                if (parseStrength)
                {
                    newCharacter.Strength = howStrong;
                }
                else if (strength.StartsWith("r")){
                    newCharacter.Strength = rnd.Next(10, 20);
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
                    goto SetStrength;
                }
            }

            // Dexterity



            // Constitution



            // Intelligence



            // Wisdom



            // Perception



            // Armor



            // Health

        }
    }
}
