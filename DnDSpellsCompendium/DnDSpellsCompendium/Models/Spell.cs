using DnDSpellsCompendium.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSpellsCompendium
{
    public class Spell
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CastTime { get; set; }
        public string Range { get; set; }
        public string Components { get; set; }
        public string Duration { get; set; }
        public SpellSchool School { get; set; }
        public List<Class> Classes { get; set; }

        public string HigherLevel { get; set; }


        public Spell(string name, string description, string range, string components, string duration, string castTime, SpellSchool school, List<Class> classes, string higherLevel = null)
        {
            Name = name;
            Description = description;
            Range = range;
            Components = components;
            Duration = duration;
            CastTime = castTime;
            School = school;
            Classes = classes;
            HigherLevel = higherLevel;
        }

        public override string ToString()
        {
            string spellString =
                $"Name: {Name}\n" +
                $"Description: {Description}\n" +
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
    }
}
