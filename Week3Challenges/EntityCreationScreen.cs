using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Challenges
{
    class EntityCreationScreen
    {
        // New Player Character variables
        Entity newCharacter = new Entity();
        CharacterCRUD characterInfo = new CharacterCRUD();
        List<Entity> _characterList = new List<Entity>();

        // New Monster variables
        Entity newMonster = new Entity();
        MonsterCRUD monsterInfo = new MonsterCRUD();
        List<Entity> _monsterList = new List<Entity>();

        // New NPC variables
        Entity newNPC = new Entity();
        NonPlayerCRUD npcInfo = new NonPlayerCRUD();
        List<Entity> _npcList = new List<Entity>();

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
                        ChooseAlignment_Character();
                        Console.Clear();
                        string displayDetails = EnterDetails_Character();
                        Console.WriteLine(displayDetails);
                        Console.WriteLine("Would you like to edit your character (y/n)?");
                        string toChange = Console.ReadLine().ToLower();
                        if (toChange == "y")
                        {
                            Console.Clear();
                            EnterDetails_Character();
                        }
                        else
                        {
                            _characterList.Add(newCharacter);
                            Console.WriteLine("Character successfully created!");
                            Console.ReadLine();
                        }
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
            else
            {
                PressEnterScript();
                goto MainMenu;
            }

        }

        private void PressEnterScript()
        {
            Console.WriteLine("Invalid input. Press enter to continue.");
            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
                Console.Clear();
                Console.WriteLine("Invalid input. Press enter to continue.");
                Console.ReadKey();
            }
        }

        private void ChooseRace_Character()
        {
            List<string> characterRaces = characterInfo.FindRace_Character();

        RaceSelect:
            Console.Clear();

            Console.WriteLine("Choose a character race:\n");
            int raceCount = 0;
            foreach (string raceName in characterRaces)
            {
                raceCount++;
                Console.WriteLine($"{raceCount}. {raceName.Remove(0, 2)}");
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
                PressEnterScript();
                goto RaceSelect;
            }
        }

        private void ChooseClass_Character()
        {
            List<string> characterClasses = characterInfo.FindClass_Character();

        ClassSelect:
            Console.Clear();

            Console.WriteLine("Choose a character class:\n");
            int classCount = 0;
            foreach (string className in characterClasses)
            {
                classCount++;
                Console.WriteLine($"{classCount}. {className.Remove(0, 2)}");
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
                        if (Console.ReadKey().Key == ConsoleKey.Enter)
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
                PressEnterScript();
                goto ClassSelect;
            }
        }

        private void ChooseAlignment_Character()
        {
            List<string> characterAlignments = characterInfo.FindAlignment_Character();

        AlignmentSelect:
            Console.Clear();
            Console.WriteLine("Choose the character's alignment:\n");

            int alignmentCount = 0;

            foreach (string alignmentName in characterAlignments)
            {
                alignmentCount++;
                string alignment = alignmentName.Replace('_', ' ');
                Console.WriteLine($"{alignmentCount}. {alignment.Remove(0, 2)}");
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
                PressEnterScript();
                goto AlignmentSelect;
            }
        }

        private string EnterDetails_Character()
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
                    PressEnterScript();
                    goto SetHeight;
                }
            }

        // Weight
        SetWeight:
            Console.Clear();
            Console.WriteLine($"How much does {newCharacter.Name} weigh (in pounds)?\n");

            string weight = Console.ReadLine();
            bool parseWeight = int.TryParse(weight, out int howHeavy);
            if (parseWeight && howHeavy >= 25 && howHeavy <= 400)
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
                    PressEnterScript();
                    goto SetWeight;
                }
            }

        // Strength
        SetStrength:
            Console.Clear();
            Random rndStr = new Random();
            Console.WriteLine($"What is {newCharacter.Name}'s base Strength?\n" +
                "Enter a number from 10 - 20 or press R to roll a d20.");
            string strength = Console.ReadLine().ToLower();
            bool parseStr = int.TryParse(strength, out int howStrong);
            if (parseStr && (strength.StartsWith("1") || strength.StartsWith("20")) && strength.Length == 2)
            {
                newCharacter.Strength = howStrong;
            }
            else if (strength == "r")
            {
                newCharacter.Strength = rndStr.Next(10, 20);
            }
            else
            {
                PressEnterScript();
                goto SetStrength;
            }

        // Dexterity
        SetDex:
            Console.Clear();
            Random rndDex = new Random();
            Console.WriteLine($"What is {newCharacter.Name}'s base Dexterity?\n" +
                "Enter a number from 10 - 20 or press R to roll a d20.");
            string dexterity = Console.ReadLine().ToLower();
            bool parseDex = int.TryParse(dexterity, out int howDexterous);
            if (parseDex && (dexterity.StartsWith("1") || dexterity.StartsWith("20")) && dexterity.Length == 2)
            {
                newCharacter.Dexterity = howDexterous;
            }
            else if (dexterity == "r")
            {
                newCharacter.Dexterity = rndDex.Next(10, 20);
            }
            else
            {
                PressEnterScript();
                goto SetDex;
            }

        // Constitution
        SetCon:
            Console.Clear();
            Random rndCon = new Random();
            Console.WriteLine($"What is {newCharacter.Name}'s base Constitution?\n" +
                "Enter a number from 10 - 20 or press R to roll a d20.");
            string constitution = Console.ReadLine().ToLower();
            bool parseCon = int.TryParse(constitution, out int howConstituted);
            if (parseCon && (constitution.StartsWith("1") || constitution.StartsWith("20")) && constitution.Length == 2)
            {
                newCharacter.Constitution = howConstituted;
            }
            else if (constitution == "r")
            {
                newCharacter.Constitution = rndCon.Next(10, 20);
            }
            else
            {
                PressEnterScript();
                goto SetCon;
            }

        // Intelligence
        SetInt:
            Console.Clear();
            Random rndInt = new Random();
            Console.WriteLine($"What is {newCharacter.Name}'s base Intelligence?\n" +
                "Enter a number from 10 - 20 or press R to roll a d20.");
            string intelligence = Console.ReadLine().ToLower();
            bool parseInt = int.TryParse(intelligence, out int howIntelligent);
            if (parseInt && (intelligence.StartsWith("1") || intelligence.StartsWith("20")) && intelligence.Length == 2)
            {
                newCharacter.Intelligence = howIntelligent;
            }
            else if (intelligence == "r")
            {
                newCharacter.Intelligence = rndInt.Next(10, 20);
            }
            else
            {
                PressEnterScript();
                goto SetInt;
            }

        // Wisdom
        SetWis:
            Console.Clear();
            Random rndWis = new Random();
            Console.WriteLine($"What is {newCharacter.Name}'s base Wisdom?\n" +
                "Enter a number from 10 - 20 or press R to roll a d20.");
            string wisdom = Console.ReadLine().ToLower();
            bool parseWis = int.TryParse(wisdom, out int howWise);
            if (parseWis && (wisdom.StartsWith("1") || wisdom.StartsWith("20")) && wisdom.Length == 2)
            {
                newCharacter.Wisdom = howWise;
            }
            else if (wisdom == "r")
            {
                newCharacter.Wisdom = rndWis.Next(10, 20);
            }
            else
            {
                PressEnterScript();
                goto SetWis;
            }

        // Perception
        SetPer:
            Console.Clear();
            Random rndPer = new Random();
            Console.WriteLine($"What is {newCharacter.Name}'s base Perception?\n" +
                "Enter a number from 10 - 20 or press R to roll a d20.");
            string perception = Console.ReadLine().ToLower();
            bool parsePer = int.TryParse(perception, out int howPerceptive);
            if (parsePer && (perception.StartsWith("1") || perception.StartsWith("20")) && perception.Length == 2)
            {
                newCharacter.Perception = howPerceptive;
            }
            else if (perception == "r")
            {
                newCharacter.Perception = rndPer.Next(10, 20);
            }
            else
            {
                PressEnterScript();
                goto SetPer;
            }

        // Armor
        SetArm:
            Console.Clear();
            Random rndArm = new Random();
            Console.WriteLine($"What is {newCharacter.Name}'s base Armor?\n" +
                "Enter a number from 10 - 20 or press R to roll a d20.");
            string armor = Console.ReadLine().ToLower();
            bool parseArm = int.TryParse(armor, out int howArmored);
            if (parseArm && (armor.StartsWith("1") || armor.StartsWith("20")) && armor.Length == 2)
            {
                newCharacter.Armor = howArmored;
            }
            else if (armor == "r")
            {
                newCharacter.Armor = rndArm.Next(10, 20);
            }
            else
            {
                PressEnterScript();
                goto SetArm;
            }

        // Health
        SetHealth:
            Console.Clear();
            Random rndHealth = new Random();
            Console.WriteLine($"What is {newCharacter.Name}'s base Health?\n" +
                "Enter a number from 10 - 32 or press R to roll 4d8.");
            string health = Console.ReadLine().ToLower();
            bool parseHealth = int.TryParse(health, out int howHealthy);
            if (parseHealth && (health.StartsWith("1") || health.StartsWith("2") || (health.StartsWith("3") && howHealthy < 33)) && health.Length == 2)
            {
                newCharacter.Health = howHealthy;
            }
            else if (health == "r")
            {
                newCharacter.Health = rndHealth.Next(10, 20);
            }
            else
            {
                PressEnterScript();
                goto SetHealth;
            }

            Console.Clear();
            string characterDetails = $"Your character's name is {newCharacter.Name}.\n" +
                $"{newCharacter.Name} is {newCharacter.Height} inches tall and weighs {newCharacter.Weight} pounds.\n" +
                $"{newCharacter.Name}'s stats are as follows:\n" +
                $"Strength: {newCharacter.Strength}\n" +
                $"Dexterity: {newCharacter.Dexterity}\n" +
                $"Constitution: {newCharacter.Constitution}\n" +
                $"Intelligence: {newCharacter.Intelligence}\n" +
                $"Wisdom: {newCharacter.Wisdom}\n" +
                $"Perception: {newCharacter.Perception}\n" +
                $"Armor: {newCharacter.Armor}\n" +
                $"Health: {newCharacter.Health}";
            return characterDetails;
        }

        private void ChooseRace_Monster()
        {
            List<string> monsterRaces = monsterInfo.FindRace_Monster();

        RaceSelect:
            Console.Clear();

            Console.WriteLine("Choose the monster's race:\n");
            int raceCount = 0;
            foreach (string raceName in monsterRaces)
            {
                raceCount++;
                Console.WriteLine($"{raceCount}. {raceName.Remove(0, 2)}");
            }

            string input = Console.ReadLine();
            bool parsed = int.TryParse(input, out int whichRace);

            if (parsed)
            {
                switch (whichRace)
                {
                    case 1:
                        newMonster.Race = EntityRace.M_Bugbear;
                        break;
                    case 2:
                        newMonster.Race = EntityRace.M_Centaur;
                        break;
                    case 3:
                        newMonster.Race = EntityRace.M_Goblin;
                        break;
                    case 4:
                        newMonster.Race = EntityRace.M_Hobgoblin;
                        break;
                    case 5:
                        newMonster.Race = EntityRace.M_Kenku;
                        break;
                    case 6:
                        newMonster.Race = EntityRace.M_Kobold;
                        break;
                    case 7:
                        newMonster.Race = EntityRace.M_Lizardfolk;
                        break;
                    case 8:
                        newMonster.Race = EntityRace.M_Minotaur;
                        break;
                    case 9:
                        newMonster.Race = EntityRace.B_Orc;
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
                PressEnterScript();
                goto RaceSelect;
            }
        }

        private void ChooseClass_Monster()
        {
            List<string> monsterClasses = monsterInfo.FindClass_Monster();

        ClassSelect:
            Console.Clear();

            Console.WriteLine("Choose the monster's class:\n");
            int classCount = 0;
            foreach (string className in monsterClasses)
            {
                classCount++;
                Console.WriteLine($"{classCount}. {className.Remove(0, 2)}");
            }

            string input = Console.ReadLine();
            bool parsed = int.TryParse(input, out int whichClass);

            if (parsed)
            {
                switch (whichClass)
                {
                    case 1:
                        newMonster.EntityClass = EntityClass.B_Barbarian;
                        break;
                    case 2:
                        newMonster.EntityClass = EntityClass.B_Fighter;
                        break;
                    case 3:
                        newMonster.EntityClass = EntityClass.B_Ranger;
                        break;
                    case 4:
                        newMonster.EntityClass = EntityClass.B_Rogue;
                        break;
                    case 5:
                        newMonster.EntityClass = EntityClass.B_Wizard;
                        break;
                    default:
                        Console.WriteLine("Invalid input. Press enter to continue.");
                        if (Console.ReadKey().Key == ConsoleKey.Enter)
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
                PressEnterScript();
                goto ClassSelect;
            }
        }

        private void ChooseAlignment_Monster()
        {
            List<string> monsterAlignments = monsterInfo.FindAlignment_Monster();

        AlignmentSelect:
            Console.Clear();

            Console.WriteLine("Choose the monster's alignment:\n");
            int alignmentCount = 0;
            foreach(string alignmentName in monsterAlignments)
            {
                alignmentCount++;
                string alignment = alignmentName.Replace('_', ' ');
                Console.WriteLine($"{alignmentCount}. {alignment.Remove(0, 2)}");
            }

            string input = Console.ReadLine();
            bool parsed = int.TryParse(input, out int whichAlignment);

            if (parsed)
            {
                switch (whichAlignment)
                {
                    case 1:
                        newMonster.Alignment = EntityAlignment.B_True_Neutral;
                        break;
                    case 2:
                        newMonster.Alignment = EntityAlignment.B_Chaotic_Neutral;
                        break;
                    case 3:
                        newMonster.Alignment = EntityAlignment.B_Lawful_Evil;
                        break;
                    case 4:
                        newMonster.Alignment = EntityAlignment.B_Neutral_Evil;
                        break;
                    case 5:
                        newMonster.Alignment = EntityAlignment.B_Chaotic_Evil;
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
                PressEnterScript();
                goto AlignmentSelect;
            }
        }

        private string EnterDetails_Monster()
        {
            // Name
            Console.WriteLine("What is the monster's name?");
            newMonster.Name = Console.ReadLine();

        // Height
        SetHeight:
            Console.Clear();
            Console.WriteLine($"How tall is {newMonster.Name} (in inches)?\n");
            string height = Console.ReadLine();
            bool parseHeight = int.TryParse(height, out int howTall);
            if (parseHeight && howTall >= 48 && howTall <= 120)
            {
                newMonster.Height = howTall;
            }
            else
            {
                Console.WriteLine("Invalid input. Monsters should be between 48 and 120 inches tall. Press enter to continue.");
                // if else to check ConsoleKey.
            }
        }
    }
}