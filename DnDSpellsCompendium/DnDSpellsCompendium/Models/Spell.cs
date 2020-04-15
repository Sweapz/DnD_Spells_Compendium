using DnDSpellsCompendium.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSpellsCompendium
{
    public class Spell
    {
        private string _name;
        public string Name 
        { 
            get => GetNameWithRitualTag(_name); 
        }

        public string Description { get; set; }
        private string _level;
        public string Level
        {
            get => GetSpellLevel(_level); 
        }

        private string _castTime;
        public string CastTime
        {
            get => _castTime == "Special" ? "Reaction" : _castTime;
        }
        public string Range { get; set; }
        private string _components;
        public string Components
        {
            get => GetComponentLettersOnly(_components); 

        }
        public string Duration { get; set; }
        public SpellSchool School { get; set; }
        public List<Class> Classes { get; set; }
        public string HigherLevel { get; set; }

        public Spell(string name, string description, string level, string range, string components, string duration, string castTime, SpellSchool school, List<Class> classes, string higherLevel = null)
        {
            _name = name;
            Description = description;
            _level = level;
            Range = range;
            _components = components;
            Duration = duration;
            _castTime = castTime;
            School = school;
            Classes = classes;
            HigherLevel = higherLevel;
        }

        public override string ToString()
        {
            string spellString =
                $"Name: {Name}\n" +
                $"Description: {Description}\n" +
                $"Level: {Level}\n" +
                $"Range: {Range}\n" +
                $"Components: {Components}\n" +
                $"Casting Time: {CastTime}\n" +
                $"School: {School.ToString()}\n" +
                "Class: \n";

            Classes.ForEach(dndClass => spellString += $"\t {dndClass.ToString()}\n");

            if (HigherLevel != null)
            {
                spellString += $"Higher Level: {HigherLevel}";
            }

            return spellString;
        }

        private string GetSpellLevel(string level)
        {
            int number;
            if (level == "Cantrip")
            {
                return level;
            }
            else
            {
                number = int.Parse(level);
            }

            switch (number)
            {
                case 1:
                    return $"{number}st level";
                case 2:
                    return $"{number}nd level";
                case 3:
                    return $"{number}rd level";
                default:
                    return $"{number}th level";
            }
        }

        private string GetComponentLettersOnly(string components)
        {
            if (components.Contains("M"))
            {
                int mIndex = components.IndexOf('M');
                if (components.Length > mIndex + 1) // Needed to catch some exceptions where M is not specified.
                {
                    return components.Remove(mIndex + 1);
                }
            }
            return components;
        }

        private string GetNameWithRitualTag(string name)
        {
            return name.Contains("Ritual") ? name.Remove(name.Length - 7) + "R)" : name;
        }

    }
}
