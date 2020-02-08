using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSpellsCompendium.Models
{
	class DnDClass
	{
		public string Name { get; set; }
		public int ClassLevel { get; set; }
		public Spellbook Spells { get; set; }


		public DnDClass()
		{
			
		}
	}
}
