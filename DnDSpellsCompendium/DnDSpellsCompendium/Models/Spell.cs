using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSpellsCompendium
{
	public enum SpellSchool
	{
		Abjuration,
		Conjuration,
		Divination,
		Enchantment,
		Evocation,
		Illusion,
		Necromancy,
		Transmuation
	}

    public class Spell : BaseModel
    {
        private string _classes;
        private string _school;

        public string Name { get; set; }
        public string Description { get; set; }
        public string CastTime { get; set; }
        public string Range { get; set; }
        public string Components { get; set; }
        public string Duration { get; set; }
        public string School
        {
            get { return _school; }
            set { _school = value; }
        }
        public string HigherLevel { get; set; }
        public string Classes
        {
            get { return _classes; }
            set
            {
                _classes = value;
            }
        }


        public Spell(string name, string description, string range, string components, string duration)
        {
            this.Name = name;
            this.Description = description;
            this.Range = range;
            this.Components = components;
            this.Duration = duration;
        }
    }
}
