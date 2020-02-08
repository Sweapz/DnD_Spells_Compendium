using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSpellsCompendium.Models
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

	public class Spell
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public int Range { get; set; }
		public List<string> Components { get; set; }
		public string Duration { get; set; }
		public SpellSchool School { get; set; }


		public Spell(string name, string description, int range, List<string> components, string duration)
		{
			this.Name = name;
			this.Description = description;
			this.Range = range;
			this.Components = components;
			this.Duration = duration;
		}
	}
}
