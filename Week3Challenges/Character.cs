using System;
using System.Collections.Generic;

namespace Week3Challenges
{
    // List of races categorized by Character-only C, Monster-only M, or both B
    public enum EntityRace
    {
        M_Bugbear = 1,
        M_Centaur,
        C_Dwarf,
        C_Elf,
        C_Gnome,
        M_Goblin,
        C_Halfling,
        M_Hobgoblin,
        C_Human,
        M_Kenku,
        M_Kobold,
        M_Lizardfolk,
        M_Minotaur,
        B_Orc,
        C_Tiefling
    }

    // List of classes categorized by Character-only C, Monster-only M, or both B
    public enum EntityClass
    {
        B_Barbarian = 1,
        C_Bard,
        C_Cleric,
        C_Druid,
        B_Fighter,
        C_Monk,
        C_Paladin,
        B_Ranger,
        B_Rogue,
        B_Wizard
    }

    // List of possible alignments
    public enum EntityAlignment
    {
        C_Lawful_Good = 1,
        C_Neutral_Good,
        C_Chaotic_Good,
        C_Lawful_Neutral,
        B_True_Neutral,
        B_Chaotic_Neutral,
        B_Lawful_Evil,
        B_Neutral_Evil,
        B_Chaotic_Evil
    }

    // ------------------------------------------------------------------------

    public class Entity
    {
        public EntityRace Race { get; set; }
        public EntityClass EntityClass { get; set; }
        public EntityAlignment Alignment { get; set; }
        public string Name { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Perception { get; set; }
        public int Armor { get; set; }
        public int Health { get; set; }

        public Entity() { }

        public Entity(EntityRace race, EntityClass entityClass, EntityAlignment alignment, string name, int height, int weight, int str, int dex, int con, int intel, int wis, int per, int armor, int hp)
        {
            Race = race;
            EntityClass = entityClass;
            Alignment = alignment;
            Name = name;
            Height = height;
            Weight = weight;
            Strength = str;
            Dexterity = dex;
            Constitution = con;
            Intelligence = intel;
            Wisdom = wis;
            Perception = per;
            Armor = armor;
            Health = hp;
        }
    }

    // ------------------------------------------------------------------------

    public abstract class EntityCRUD
    {
        public abstract void Create(Entity entity);
        public abstract List<Entity> List();
        public abstract bool Edit(string name, Entity newCharacter);
        public abstract bool Delete(string name);
        public abstract Entity GetName(string name);
    }

    // ------------------------------------------------------------------------

    public class CharacterCRUD : EntityCRUD
    {
        private List<Entity> _characterList = new List<Entity>();

        public List<string> FindRace_Character()
        {
            List<string> characterRaces = new List<string>();
            foreach (string race in Enum.GetNames(typeof(EntityRace)))
            {
                if (race.StartsWith("C") || race.StartsWith("B"))
                {
                    characterRaces.Add(race);
                }
            }
            return characterRaces;
        }

        public List<string> FindClass_Character()
        {
            List<string> characterClasses = new List<string>();

            foreach (string className in Enum.GetNames(typeof(EntityClass)))
            {
                if (className.StartsWith("C") || className.StartsWith("B"))
                {
                    characterClasses.Add(className);
                }
            }
            return characterClasses;
        }

        public List<string> FindAlignment_CharacterAndNPC()
        {
            List<string> characterAlignments = new List<string>();

            foreach(string alignmentName in Enum.GetNames(typeof(EntityAlignment)))
            {
                characterAlignments.Add(alignmentName);
            }
            return characterAlignments;
        }

       // Create
        public override void Create(Entity character)
        {
            _characterList.Add(character);
        }

        // Read
        public override List<Entity> List()
        {
            return _characterList;
        }

        // Update
        public override bool Edit(string name, Entity newCharacter)
        {
            Entity oldCharacter = GetName(name);

            if (oldCharacter != null)
            {
                oldCharacter.Race = newCharacter.Race;
                oldCharacter.EntityClass = newCharacter.EntityClass;
                oldCharacter.Alignment = newCharacter.Alignment;
                oldCharacter.Name = newCharacter.Name;
                oldCharacter.Height = newCharacter.Height;
                oldCharacter.Weight = newCharacter.Weight;
                oldCharacter.Strength = newCharacter.Strength;
                oldCharacter.Dexterity = newCharacter.Dexterity;
                oldCharacter.Constitution = newCharacter.Constitution;
                oldCharacter.Intelligence = newCharacter.Intelligence;
                oldCharacter.Wisdom = newCharacter.Wisdom;
                oldCharacter.Perception = newCharacter.Perception;
                oldCharacter.Armor = newCharacter.Armor;
                oldCharacter.Health = newCharacter.Health;
                return true;
            }
            else
            {
                return false;
            }
        }

        // Delete
        public override bool Delete(string name)
        {
            Entity character = GetName(name);

            if (character == null)
            {
                return false;
            }

            int characterCount = _characterList.Count;
            _characterList.Remove(character);

            if (characterCount > _characterList.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Helper method
        public override Entity GetName(string name)
        {
            foreach (var character in List())
            {
                if (name.ToLower() == character.Name.ToLower())
                {
                    return character;
                }
            }

            return null;
        }
    }

    // ------------------------------------------------------------------------

    public class MonsterCRUD : EntityCRUD
    {
        private List<Entity> _monsterList = new List<Entity>();

        public List<string> FindRace_Monster()
        {
            List<string> monsterRaces = new List<string>();

            foreach (string race in Enum.GetNames(typeof(EntityRace)))
            {
                if (race.StartsWith("M") || race.StartsWith("B"))
                {
                    monsterRaces.Add(race);
                }
            }
            return monsterRaces;
        }

        public List<string> FindClass_Monster()
        {
            List<string> monsterClasses = new List<string>();

            foreach (string className in Enum.GetNames(typeof(EntityClass)))
            {
                if (className.StartsWith("M") || className.StartsWith("B"))
                {
                    monsterClasses.Add(className);
                }
            }
            return monsterClasses;
        }

        public List<string> FindAlignment_Monster()
        {
            List<string> monsterAlignments = new List<string>();

            foreach(string alignmentName in Enum.GetNames(typeof(EntityAlignment)))
            {
                if (alignmentName.StartsWith("M") || alignmentName.StartsWith("B"))
                {
                    monsterAlignments.Add(alignmentName);
                }
            }
            return monsterAlignments;
        }

        public override void Create(Entity monster)
        {
            _monsterList.Add(monster);
        }

        public override List<Entity> List()
        {
            return _monsterList;
        }

        public override bool Edit(string name, Entity newMonster)
        {
            Entity oldMonster = GetName(name);

            if (oldMonster != null)
            {
                oldMonster.Race = newMonster.Race;
                oldMonster.EntityClass = newMonster.EntityClass;
                oldMonster.Alignment = newMonster.Alignment;
                oldMonster.Name = newMonster.Name;
                oldMonster.Height = newMonster.Height;
                oldMonster.Weight = newMonster.Weight;
                oldMonster.Strength = newMonster.Strength;
                oldMonster.Dexterity = newMonster.Dexterity;
                oldMonster.Constitution = newMonster.Constitution;
                oldMonster.Intelligence = newMonster.Intelligence;
                oldMonster.Wisdom = newMonster.Wisdom;
                oldMonster.Perception = newMonster.Perception;
                oldMonster.Armor = newMonster.Armor;
                oldMonster.Health = newMonster.Health;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool Delete(string name)
        {
            Entity monster = GetName(name);

            if (monster == null)
            {
                return false;
            }

            int monsterCount = _monsterList.Count;
            _monsterList.Remove(monster);

            if (monsterCount > _monsterList.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override Entity GetName(string name)
        {
            foreach (Entity monster in List())
            {
                if (name.ToLower() == monster.Name.ToLower())
                {
                    return monster;
                }
            }

            return null;
        }
    }

    // ------------------------------------------------------------------------

    public class NonPlayerCRUD : CharacterCRUD
    {
        private List<Entity> _npcList = new List<Entity>();

        public List<string> GetAllRaces()
        {
            var allRaces = new List<string>();
            foreach(string race in Enum.GetNames(typeof(EntityRace)))
            {
                allRaces.Add(race);
            }

            return allRaces;
        }

        public List<string> GetAllClasses()
        {
            var allClasses = new List<string>();
            foreach(string className in Enum.GetNames(typeof(EntityClass)))
            {
                allClasses.Add(className);
            }

            return allClasses;
        }

        public override void Create(Entity npc)
        {
            _npcList.Add(npc);
        }

        public override List<Entity> List()
        {
            return _npcList;
        }

        public override bool Edit(string name, Entity newNPC)
        {
            Entity oldNPC = GetName(name);

            if (oldNPC != null)
            {
                oldNPC.Race = newNPC.Race;
                oldNPC.EntityClass = newNPC.EntityClass;
                oldNPC.Alignment = newNPC.Alignment;
                oldNPC.Name = newNPC.Name;
                oldNPC.Height = newNPC.Height;
                oldNPC.Weight = newNPC.Weight;
                oldNPC.Strength = newNPC.Strength;
                oldNPC.Dexterity = newNPC.Dexterity;
                oldNPC.Constitution = newNPC.Constitution;
                oldNPC.Intelligence = newNPC.Intelligence;
                oldNPC.Wisdom = newNPC.Wisdom;
                oldNPC.Perception = newNPC.Perception;
                oldNPC.Armor = newNPC.Armor;
                oldNPC.Health = newNPC.Health;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool Delete(string name)
        {
            Entity npc = GetName(name);

            if (npc == null)
            {
                return false;
            }

            int npcCount = _npcList.Count;
            _npcList.Remove(npc);

            if (npcCount > _npcList.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override Entity GetName(string name)
        {
            foreach (Entity npc in List())
            {
                if (name.ToLower() == npc.Name.ToLower())
                {
                    return npc;
                }
            }

            return null;
        }
    }
}
