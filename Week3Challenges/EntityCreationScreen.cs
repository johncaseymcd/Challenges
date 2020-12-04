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

        // List of all characters
        List<Entity> _allEntities = new List<Entity>();

        public void Run()
        {
            SeedEntityList();
            Menu();
        }

        private void Menu()
        {
        MainMenu:
            Console.Clear();
            Console.WriteLine("What would you like to do?\n" +
                "1. Create a character\n" +
                "2. View all characters\n" +
                "3. Edit an existing character\n" +
                "4. Delete an existing character\n" +
                "5. Exit");
            string mainMenuChoice = Console.ReadLine();
            bool parseMainMenu = int.TryParse(mainMenuChoice, out int whatToDo);
            if (parseMainMenu)
            {
                Console.Clear();
                switch (whatToDo)
                {
                    case 1:
                        goto EntityCreate;
                    case 2:
                        goto EntityView;
                    case 3:
                        goto EntityEdit;
                    case 4:
                        goto EntityDelete;
                    case 5:
                        Console.WriteLine("Goodbye!");
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
                            PressEnterScript();
                            goto default;
                        }
                }
            }
            else
            {
                PressEnterScript();
                goto MainMenu;
            }

        EntityCreate:
            Console.Clear();
            Console.WriteLine("What kind of character are you creating?\n" +
                "1. Player Character\n" +
                "2. Monster\n" +
                "3. Non-Player Character");
            string createChoice = Console.ReadLine();
            bool parseCreateChoice = int.TryParse(createChoice, out int whichCharacter);
            if (parseCreateChoice)
            {
                switch (whichCharacter)
                {
                    case 1:
                    // Code for Character creation
                    CreateCharacter:
                        Console.Clear();
                        EnterDetails_Character();
                        Console.WriteLine("Would you like to edit your character (y/n)?");
                        string toChange = Console.ReadLine().ToLower();
                        if (toChange == "y")
                        {
                            goto CreateCharacter;
                        }
                        else
                        {
                            _characterList.Add(newCharacter);
                            Console.WriteLine("Character successfully created!");
                            Console.ReadLine();
                            goto MainMenu;
                        }
                    case 2:
                    // Code for Monster creation
                    CreateMonster:
                        Console.Clear();
                        EnterDetails_Monster();
                        Console.WriteLine("Would you like to edit your character (y/n)?");
                        string toChangeMonster = Console.ReadLine().ToLower();
                        if (toChangeMonster == "y")
                        {
                            goto CreateMonster;
                        }
                        else
                        {
                            _monsterList.Add(newMonster);
                            Console.WriteLine("Monster successfully created!");
                            Console.ReadLine();
                            goto MainMenu;
                        }
                    case 3:
                    // Code for NPC creation
                    CreateNPC:
                        Console.Clear();
                        EnterDetails_NPC();
                        Console.WriteLine("Would you like to edit this character (y/n)?");
                        string toChangeNPC = Console.ReadLine().ToLower();
                        if (toChangeNPC == "y")
                        {
                            goto CreateNPC;
                        }
                        else
                        {
                            _npcList.Add(newNPC);
                            Console.WriteLine("NPC successfully created!");
                            Console.ReadLine();
                            goto MainMenu;
                        }
                    default:
                        Console.WriteLine("Invalid input. Press enter to continue.");
                        if (Console.ReadKey().Key == ConsoleKey.Enter)
                        {
                            goto EntityCreate;
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
                goto EntityCreate;
            }

        EntityView:
            Console.Clear();
            Console.WriteLine("What kind of characters would you like to view?\n" +
                "1. Player characters\n" +
                "2. Monsters\n" +
                "3. NPCs\n" +
                "4. All characters\n" +
                "5. Exit");
            string viewChoice = Console.ReadLine();
            bool parseViewChoice = int.TryParse(viewChoice, out int whatToView);
            if (parseViewChoice)
            {
                Console.Clear();
                switch (whatToView)
                {
                    case 1:
                        int characterCount = 0;
                        foreach(var character in _characterList)
                        {
                            characterCount++;
                            Console.WriteLine($"{characterCount}. {character.Name}: {character.Alignment.ToString().Replace('_', ' ').Remove(0, 2)} {character.EntityClass.ToString().Remove(0, 2)} {character.Race.ToString().Remove(0, 2)}\n");
                        }
                        Console.ReadLine();
                        goto MainMenu;
                    case 2:
                        int monsterCount = 0;
                        foreach(var monster in _monsterList)
                        {
                            monsterCount++;
                            Console.WriteLine($"{monsterCount}. {monster.Name}: {monster.Alignment.ToString().Replace('_', ' ').Remove(0,2)} {monster.EntityClass.ToString().Remove(0, 2)} {monster.Race.ToString().Remove(0,2)}\n");
                        }
                        Console.ReadLine();
                        goto MainMenu;
                    case 3:
                        int npcCount = 0;
                        foreach(var npc in _npcList)
                        {
                            npcCount++;
                            Console.WriteLine($"{npcCount}. {npc.Name}: {npc.Alignment.ToString().Replace('_', ' ').Remove(0, 2)} {npc.EntityClass.ToString().Remove(0, 2)} {npc.Race.ToString().Remove(0, 2)}");
                        }
                        Console.ReadLine();
                        goto MainMenu;
                    case 4:
                        AggregateEntityLists();
                        int entityCount = 0;
                        foreach(var entity in _allEntities)
                        {
                            entityCount++;
                            if (entityCount <= _characterList.Count)
                            {
                                Console.WriteLine($"{entityCount}. {entity.Name} is a player character who is a {entity.Alignment.ToString().Replace('_', ' ').Remove(0, 2)} {entity.EntityClass.ToString().Remove(0, 2)} {entity.Race.ToString().Remove(0, 2)}");
                            }
                            else if(entityCount > _characterList.Count && entityCount <= (_characterList.Count + _monsterList.Count))
                            {
                                Console.WriteLine($"{entityCount}. {entity.Name} is a monster who is a {entity.Alignment.ToString().Replace('_', ' ').Remove(0, 2)} {entity.EntityClass.ToString().Remove(0, 2)} {entity.Race.ToString().Remove(0, 2)}");
                            }
                            else if (entityCount > _characterList.Count + _monsterList.Count)
                            {
                                Console.WriteLine($"{entityCount}. {entity.Name} is an NPC who is a {entity.Alignment.ToString().Replace('_', ' ').Remove(0, 2)} {entity.EntityClass.ToString().Remove(0, 2)} {entity.Race.ToString().Remove(0, 2)}");
                            }
                        }
                        Console.ReadLine();
                        goto MainMenu;
                    case 5:
                        goto MainMenu;
                    default:
                        Console.WriteLine("Invalid input. Press enter to continue.");
                        if (Console.ReadKey().Key == ConsoleKey.Enter)
                        {
                            goto EntityView;
                        }
                        else
                        {
                            PressEnterScript();
                            goto EntityView;
                        }
                }
            }
            else
            {
                PressEnterScript();
                goto EntityView;
            }

        EntityEdit:
            Console.Clear();
            Console.WriteLine("Enter the name of the character you'd like to edit:");
            string entityToEdit = Console.ReadLine();
            foreach(var character in _characterList)
            {
                if (entityToEdit == character.Name)
                {
                    bool wasCharacterUpdated = characterInfo.Edit(entityToEdit, EnterDetails_Character());
                    if (wasCharacterUpdated)
                    {
                        Console.WriteLine("Update successful!");
                        Console.ReadLine();
                        goto MainMenu;
                    }
                    else
                    {
                        Console.WriteLine("Could not edit character. Please try again.");
                        Console.ReadLine();
                        goto EntityEdit;
                    }
                }
            }

            foreach(var monster in _monsterList)
            {
                if (entityToEdit == monster.Name)
                {
                    bool wasMonsterUpdated = monsterInfo.Edit(entityToEdit, EnterDetails_Monster());
                    if (wasMonsterUpdated)
                    {
                        Console.WriteLine("Update successful!");
                        Console.ReadLine();
                        goto MainMenu;
                    }
                    else
                    {
                        Console.WriteLine("Could not edit monster. Please try again.");
                        Console.ReadLine();
                        goto EntityEdit;
                    }
                }
            }

            foreach (var npc in _npcList)
            {
                if (entityToEdit == npc.Name)
                {
                    bool wasNPCUpdated = npcInfo.Edit(entityToEdit, EnterDetails_NPC());
                    if (wasNPCUpdated)
                    {
                        Console.WriteLine("Update successful!");
                        Console.ReadLine();
                        goto MainMenu;
                    }
                    else
                    {
                        Console.WriteLine("Could not edit NPC. Please try again.");
                        Console.ReadLine();
                        goto EntityEdit;
                    }
                }
            }

        EntityDelete:
            Console.Clear();
            Console.WriteLine("Enter the name of the character you'd like to delete.");
            string entityToDelete = Console.ReadLine();
            foreach(var character in _characterList)
            {
                if (entityToDelete == character.Name)
                {
                    bool wasCharacterDeleted = characterInfo.Delete(entityToDelete);
                    if (wasCharacterDeleted)
                    {
                        Console.WriteLine("Character successfully deleted.");
                        Console.ReadLine();
                        goto MainMenu;
                    }
                    else
                    {
                        Console.WriteLine("Could not delete character. Please try again.");
                        Console.ReadLine();
                        goto EntityDelete;
                    }
                }
            }

            foreach(var monster in _monsterList)
            {
                if (entityToDelete == monster.Name)
                {
                    bool wasMonsterDeleted = monsterInfo.Delete(entityToDelete);
                    if (wasMonsterDeleted)
                    {
                        Console.WriteLine("Monster successfully deleted.");
                        Console.ReadLine();
                        goto MainMenu;
                    }
                    else
                    {
                        Console.WriteLine("Could not delete monster. Please try again.");
                        Console.ReadLine();
                        goto EntityDelete;
                    }
                }
            }

            foreach(var npc in _npcList)
            {
                if(entityToDelete == npc.Name)
                {
                    bool wasNPCDeleted = npcInfo.Delete(entityToDelete);
                    if (wasNPCDeleted)
                    {
                        Console.WriteLine("NPC successfully deleted.");
                        Console.ReadLine();
                        goto MainMenu;
                    }
                    else
                    {
                        Console.WriteLine("Could not delete NPC. Please try again.");
                        Console.ReadLine();
                        goto EntityDelete;
                    }
                }
            }
        }

        private void AggregateEntityLists()
        {
            foreach (var character in _characterList)
            {
                _allEntities.Add(character);
            }

            foreach (var monster in _monsterList)
            {
                _allEntities.Add(monster);
            }

            foreach (var npc in _npcList)
            {
                _allEntities.Add(npc);
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

        private Entity EnterDetails_Character()
        {
            // Choose Race
            List<string> characterRaces = characterInfo.FindRace_Character();

        RaceSelect:
            Console.Clear();

            Console.WriteLine("Choose a character race:");
            int raceCount = 0;
            foreach (string raceName in characterRaces)
            {
                raceCount++;
                Console.WriteLine($"{raceCount}. {raceName.Remove(0, 2)}");
            }

            string inputRace = Console.ReadLine();
            bool parseRace = int.TryParse(inputRace, out int whichRace);

            if (parseRace)
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

            // Choose class
            List<string> characterClasses = characterInfo.FindClass_Character();

        ClassSelect:
            Console.Clear();

            Console.WriteLine("Choose a character class:");
            int classCount = 0;
            foreach (string className in characterClasses)
            {
                classCount++;
                Console.WriteLine($"{classCount}. {className.Remove(0, 2)}");
            }

            string inputClass = Console.ReadLine();
            bool parseClass = int.TryParse(inputClass, out int whichClass);
            if (parseClass)
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

            // Choose alignment
            List<string> characterAlignments = characterInfo.FindAlignment_CharacterAndNPC();

        AlignmentSelect:
            Console.Clear();
            Console.WriteLine("Choose the character's alignment:");

            int alignmentCount = 0;

            foreach (string alignmentName in characterAlignments)
            {
                alignmentCount++;
                string alignment = alignmentName.Replace('_', ' ');
                Console.WriteLine($"{alignmentCount}. {alignment.Remove(0, 2)}");
            }


            string inputAlignment = Console.ReadLine();
            bool parseAlignment = int.TryParse(inputAlignment, out int whichAlignment);

            if (parseAlignment)
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

        // Name
            Console.Clear();
            Console.WriteLine("What is the character's name?");
            newCharacter.Name = Console.ReadLine();

        // Height
        SetHeight:
            Console.Clear();
            Console.WriteLine($"How tall is {newCharacter.Name} (in inches)?");

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
            Console.WriteLine($"How much does {newCharacter.Name} weigh (in pounds)?");

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
            var rndStr = new Random();
            Console.WriteLine($"What is {newCharacter.Name}'s base Strength?\n" +
                "Enter a number from 10 - 20 or press R to roll a d20.");
            string strength = Console.ReadLine().ToLower();
            bool parseStr = int.TryParse(strength, out int howStrong);
            if (parseStr && howStrong >= 10 && howStrong <= 20)
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
            var rndDex = new Random();
            Console.WriteLine($"What is {newCharacter.Name}'s base Dexterity?\n" +
                "Enter a number from 10 - 20 or press R to roll a d20.");
            string dexterity = Console.ReadLine().ToLower();
            bool parseDex = int.TryParse(dexterity, out int howDexterous);
            if (parseDex && howDexterous >= 10 && howDexterous <= 20)
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
            var rndCon = new Random();
            Console.WriteLine($"What is {newCharacter.Name}'s base Constitution?\n" +
                "Enter a number from 10 - 20 or press R to roll a d20.");
            string constitution = Console.ReadLine().ToLower();
            bool parseCon = int.TryParse(constitution, out int howConstituted);
            if (parseCon && howConstituted >= 10 && howConstituted <= 20)
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
            var rndInt = new Random();
            Console.WriteLine($"What is {newCharacter.Name}'s base Intelligence?\n" +
                "Enter a number from 10 - 20 or press R to roll a d20.");
            string intelligence = Console.ReadLine().ToLower();
            bool parseInt = int.TryParse(intelligence, out int howIntelligent);
            if (parseInt && howIntelligent >= 10 && howIntelligent <= 20)
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
            var rndWis = new Random();
            Console.WriteLine($"What is {newCharacter.Name}'s base Wisdom?\n" +
                "Enter a number from 10 - 20 or press R to roll a d20.");
            string wisdom = Console.ReadLine().ToLower();
            bool parseWis = int.TryParse(wisdom, out int howWise);
            if (parseWis && howWise >= 10 && howWise <= 20)
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
            var rndPer = new Random();
            Console.WriteLine($"What is {newCharacter.Name}'s base Perception?\n" +
                "Enter a number from 10 - 20 or press R to roll a d20.");
            string perception = Console.ReadLine().ToLower();
            bool parsePer = int.TryParse(perception, out int howPerceptive);
            if (parsePer && howPerceptive >= 10 && howPerceptive <= 20)
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
            var rndArm = new Random();
            Console.WriteLine($"What is {newCharacter.Name}'s base Armor?\n" +
                "Enter a number from 10 - 20 or press R to roll a d20.");
            string armor = Console.ReadLine().ToLower();
            bool parseArm = int.TryParse(armor, out int howArmored);
            if (parseArm && howArmored >= 10 && howArmored <= 20)
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
            var rndHealth = new Random();
            int healthSum = 0;
            Console.WriteLine($"What is {newCharacter.Name}'s base Health?\n" +
                "Enter a number from 10 - 32 or press R to roll 4d8.");
            string health = Console.ReadLine().ToLower();
            bool parseHealth = int.TryParse(health, out int howHealthy);
            if (parseHealth && howHealthy >= 10 && howHealthy <= 32)
            {
                newCharacter.Health = howHealthy;
            }
            else if (health == "r")
            {
                for (int dieRolls = 1; dieRolls <=4; dieRolls++)
                { 
                    healthSum += rndHealth.Next(3, 8);
                }
                newCharacter.Health = healthSum;
            }
            else
            {
                PressEnterScript();
                goto SetHealth;
            }

            Console.Clear();
            Console.WriteLine($"Your character's name is {newCharacter.Name}.\n" +
                $"{newCharacter.Name} is a {newCharacter.Alignment.ToString().Replace('_', ' ').Remove(0,2)} {newCharacter.EntityClass.ToString().Remove(0,2)} {newCharacter.Race.ToString().Remove(0,2)}.\n" +
                $"{newCharacter.Name} is {newCharacter.Height} inches tall and weighs {newCharacter.Weight} pounds.\n" +
                $"{newCharacter.Name}'s stats are as follows:\n" +
                $"Strength: {newCharacter.Strength}\n" +
                $"Dexterity: {newCharacter.Dexterity}\n" +
                $"Constitution: {newCharacter.Constitution}\n" +
                $"Intelligence: {newCharacter.Intelligence}\n" +
                $"Wisdom: {newCharacter.Wisdom}\n" +
                $"Perception: {newCharacter.Perception}\n" +
                $"Armor: {newCharacter.Armor}\n" +
                $"Health: {newCharacter.Health}");
            return newCharacter;
        }

        private Entity EnterDetails_Monster()
        {
            // Choose race
            List<string> monsterRaces = monsterInfo.FindRace_Monster();

        RaceSelect:
            Console.Clear();

            Console.WriteLine("Choose the monster's race:");
            int raceCount = 0;
            foreach (string raceName in monsterRaces)
            {
                raceCount++;
                Console.WriteLine($"{raceCount}. {raceName.Remove(0, 2)}");
            }

            string inputRace = Console.ReadLine();
            bool parseRace = int.TryParse(inputRace, out int whichRace);

            if (parseRace)
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

            // Choose class
            List<string> monsterClasses = monsterInfo.FindClass_Monster();

        ClassSelect:
            Console.Clear();

            Console.WriteLine("Choose the monster's class:");
            int classCount = 0;
            foreach (string className in monsterClasses)
            {
                classCount++;
                Console.WriteLine($"{classCount}. {className.Remove(0, 2)}");
            }

            string inputClass = Console.ReadLine();
            bool parseClass = int.TryParse(inputClass, out int whichClass);

            if (parseClass)
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

            // Choose alignment
            List<string> monsterAlignments = monsterInfo.FindAlignment_Monster();

        AlignmentSelect:
            Console.Clear();

            Console.WriteLine("Choose the monster's alignment:");
            int alignmentCount = 0;
            foreach (string alignmentName in monsterAlignments)
            {
                alignmentCount++;
                string alignment = alignmentName.Replace('_', ' ');
                Console.WriteLine($"{alignmentCount}. {alignment.Remove(0, 2)}");
            }

            string inputAlignment = Console.ReadLine();
            bool parseAlignment = int.TryParse(inputAlignment, out int whichAlignment);

            if (parseAlignment)
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

        // Name
            Console.Clear();
            Console.WriteLine("What is the monster's name?");
            newMonster.Name = Console.ReadLine();

        // Height
        SetHeight:
            Console.Clear();
            Console.WriteLine($"How tall is {newMonster.Name} (in inches)?");
            string height = Console.ReadLine();
            bool parseHeight = int.TryParse(height, out int howTall);
            if (parseHeight && howTall >= 48 && howTall <= 120)
            {
                newMonster.Height = howTall;
            }
            else
            {
                Console.WriteLine("Invalid input. Monsters should be between 48 and 120 inches tall. Press enter to continue.");
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
            Console.WriteLine($"How much does {newMonster.Name} weigh (in pounds)?");
            string weight = Console.ReadLine();
            bool parseWeight = int.TryParse(weight, out int howHeavy);
            if (parseWeight && howHeavy >= 50 && howHeavy <= 600)
            {
                newMonster.Weight = howHeavy;
            }
            else
            {
                Console.WriteLine("Invalid input. Monsters should weigh between 50 and 600 pounds. Press enter to continue.");
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
            var rndStr = new Random();
            Console.WriteLine($"What is {newMonster.Name}'s base strength?\n" +
                $"Enter a number from 10 - 20 or press R to roll a d20.");
            string strength = Console.ReadLine().ToLower();
            bool parseStr = int.TryParse(strength, out int howStrong);
            if (parseStr && howStrong >= 10 && howStrong <= 20)
            {
                newMonster.Strength = howStrong;
            }
            else if (strength == "r")
            {
                newMonster.Strength = rndStr.Next(10, 20);
            }
            else
            {
                PressEnterScript();
                goto SetStrength;
            }

        // Dexterity
        SetDexterity:
            Console.Clear();
            var rndDex = new Random();
            Console.WriteLine($"What is {newMonster.Name}'s base dexterity?\n" +
                $"Enter a number from 10 - 20 or press R to roll a d20.");
            string dexterity = Console.ReadLine().ToLower();
            bool parseDex = int.TryParse(dexterity, out int howDexterous);
            if (parseDex && howDexterous >= 10 && howDexterous <= 20)
            {
                newMonster.Dexterity = howDexterous;
            }
            else if (dexterity == "r")
            {
                newMonster.Dexterity = rndDex.Next(10, 20);
            }
            else
            {
                PressEnterScript();
                goto SetDexterity;
            }

        // Constitution
        SetConstitution:
            Console.Clear();
            var rndCon = new Random();
            Console.WriteLine($"What is {newMonster.Name}'s base constitution?\n" +
                $"Enter a number from 10 - 20 or press R to roll a d20.");
            string constitution = Console.ReadLine().ToLower();
            bool parseCon = int.TryParse(constitution, out int howConstituted);
            if (parseCon && howConstituted >= 10 && howConstituted <= 20)
            {
                newMonster.Constitution = howConstituted;
            }
            else if (constitution == "r")
            {
                newMonster.Dexterity = rndCon.Next(10, 20);
            }
            else
            {
                PressEnterScript();
                goto SetConstitution;
            }

        // Intelligence
        SetIntelligence:
            Console.Clear();
            var rndInt = new Random();
            Console.WriteLine($"What is {newMonster.Name}'s base intelligence?\n" +
                $"Enter a number from 10 - 20 or press R to roll a d20.");
            string intelligence = Console.ReadLine().ToLower();
            bool parseInt = int.TryParse(intelligence, out int howIntelligent);
            if (parseInt && howIntelligent >= 10 && howIntelligent <= 20)
            {
                newMonster.Intelligence = howIntelligent;
            }
            else if (constitution == "r")
            {
                newMonster.Intelligence = rndInt.Next(10, 20);
            }
            else
            {
                PressEnterScript();
                goto SetIntelligence;
            }

        // Wisdom
        SetWisdom:
            Console.Clear();
            var rndWis = new Random();
            Console.WriteLine($"What is {newMonster.Name}'s base wisdom?\n" +
                $"Enter a number from 10 - 20 or press R to roll a d20.");
            string wisdom = Console.ReadLine().ToLower();
            bool parseWis = int.TryParse(wisdom, out int howWise);
            if (parseWis && howWise >= 10 && howWise <= 20)
            {
                newMonster.Wisdom = howWise;
            }
            else if (wisdom == "r")
            {
                newMonster.Wisdom = rndWis.Next(10, 20);
            }
            else
            {
                PressEnterScript();
                goto SetWisdom;
            }

        // Perception
        SetPerception:
            Console.Clear();
            var rndPer = new Random();
            Console.WriteLine($"What is {newMonster.Name}'s base perception?\n" +
                $"Enter a number from 10 - 20 or press R to roll a d20.");
            string perception = Console.ReadLine().ToLower();
            bool parsePer = int.TryParse(perception, out int howPerceptive);
            if (parsePer && howPerceptive >= 10 && howPerceptive <= 20)
            {
                newMonster.Perception = howPerceptive;
            }
            else if (perception == "r")
            {
                newMonster.Perception = rndPer.Next(10, 20);
            }
            else
            {
                PressEnterScript();
                goto SetPerception;
            }

        // Armor
        SetArmor:
            Console.Clear();
            var rndArm = new Random();
            Console.WriteLine($"What is {newMonster.Name}'s base armor?\n" +
                $"Enter a number from 10 - 20 or press R to roll a d20.");
            string armor = Console.ReadLine().ToLower();
            bool parseArm = int.TryParse(armor, out int howArmored);
            if (parseArm && howArmored >= 10 && howArmored <= 20)
            {
                newMonster.Armor = howArmored;
            }
            else if (armor == "r")
            {
                newMonster.Armor = rndArm.Next(10, 20);
            }
            else
            {
                PressEnterScript();
                goto SetArmor;
            }

        // Health
        SetHealth:
            Console.Clear();
            var rndHealth = new Random();
            int healthSum = 0;
            Console.WriteLine($"What is {newMonster.Name}'s base health?\n" +
                $"Enter a number from 10 - 32 or press R to roll 4d8.");
            string health = Console.ReadLine().ToLower();
            bool parseHealth = int.TryParse(health, out int howHealthy);
            if (parseHealth && howHealthy >= 10 && howHealthy <= 32)
            {
                newMonster.Health = howHealthy;
            }
            else if (health == "r")
            {
                for (int dieRolls = 1; dieRolls <= 4; dieRolls++)
                {
                    healthSum += rndHealth.Next(3, 8);
                }
                newMonster.Health = healthSum;
            }
            else
            {
                PressEnterScript();
                goto SetHealth;
            }

            Console.Clear();
            Console.WriteLine($"Your character's name is {newMonster.Name}.\n" +
                $"{newMonster.Name} is a {newMonster.Alignment.ToString().Replace('_', ' ').Remove(0,2)} {newMonster.EntityClass.ToString().Remove(0,2)} {newMonster.Race.ToString().Remove(0,2)}.\n" +
                $"{newMonster.Name} is {newMonster.Height} inches tall and weighs {newMonster.Weight} pounds.\n" +
                $"{newMonster.Name}'s stats are as follows:\n" +
                $"Strength: {newMonster.Strength}\n" +
                $"Dexterity: {newMonster.Dexterity}\n" +
                $"Constitution: {newMonster.Constitution}\n" +
                $"Intelligence: {newMonster.Intelligence}\n" +
                $"Wisdom: {newMonster.Wisdom}\n" +
                $"Perception: {newMonster.Perception}\n" +
                $"Armor: {newMonster.Armor}\n" +
                $"Health: {newMonster.Health}");
            return newMonster;
        }

        private Entity EnterDetails_NPC()
        {
            // Choose Race
            var npcRaces = npcInfo.GetAllRaces();

        RaceSelect:
            Console.Clear();
            Console.WriteLine("Choose a race:");
            int raceCount = 0;
            foreach (string race in npcRaces)
            {
                raceCount++;
                Console.WriteLine($"{raceCount}. {race.Remove(0, 2)}");
            }

            string inputRace = Console.ReadLine();
            bool parseRace = int.TryParse(inputRace, out int whichRace);

            if (parseRace)
            {
                switch (whichRace)
                {
                    case 1:
                        newNPC.Race = EntityRace.M_Bugbear;
                        break;
                    case 2:
                        newNPC.Race = EntityRace.M_Centaur;
                        break;
                    case 3:
                        newNPC.Race = EntityRace.C_Dwarf;
                        break;
                    case 4:
                        newNPC.Race = EntityRace.C_Elf;
                        break;
                    case 5:
                        newNPC.Race = EntityRace.C_Gnome;
                        break;
                    case 6:
                        newNPC.Race = EntityRace.M_Goblin;
                        break;
                    case 7:
                        newNPC.Race = EntityRace.C_Halfling;
                        break;
                    case 8:
                        newNPC.Race = EntityRace.M_Hobgoblin;
                        break;
                    case 9:
                        newNPC.Race = EntityRace.C_Human;
                        break;
                    case 10:
                        newNPC.Race = EntityRace.M_Kenku;
                        break;
                    case 11:
                        newNPC.Race = EntityRace.M_Kobold;
                        break;
                    case 12:
                        newNPC.Race = EntityRace.M_Lizardfolk;
                        break;
                    case 13:
                        newNPC.Race = EntityRace.M_Minotaur;
                        break;
                    case 14:
                        newNPC.Race = EntityRace.B_Orc;
                        break;
                    case 15:
                        newNPC.Race = EntityRace.C_Tiefling;
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

            // Choose class
            var npcClasses = npcInfo.GetAllClasses();

        ClassSelect:
            Console.Clear();
            Console.WriteLine("Choose a class:");
            int classCount = 0;
            foreach (string className in npcClasses)
            {
                classCount++;
                Console.WriteLine($"{classCount}. {className.Remove(0, 2)}");
            }

            string inputClass = Console.ReadLine();
            bool parseClass = int.TryParse(inputClass, out int whichClass);
            if (parseClass)
            {
                switch (whichClass)
                {
                    case 1:
                        newNPC.EntityClass = EntityClass.B_Barbarian;
                        break;
                    case 2:
                        newNPC.EntityClass = EntityClass.C_Bard;
                        break;
                    case 3:
                        newNPC.EntityClass = EntityClass.C_Cleric;
                        break;
                    case 4:
                        newNPC.EntityClass = EntityClass.C_Druid;
                        break;
                    case 5:
                        newNPC.EntityClass = EntityClass.B_Fighter;
                        break;
                    case 6:
                        newNPC.EntityClass = EntityClass.C_Monk;
                        break;
                    case 7:
                        newNPC.EntityClass = EntityClass.C_Paladin;
                        break;
                    case 8:
                        newNPC.EntityClass = EntityClass.B_Ranger;
                        break;
                    case 9:
                        newNPC.EntityClass = EntityClass.B_Rogue;
                        break;
                    case 10:
                        newNPC.EntityClass = EntityClass.B_Wizard;
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

            // Choose alignment
            var alignments = npcInfo.FindAlignment_CharacterAndNPC();

        AlignmentSelect:
            Console.WriteLine("Choose an alignment:");
            int alignmentCount = 0;
            foreach (string alignmentName in alignments)
            {
                alignmentCount++;
                Console.WriteLine($"{alignmentCount}. {alignmentName.Remove(0, 2)}");
            }

            string inputAlignment = Console.ReadLine();
            bool parseAlignment = int.TryParse(inputAlignment, out int whichAlignment);
            if (parseAlignment)
            {
                switch (whichAlignment)
                {
                    case 1:
                        newNPC.Alignment = EntityAlignment.C_Lawful_Good;
                        break;
                    case 2:
                        newNPC.Alignment = EntityAlignment.C_Neutral_Good;
                        break;
                    case 3:
                        newNPC.Alignment = EntityAlignment.C_Chaotic_Good;
                        break;
                    case 4:
                        newNPC.Alignment = EntityAlignment.C_Lawful_Neutral;
                        break;
                    case 5:
                        newNPC.Alignment = EntityAlignment.B_True_Neutral;
                        break;
                    case 6:
                        newNPC.Alignment = EntityAlignment.B_Chaotic_Neutral;
                        break;
                    case 7:
                        newNPC.Alignment = EntityAlignment.B_Lawful_Evil;
                        break;
                    case 8:
                        newNPC.Alignment = EntityAlignment.B_Neutral_Evil;
                        break;
                    case 9:
                        newNPC.Alignment = EntityAlignment.B_Chaotic_Evil;
                        break;
                    default:
                        Console.WriteLine("Invalid input. Press enter to continue.");
                        if (Console.ReadKey().Key == ConsoleKey.Enter)
                        {
                            goto AlignmentSelect;
                        }
                        else
                        {
                            PressEnterScript();
                            goto AlignmentSelect;
                        }
                }
            }
            else
            {
                PressEnterScript();
                goto AlignmentSelect;
            }

            // Name
            Console.Clear();
            Console.WriteLine("What is the character's name?");
            newNPC.Name = Console.ReadLine();

        // Height
        SetHeight:
            Console.Clear();
            Console.WriteLine($"How tall is {newNPC.Name} (in inches)?");
            string height = Console.ReadLine();
            bool parseHeight = int.TryParse(height, out int howTall);
            if (parseHeight && howTall >= 24 && howTall <= 120)
            {
                newNPC.Height = howTall;
            }
            else
            {
                Console.WriteLine("Invalid input. NPCs should be between 24 and 120 inches tall. Press enter to continue.");
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
            Console.WriteLine($"How much does {newNPC.Name} weight (in pounds)?");
            string weight = Console.ReadLine();
            bool parseWeight = int.TryParse(weight, out int howHeavy);
            if (parseWeight && howHeavy >= 25 && howHeavy <= 600)
            {
                newNPC.Weight = howHeavy;
            }
            else
            {
                Console.WriteLine("Invalid input. NPCs should weigh between 25 and 600 pounds. Press enter to continue.");
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
            var rndStrength = new Random();
            Console.Clear();
            Console.WriteLine($"What is {newNPC.Name}'s base strength?\n" +
                $"Enter a number from 10 - 20 or press R to roll a d20.");
            string strength = Console.ReadLine().ToLower();
            bool parseStrength = int.TryParse(strength, out int howStrong);
            if (parseStrength && howStrong >= 10 && howStrong <= 20)
            {
                newNPC.Strength = howStrong;
            }
            else if (strength == "r")
            {
                newNPC.Strength = rndStrength.Next(10, 20);
            }
            else
            {
                PressEnterScript();
                goto SetStrength;
            }

        // Dexterity
        SetDexterity:
            var rndDexterity = new Random();
            Console.Clear();
            Console.WriteLine($"What is {newNPC.Name}'s base dexterity?\n" +
                $"Enter a number from 10 - 20 or press R to roll a d20.");
            string dexterity = Console.ReadLine().ToLower();
            bool parseDexterity = int.TryParse(dexterity, out int howDexterous);
            if (parseDexterity && howDexterous >= 10 && howDexterous <= 20)
            {
                newNPC.Dexterity = howDexterous;
            }
            else if (dexterity == "r")
            {
                newNPC.Dexterity = rndDexterity.Next(10, 20);
            }
            else
            {
                PressEnterScript();
                goto SetDexterity;
            }

        // Constitution
        SetConstitution:
            var rndConstitution = new Random();
            Console.Clear();
            Console.WriteLine($"What is {newNPC.Name}'s base constitution?\n" +
                $"Enter a number from 10 - 20 or press R to roll a d20.");
            string constitution = Console.ReadLine().ToLower();
            bool parseConstitution = int.TryParse(constitution, out int howConstituted);
            if (parseConstitution && howConstituted >= 10 && howConstituted <= 20)
            {
                newNPC.Constitution = howConstituted;
            }
            else if (constitution == "r")
            {
                newNPC.Constitution = rndConstitution.Next(10, 20);
            }
            else
            {
                PressEnterScript();
                goto SetConstitution;
            }

        // Intelligence
        SetIntelligence:
            var rndIntelligence = new Random();
            Console.Clear();
            Console.WriteLine($"What is {newNPC.Name}'s base intelligence?\n" +
                $"Enter a number from 10 - 20 or press R to roll a d20.");
            string intelligence = Console.ReadLine().ToLower();
            bool parseIntelligence = int.TryParse(intelligence, out int howIntelligent);
            if (parseIntelligence && howIntelligent >= 10 && howIntelligent <= 20)
            {
                newNPC.Intelligence = howIntelligent;
            }
            else if (intelligence == "r")
            {
                newNPC.Intelligence = rndIntelligence.Next(10, 20);
            }
            else
            {
                PressEnterScript();
                goto SetIntelligence;
            }

        // Wisdom
        SetWisdom:
            var rndWisdom = new Random();
            Console.Clear();
            Console.WriteLine($"What is {newNPC.Name}'s base wisdom?\n" +
                $"Enter a number from 10 - 20 or press R to roll a d20.");
            string wisdom = Console.ReadLine().ToLower();
            bool parseWisdom = int.TryParse(wisdom, out int howWise);
            if (parseWisdom && howWise >= 10 && howWise <= 20)
            {
                newNPC.Wisdom = howWise;
            }
            else if (wisdom == "r")
            {
                newNPC.Wisdom = rndWisdom.Next(10, 20);
            }
            else
            {
                PressEnterScript();
                goto SetWisdom;
            }

        // Perception
        SetPerception:
            var rndPerception = new Random();
            Console.Clear();
            Console.WriteLine($"What is {newNPC.Name}'s base perception?\n" +
                $"Enter a number from 10 - 20 or press R to roll a d20.");
            string perception = Console.ReadLine().ToLower();
            bool parsePerception = int.TryParse(perception, out int howPerceptive);
            if (parsePerception && howPerceptive >= 10 && howPerceptive <= 20)
            {
                newNPC.Perception = howPerceptive;
            }
            else if (perception == "r")
            {
                newNPC.Perception = rndPerception.Next(10, 20);
            }
            else
            {
                PressEnterScript();
                goto SetPerception;
            }

        // Armor
        SetArmor:
            var rndArmor = new Random();
            Console.Clear();
            Console.WriteLine($"What is {newNPC.Name}'s base armor?\n" +
                $"Enter a number from 10 - 20 or press R to roll a d20.");
            string armor = Console.ReadLine().ToLower();
            bool parseArmor = int.TryParse(armor, out int howArmored);
            if (parseArmor && howArmored >= 10 && howArmored <= 20)
            {
                newNPC.Armor = howArmored;
            }
            else if (armor == "r")
            {
                newNPC.Armor = rndArmor.Next(10, 20);
            }
            else
            {
                PressEnterScript();
                goto SetArmor;
            }

        // Health
        SetHealth:
            var rndHealth = new Random();
            Console.Clear();
            Console.WriteLine($"What is {newNPC.Name}'s base health?\n" +
                $"Enter a number from 10 - 32 or press R to roll 4d8.");
            string health = Console.ReadLine().ToLower();
            bool parseHealth = int.TryParse(health, out int howHealthy);
            if (parseHealth && howHealthy >= 10 && howHealthy <= 32)
            {
                newNPC.Health = howHealthy;
            }
            else if (health == "r")
            {
                int healthSum = 0;
                for (int dieRolls = 1; dieRolls <= 4; dieRolls++)
                {
                    healthSum += rndHealth.Next(3, 8);
                }

                newNPC.Health = healthSum;
            }
            else
            {
                PressEnterScript();
                goto SetHealth;
            }

            Console.Clear();
            Console.WriteLine($"Your character's name is {newNPC.Name}.\n" +
                $"{newNPC.Name} is a {newNPC.Alignment.ToString().Replace('_', ' ').Remove(0,2)} {newNPC.EntityClass.ToString().Remove(0,2)} {newNPC.Race.ToString().Remove(0,2)}.\n" +
               $"{newNPC.Name} is {newNPC.Height} inches tall and weighs {newNPC.Weight} pounds.\n" +
               $"{newNPC.Name}'s stats are as follows:\n" +
               $"Strength: {newNPC.Strength}\n" +
               $"Dexterity: {newNPC.Dexterity}\n" +
               $"Constitution: {newNPC.Constitution}\n" +
               $"Intelligence: {newNPC.Intelligence}\n" +
               $"Wisdom: {newNPC.Wisdom}\n" +
               $"Perception: {newNPC.Perception}\n" +
               $"Armor: {newNPC.Armor}\n" +
               $"Health: {newNPC.Health}");
            return newNPC;
        }

        private void SeedEntityList()
        {
            var player1 = new Entity(EntityRace.C_Halfling, EntityClass.B_Rogue, EntityAlignment.B_Chaotic_Neutral, "Hanenbow Burrows", 35, 65, 11, 14, 12, 14, 13, 16, 18, 22);
            var player2 = new Entity(EntityRace.C_Human, EntityClass.C_Monk, EntityAlignment.B_Lawful_Evil, "Antonin Luna", 77, 277, 12, 13, 13, 13, 15, 17, 13, 22);
            var player3 = new Entity(EntityRace.C_Dwarf, EntityClass.C_Paladin, EntityAlignment.C_Lawful_Good, "Fari Godhand", 54, 175, 13, 10, 11, 13, 14, 16, 16, 31);
            var player4 = new Entity(EntityRace.C_Elf, EntityClass.C_Druid, EntityAlignment.B_True_Neutral, "Iliana Petrichor", 72, 186, 10, 15, 10, 14, 12, 15, 13, 13);

            _characterList.Add(player1);
            _characterList.Add(player2);
            _characterList.Add(player3);
            _characterList.Add(player4);

            var monster1 = new Entity(EntityRace.M_Goblin, EntityClass.B_Fighter, EntityAlignment.B_Neutral_Evil, "Standard Goblin", 40, 55, 12, 10, 13, 10, 10, 11, 15, 15);
            var monster2 = new Entity(EntityRace.B_Orc, EntityClass.B_Rogue, EntityAlignment.B_Chaotic_Evil, "Standard Orc", 75, 250, 15, 13, 14, 11, 11, 13, 16, 25);
            var monster3 = new Entity(EntityRace.M_Kenku, EntityClass.B_Wizard, EntityAlignment.B_Lawful_Evil, "Standard Kenku", 63, 100, 12, 15, 12, 16, 13, 16, 11, 20);
            var monster4 = new Entity(EntityRace.M_Lizardfolk, EntityClass.B_Ranger, EntityAlignment.B_Neutral_Evil, "Standard Lizardfolk", 76, 225, 15, 13, 17, 12, 11, 13, 18, 25);

            _monsterList.Add(monster1);
            _monsterList.Add(monster2);
            _monsterList.Add(monster3);
            _monsterList.Add(monster4);

            var npc1 = new Entity(EntityRace.C_Human, EntityClass.B_Fighter, EntityAlignment.C_Lawful_Neutral, "Shopkeeper", 69, 169, 13, 13, 13, 13, 13, 13, 13, 20);
            var npc2 = new Entity(EntityRace.B_Orc, EntityClass.B_Fighter, EntityAlignment.B_True_Neutral, "Bartender", 77, 264, 16, 14, 16, 12, 11, 16, 19, 30);
            var npc3 = new Entity(EntityRace.M_Hobgoblin, EntityClass.B_Barbarian, EntityAlignment.B_Chaotic_Neutral, "Mercenary", 64, 181, 15, 17, 16, 13, 11, 14, 17, 30);
            var npc4 = new Entity(EntityRace.M_Centaur, EntityClass.C_Cleric, EntityAlignment.C_Lawful_Good, "Healer", 81, 555, 18, 10, 18, 19, 20, 20, 17, 32);

            _npcList.Add(npc1);
            _npcList.Add(npc2);
            _npcList.Add(npc3);
            _npcList.Add(npc4);
        }
    }
}